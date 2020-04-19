namespace Wide.Lex
{
    public interface IToken
    {
        ITokenLocation Location { get; }
        string Value { get; }
        ITokenType Type { get; }
    }
}
