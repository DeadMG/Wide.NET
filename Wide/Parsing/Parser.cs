using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;
using Wide.Parsing.AST;
using Wide.Parsing.AST.Expressions;
using Wide.Util;

namespace Wide.Parsing
{
    public class Parser
    {
        public Dictionary<ITokenType, Func<Parser, Import, Token, IExpression>> PrimaryExpressions = new Dictionary<ITokenType, Func<Parser, Import, Token, IExpression>>
        {
            { PredefinedTokenTypes.This, (parser, import, token) => new This(token.Location) },
            { PredefinedTokenTypes.String, (parser, import, token) => new AST.Expressions.String(token.Value, token.Location) },
            { PredefinedTokenTypes.Integer, (parser, import, token) => new Integer(token.Location, token.Value) },
            { PredefinedTokenTypes.True, (parser, import, token) => new True(token.Location) },
            { PredefinedTokenTypes.False, (parser, import, token) => new False(token.Location) }
        };

        public Token Expect(PutbackRange<Token> tokens, IEnumerable<ITokenType> permitted)
        {
            var set = new HashSet<ITokenType>(permitted);
            var next = tokens.GetNext();
            if (next == null)
                throw new ParserException(set, null);
            if (!permitted.Contains(next.Type))
                throw new ParserException(set, next);
            return next; 
        }

        public IExpression ParseExpression(PutbackRange<Token> tokens, Import import)
        {
            var next = Expect(tokens, PrimaryExpressions.Keys);
            return PrimaryExpressions[next.Type](this, import, next);
        }

        public PutbackRange<Token> PutbackRangeFromTokens(IEnumerable<Token> inputTokens)
        {
            return new PutbackRange<Token>(inputTokens.Where(t => t.Type != PredefinedTokenTypes.Comment && t.Type != PredefinedTokenTypes.Error));
        }
    }
}
