using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.LexerTest
{
    [TestFixture]
    public class FixedTokensTests
    {
        [Test]
        public void CheckHasFixedTokensByDefault()
        {
            Assert.That(new Lexer().FixedTokens.Count != 0);
        }

        [TestCaseSource("PredefinedFixedTokens")]
        [Test]
        public void CheckCanLexFixedTokens(ITokenType tokenType)
        {
            var startPosition = new SourcePosition(1, 0, 0);
            var lexer = new Lexer();
            var results = lexer.Lex(tokenType.FixedSource, new SourcePosition(1, 0, 0)).ToList();
            Assert.That(results.Count == 1);
            Assert.That(results[0].Type == tokenType);
            Assert.That(results[0].Value == tokenType.FixedSource);
            Assert.AreEqual(results[0].Location.Begin, startPosition);
            Assert.AreEqual(results[0].Location.End, tokenType.FixedSource.Aggregate(startPosition, (pos, character) => pos.Advance(character, lexer.tabsize)));
        }

        public IEnumerable<ITokenType> PredefinedFixedTokens => new Lexer().FixedTokens.Values.ToList();
    }
}
