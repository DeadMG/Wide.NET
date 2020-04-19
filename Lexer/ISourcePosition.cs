namespace Wide.Lex
{
    public interface ISourcePosition
    {
        int Line { get; }
        int Column { get; }
        int Offset { get; }

        ISourcePosition Advance(char c, int tabsize);
    }
}
