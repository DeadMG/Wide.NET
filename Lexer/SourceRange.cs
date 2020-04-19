namespace Wide.Lex
{
    public class SourceRange : ISourceRange
    {
        public SourceRange(ISourcePosition begin, ISourcePosition end)
        {
            Begin = begin;
            End = end;
        }

        public ISourcePosition Begin { get; }
        public ISourcePosition End { get; }
    }
}
