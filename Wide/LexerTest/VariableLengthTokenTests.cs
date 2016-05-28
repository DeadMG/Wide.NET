﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.LexerTest
{
    [TestFixture]
    public class VariableLengthTokenTests
    {
        [Test]
        public void TestIdentifierMayStartWithANumber()
        {
            var lexer = new Lexer();
            var sampleInput = "3DScene";
            var startPosition = new SourcePosition(1, 0, 0);
            var results = lexer.Lex(sampleInput, startPosition).ToList();
            Assert.That(results.Count == 1);
            Assert.That(results[0].Type == PredefinedTokenTypes.Identifier);
            Assert.That(results[0].Value == sampleInput);
            Assert.AreEqual(results[0].Location.Begin, startPosition);
            Assert.AreEqual(results[0].Location.End, sampleInput.Aggregate(startPosition, (pos, character) => pos.Advance(character, lexer.tabsize)));
        }

        [Test]
        public void TestString()
        {

        }
    }
}
