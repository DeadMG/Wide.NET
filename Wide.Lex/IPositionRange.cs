namespace Wide.Lex
{
    public interface ISourceRange
    {
        ISourcePosition Begin { get; }
        ISourcePosition End { get; }
    }
}
