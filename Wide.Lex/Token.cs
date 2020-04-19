namespace Wide.Lex
{
    public class Token : IToken
    {
        public Token(ISourceRange loc, ITokenType type, string value)
        {
            Location = loc;
            Type = type;
            Value = value;
        }

        public ISourceRange Location { get; private set; }
        public ITokenType Type { get; private set; }
        public string Value { get; private set; }
    }
}
