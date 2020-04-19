namespace Wide.Lex
{
    public class SourceRange : ITokenLocation
    {
        public SourceRange(SourcePosition begin, SourcePosition end)
        {
            this.Begin = begin;
            this.End = end;
        }

        public SourcePosition Begin { get; }
        public SourcePosition End { get; }

        public string Description => Begin.Description + " - " + End.Description;
    }
}
