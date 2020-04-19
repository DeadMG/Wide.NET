using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;
using Wide.Parsing;
using Wide.Parsing.AST.Expressions;
using Wide.Util;

namespace Wide.ParsingTest
{
    [TestFixture]
    public class PrimaryExpressionsTests
    {
        private class RandomTokenType : ITokenType
        {
            public string FixedSource => null;
            public string Name => "";
        }

        [Test]
        public void CheckHasPrimaryExpressionsByDefault()
        {
            Assert.That(new Parser().PrimaryExpressions.Count != 0);
        }

        [Test]
        public void CheckCanParseThis()
        {
            var token = new Token(new SourceRange(new SourcePosition(1, 0, 0), new SourcePosition(1, 1, 1)), PredefinedTokenTypes.This, "this");
            var expr = new Parser().ParseExpression(new Parser().PutbackRangeFromTokens(Enumerable.Repeat(token, 1)), null);
            Assert.That(Equality.DeepEqual(expr, new This(token.Location)));
        }

        [Test]
        [ExpectedException(typeof(ParserException))]
        public void ThrowsForInvalidTokenType()
        {
            var token = new Token(new SourceRange(new SourcePosition(1, 0, 0), new SourcePosition(1, 1, 1)), new RandomTokenType(), "");
            new Parser().ParseExpression(new Parser().PutbackRangeFromTokens(Enumerable.Repeat(token, 1)), null);
        }
    }
}
