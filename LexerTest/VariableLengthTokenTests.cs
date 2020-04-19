using System.Linq;

namespace Wide.Lex.Tests
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
            var lexer = new Lexer();
            var stringValue = "3DScene";
            var sampleInput = "\"" + stringValue + "\"";
            var startPosition = new SourcePosition(1, 0, 0);
            var results = lexer.Lex(sampleInput, startPosition).ToList();
            Assert.That(results.Count == 1);
            Assert.That(results[0].Type == PredefinedTokenTypes.String);
            Assert.That(results[0].Value == stringValue);
            Assert.AreEqual(results[0].Location.Begin, startPosition);
            Assert.AreEqual(results[0].Location.End, sampleInput.Aggregate(startPosition, (pos, character) => pos.Advance(character, lexer.tabsize)));
        }

        [Test]
        public void TestEscapes()
        {
            var lexer = new Lexer();
            var stringValue = "\\r\\n\\t\\\"";
            var sampleInput = "\"" + stringValue + "\"";
            var startPosition = new SourcePosition(1, 0, 0);
            var results = lexer.Lex(sampleInput, startPosition).ToList();
            Assert.That(results.Count == 1);
            Assert.That(results[0].Type == PredefinedTokenTypes.String);
            Assert.That(results[0].Value == "\r\n\t\"");
            Assert.AreEqual(results[0].Location.Begin, startPosition);
            Assert.AreEqual(results[0].Location.End, sampleInput.Aggregate(startPosition, (pos, character) => pos.Advance(character, lexer.tabsize)));
        }

        [Test]
        public void TestIntegers()
        {
            var lexer = new Lexer();
            var sampleInput = "11111";
            var startPosition = new SourcePosition(1, 0, 0);
            var results = lexer.Lex(sampleInput, startPosition).ToList();
            Assert.That(results.Count == 1);
            Assert.That(results[0].Type == PredefinedTokenTypes.Integer);
            Assert.That(results[0].Value == sampleInput);
            Assert.AreEqual(results[0].Location.Begin, startPosition);
            Assert.AreEqual(results[0].Location.End, sampleInput.Aggregate(startPosition, (pos, character) => pos.Advance(character, lexer.tabsize)));
        }
    }
}
