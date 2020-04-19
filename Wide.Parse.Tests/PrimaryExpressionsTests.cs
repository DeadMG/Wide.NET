using System.Linq;
using NUnit.Framework;
using Wide.Lex;
using Wide.Parse.AST;
using Wide.Parse.AST.Expressions;
using Wide.Util;

namespace Wide.Parse.Tests
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
            var token = new LexedToken(new SourceRange(new SourcePosition("test", 1, 0, 0), new SourcePosition("test", 1, 1, 1)), PredefinedTokenTypes.This, "this");
            var expr = new Parser().ParseExpression(new Parser().PutbackRangeFromTokens(Enumerable.Repeat(token, 1)), null);
            Assert.That(Equality.DeepEqual(expr, new This(new TokenASTLocation(token.Location))));
        }

        [Test]
        public void ThrowsForInvalidTokenType()
        {
            var token = new LexedToken(new SourceRange(new SourcePosition("test", 1, 0, 0), new SourcePosition("test", 1, 1, 1)), new RandomTokenType(), "");
            Assert.Throws<ParserException>(() => new Parser().ParseExpression(new Parser().PutbackRangeFromTokens(Enumerable.Repeat(token, 1)), null));
        }
    }
}
