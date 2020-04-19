using System;
using System.Collections.Generic;
using System.Linq;
using Wide.Util;

namespace Wide.Lex
{
    public class Lexer
    {
        public Dictionary<char, string> Escapes = new Dictionary<char, string>
        {
            { 't', "\t" },
            { 'n', "\n" },
            { 'r', "\r" },
            { '"', "\"" }
        };

        public Dictionary<string, ITokenType> FixedTokens = typeof(PredefinedTokenTypes)
            .GetFields()
            .Where(f => f.IsStatic)
            .Select(f => f.GetValue(null))
            .OfType<ITokenType>()
            .Where(f => f.FixedSource != null)
            .ToDictionary(t => t.FixedSource);

        public HashSet<char> Whitespace = new HashSet<char>
        {
            '\r',
            ' ',
            '\t',
            '\n'
        };

        public int tabsize = 4;
        
        public IEnumerable<LexedToken> ParseComments(SourcePosition position, PutbackRange<InputCharacter> state)
        {
            int num = 1;
            var comment = "";
            var end = position;
            while (true)
            {
                var next = state.GetNext();
                if (next == null) break;
                end = next.End;
                if (next.Character == '*')
                {
                    next = state.GetNext();
                    if (next == null) break;
                    if (next.Character == '/')
                    {
                        --num;
                        if (num == 0)
                            break;
                    }
                }
                if (next.Character == '/')
                {
                    next = state.GetNext();
                    if (next == null) break;
                    if (next.Character == '*')
                        ++num;
                }
            }
            yield return new LexedToken(new SourceRange(position, end), PredefinedTokenTypes.Comment, comment);
            if (num != 0)
            {
                yield return new LexedToken(new SourceRange(end, end), PredefinedTokenTypes.Error, "Unterminated comment");
            }
        }

        public class InputCharacter
        {
            public InputCharacter(char c, SourcePosition begin, SourcePosition end)
            {
                Character = c;
                Begin = begin;
                End = end;
            }
            public char Character { get; }
            public SourcePosition Begin { get; }
            public SourcePosition End { get; }
        }
        
        private LexedToken TryLexFixedToken(SourcePosition start, SourcePosition end, string existing, PutbackRange<InputCharacter> state)
        {
            var next = state.GetNext();
            if (next == null)
            {
                if (FixedTokens.ContainsKey(existing))
                    return new LexedToken(new SourceRange(start, end), FixedTokens[existing], existing);
                return null;
            }

            var potentialNext = existing + next.Character;
            if (!FixedTokens.Any(p => p.Key.StartsWith(potentialNext)))
            {
                state.Putback(next);
                return null;
            }

            var tryGreedy = TryLexFixedToken(start, next.End, potentialNext, state);
            if (tryGreedy != null)
                return tryGreedy;
            
            state.Putback(next);

            if (FixedTokens.ContainsKey(existing))
                return new LexedToken(new SourceRange(start, next.End), FixedTokens[existing], existing);

            return null;
        }

        public IEnumerable<LexedToken> Lex(IEnumerable<char> input, SourcePosition initialPosition)
        {
            var state = new PutbackRange<InputCharacter>(input.SelectAggregate(initialPosition, (character, currentPos) => currentPos.Advance(character, tabsize), (character, begin, end) => new InputCharacter(character, begin, end)));

            while (true)
            {
                var next = state.GetNext();
                if (next == null)
                    yield break;

                if (Whitespace.Contains(next.Character))
                    continue;

                if (next.Character == '/')
                {
                    var possibleComment = state.GetNext();
                    if (possibleComment?.Character == '*')
                    {
                        foreach (var comment in ParseComments(next.Begin, state))
                            yield return comment;
                        continue;
                    }
                    else if (possibleComment?.Character == '/')
                    {
                        var comment = "";
                        var end = possibleComment.End;
                        while (true)
                        {
                            var possibleTerminator = state.GetNext();
                            if (possibleTerminator == null)
                            {
                                yield return new LexedToken(new SourceRange(next.Begin, end), PredefinedTokenTypes.Comment, comment);
                                yield break;
                            }
                            end = possibleTerminator.End;
                            if (possibleTerminator.Character == '\n')
                            {
                                yield return new LexedToken(new SourceRange(next.Begin, end), PredefinedTokenTypes.Comment, comment);
                                break;
                            }
                            comment += possibleTerminator.Character;
                        }
                        continue;
                    }
                    else
                    {
                        state.Putback(possibleComment);
                    }
                }
                
                var token = TryLexFixedToken(next.Begin, next.End, next.Character.ToString(), state);
                if (token != null)
                {
                    yield return token;
                    continue;
                }
                if (FixedTokens.ContainsKey(next.Character.ToString()))
                {
                    yield return new LexedToken(new SourceRange(next.Begin, next.End), FixedTokens[next.Character.ToString()], next.Character.ToString());
                    continue;
                }

                if (next.Character == '"')
                {
                    var stringValue = "";
                    var wasPreviousCharacterSlash = false;
                    var end = next.End;
                    while (true)
                    {
                        var nextChar = state.GetNext();
                        if (nextChar == null)
                        {
                            yield return new LexedToken(new SourceRange(next.Begin, end), PredefinedTokenTypes.String, stringValue);
                            yield return new LexedToken(new SourceRange(end, end), PredefinedTokenTypes.Error, "Unterminated string literal");
                            yield break;
                        }
                        end = nextChar.End;
                        if (!wasPreviousCharacterSlash && nextChar.Character == '"')
                        {
                            yield return new LexedToken(new SourceRange(next.Begin, nextChar.End), PredefinedTokenTypes.String, stringValue);
                            break;
                        }
                        var effectiveCharacter = nextChar.Character.ToString();
                        if (wasPreviousCharacterSlash)
                        {
                            if (Escapes.ContainsKey(nextChar.Character))
                            {
                                // Remove the last slash.
                                stringValue = stringValue.Remove(stringValue.Length - 1, 1);
                                effectiveCharacter = Escapes[nextChar.Character];
                                wasPreviousCharacterSlash = false;
                            }
                        }
                        stringValue += effectiveCharacter;
                        wasPreviousCharacterSlash = !wasPreviousCharacterSlash && nextChar.Character == '\\';
                    }
                    continue;
                }

                var type = PredefinedTokenTypes.Integer;
                var startPosition = next.Begin;
                if (next.Character == '@')
                {
                    type = PredefinedTokenTypes.Identifier;
                    next = state.GetNext();
                }
                else
                {
                    if (!Char.IsLetterOrDigit(next.Character))
                    {
                        yield return new LexedToken(new SourceRange(next.Begin, next.End), PredefinedTokenTypes.Error, "Unlexable character");
                        continue;
                    }
                }

                var value = next.Character.ToString();
                var lastEnd = next.End;
                while (true)
                {
                    var nextChar = state.GetNext();
                    if (nextChar == null)
                    {
                        yield return new LexedToken(new SourceRange(startPosition, lastEnd), type, value);
                        yield break;
                    }
                    if (!Char.IsLetterOrDigit(nextChar.Character))
                        break;
                    if (Char.IsLetter(nextChar.Character))
                        type = PredefinedTokenTypes.Identifier;
                    value += nextChar.Character;
                    lastEnd = nextChar.End;
                }
                yield return new LexedToken(new SourceRange(startPosition, lastEnd), type, value);
            }
        }        
    }
}
