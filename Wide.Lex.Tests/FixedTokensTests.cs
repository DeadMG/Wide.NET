﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Wide.Lex.Tests
{
    [TestFixture]
    public class FixedTokensTests
    {
        [Test]
        public void CheckHasFixedTokensByDefault()
        {
            Assert.That(new Lex.Lexer().FixedTokens.Count != 0);
        }

        [TestCaseSource(nameof(PredefinedFixedTokens))]
        [Test]
        public void CheckCanLexFixedTokens(ITokenType tokenType)
        {
            var startPosition = new SourcePosition("test", 1, 0, 0);
            var lexer = new Lex.Lexer();
            var results = lexer.Lex(tokenType.FixedSource, new SourcePosition("test", 1, 0, 0)).ToList();
            Assert.That(results.Count == 1);
            Assert.That(results[0].Type == tokenType);
            Assert.That(results[0].Value == tokenType.FixedSource);
            Assert.AreEqual(results[0].Location.Begin, startPosition);
            Assert.AreEqual(results[0].Location.End, tokenType.FixedSource.Aggregate(startPosition, (pos, character) => pos.Advance(character, lexer.tabsize)));
        }

        public static IEnumerable<ITokenType> PredefinedFixedTokens => new Lex.Lexer().FixedTokens.Values.ToList();
    }
}
