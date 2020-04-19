using System;
using System.Collections.Generic;
using System.Linq;
using Wide.Lex;
using Wide.Parse.AST;
using Wide.Parse.AST.Expressions;
using Wide.Util;
using String = Wide.Parse.AST.Expressions.String;

namespace Wide.Parse
{
    public class Parser
    {
        public Dictionary<ITokenType, Func<Parser, Import, IToken, IExpression>> PrimaryExpressions = new Dictionary<ITokenType, Func<Parser, Import, IToken, IExpression>>
        {
            { PredefinedTokenTypes.This, (parser, import, token) => new This(new TokenASTLocation(token.Location)) },
            { PredefinedTokenTypes.String, (parser, import, token) => new String(token.Value, new TokenASTLocation(token.Location)) },
            { PredefinedTokenTypes.Integer, (parser, import, token) => new Integer(new TokenASTLocation(token.Location), token.Value) },
            { PredefinedTokenTypes.True, (parser, import, token) => new True(new TokenASTLocation(token.Location)) },
            { PredefinedTokenTypes.False, (parser, import, token) => new False(new TokenASTLocation(token.Location)) }
        };

        public ITokenLocationMerger TokenLocationMerger { get; set; } = new DefaultTokenLocationMerger();

        public IToken Expect(PutbackRange<IToken> tokens, IEnumerable<ITokenType> permitted)
        {
            var set = new HashSet<ITokenType>(permitted);
            var next = tokens.GetNext();
            if (next == null)
                throw new ParserException(set, null);
            if (!permitted.Contains(next.Type))
                throw new ParserException(set, next);
            return next; 
        }

        public IExpression ParseExpression(PutbackRange<IToken> tokens, Import import)
        {
            var next = Expect(tokens, PrimaryExpressions.Keys);
            return PrimaryExpressions[next.Type](this, import, next);
        }

        public PutbackRange<IToken> PutbackRangeFromTokens(IEnumerable<IToken> inputTokens)
        {
            return new PutbackRange<IToken>(inputTokens.Where(t => t.Type != PredefinedTokenTypes.Comment && t.Type != PredefinedTokenTypes.Error));
        }
    }
}
