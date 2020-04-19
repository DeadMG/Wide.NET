namespace Wide.Lex
{
    public interface IToken
    {
        ISourceRange Location { get; }
        string Value { get; }
        ITokenType Type { get; }
    }
}
