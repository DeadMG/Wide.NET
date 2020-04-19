namespace Wide.Lex
{
    public class LexedToken : IToken
    {
        public LexedToken(SourceRange loc, ITokenType type, string value)
        {
            Location = loc;
            Type = type;
            Value = value;
        }

        public SourceRange Location { get; }
        ITokenLocation IToken.Location => Location;
        public ITokenType Type { get; }
        public string Value { get;  }
    }
}
