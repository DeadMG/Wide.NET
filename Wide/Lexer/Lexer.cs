using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
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
        
        public IEnumerable<IToken> ParseComments(ISourcePosition position, LexerState state)
        {
            int num = 1;
            var comment = "";
            while (true)
            {
                var next = state.GetNext();
                if (next == null) break;
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
            yield return new Token(new SourceRange(position, state.CurrentPosition), PredefinedTokenTypes.Comment, comment);
            if (num != 0)
            {
                yield return new Token(new SourceRange(state.CurrentPosition, state.CurrentPosition), PredefinedTokenTypes.Error, "Unterminated comment");
            }
        }

        public class InputCharacter
        {
            public char Character;
            public ISourcePosition Begin;
            public ISourcePosition End;
        }

        public class LexerState
        {
            private List<InputCharacter> putback = new List<InputCharacter>();
            private IEnumerator<char> currentCharacter;
            private int tabsize;

            public ISourcePosition CurrentPosition { get; private set; }

            public LexerState(IEnumerator<char> characterEnumerator, ISourcePosition initialPosition, int tabsize)
            {
                CurrentPosition = initialPosition;
                currentCharacter = characterEnumerator;
                this.tabsize = tabsize;
            }

            public void Putback(InputCharacter character)
            {
                if (character == null) return;
                putback.Add(character);
            }

            public InputCharacter GetNext()
            {
                if (putback.Any())
                {
                    var last = putback.Last();
                    putback.RemoveAt(putback.Count - 1);
                    return last;
                }
                if (currentCharacter.MoveNext())
                {
                    var next = currentCharacter.Current;
                    var begin = CurrentPosition;
                    CurrentPosition = CurrentPosition.Advance(next, tabsize);
                    return new InputCharacter
                    {
                        Character = next,
                        Begin = begin,
                        End = CurrentPosition
                    };
                }
                return null;
            }
        }

        private IToken TryLexFixedToken(ISourcePosition start, string existing, LexerState state)
        {
            var next = state.GetNext();
            if (next == null)
            {
                if (FixedTokens.ContainsKey(existing))
                    return new Token(new SourceRange(start, state.CurrentPosition), FixedTokens[existing], existing);
                return null;
            }

            var potentialNext = existing + next.Character;
            if (!FixedTokens.Any(p => p.Key.StartsWith(potentialNext)))
            {
                state.Putback(next);
                return null;
            }

            var tryGreedy = TryLexFixedToken(start, potentialNext, state);
            if (tryGreedy != null)
                return tryGreedy;
            
            state.Putback(next);

            if (FixedTokens.ContainsKey(existing))
                return new Token(new SourceRange(start, next.End), FixedTokens[existing], existing);

            return null;
        }

        public IEnumerable<IToken> Lex(IEnumerable<char> input, ISourcePosition initialPosition)
        {
            var state = new LexerState(input.GetEnumerator(), initialPosition, tabsize);

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
                        while (true)
                        {
                            var possibleTerminator = state.GetNext();
                            if (possibleTerminator == null)
                            {
                                yield return new Token(new SourceRange(next.Begin, state.CurrentPosition), PredefinedTokenTypes.Comment, comment);
                                yield break;
                            }
                            if (possibleTerminator.Character == '\n')
                            {
                                yield return new Token(new SourceRange(next.Begin, state.CurrentPosition), PredefinedTokenTypes.Comment, comment);
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
                
                var token = TryLexFixedToken(next.Begin, next.Character.ToString(), state);
                if (token != null)
                {
                    yield return token;
                    continue;
                }
                if (FixedTokens.ContainsKey(next.Character.ToString()))
                {
                    yield return new Token(new SourceRange(next.Begin, state.CurrentPosition), FixedTokens[next.Character.ToString()], next.Character.ToString());
                    continue;
                }

                if (next.Character == '"')
                {
                    var stringValue = "";
                    var wasPreviousCharacterSlash = false;
                    while (true)
                    {
                        var nextChar = state.GetNext();
                        if (nextChar == null)
                        {
                            yield return new Token(new SourceRange(next.Begin, state.CurrentPosition), PredefinedTokenTypes.String, stringValue);
                            yield return new Token(new SourceRange(state.CurrentPosition, state.CurrentPosition), PredefinedTokenTypes.Error, "Unterminated string literal");
                            yield break;
                        }
                        if (!wasPreviousCharacterSlash && nextChar.Character == '"')
                        {
                            yield return new Token(new SourceRange(next.Begin, state.CurrentPosition), PredefinedTokenTypes.String, stringValue);
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
                        yield return new Token(new SourceRange(next.Begin, next.End), PredefinedTokenTypes.Error, "Unlexable character");
                        continue;
                    }
                }

                var value = next.Character.ToString();
                while (true)
                {
                    var nextChar = state.GetNext();
                    if (nextChar == null)
                    {
                        yield return new Token(new SourceRange(startPosition, state.CurrentPosition), type, value);
                        yield break;
                    }
                    if (!Char.IsLetterOrDigit(nextChar.Character))
                        break;
                    if (Char.IsLetter(nextChar.Character))
                        type = PredefinedTokenTypes.Identifier;
                    value += nextChar.Character;
                }
                yield return new Token(new SourceRange(startPosition, state.CurrentPosition), type, value);
            }
        }        
    }
}
