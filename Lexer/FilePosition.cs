namespace Wide.Lex
{
    public class FilePosition : ISourcePosition
    {
        private readonly SourcePosition Source;

        public FilePosition(SourcePosition source, string name)
        {
            Source = source;
            Filename = name;
        }

        public readonly string Filename;

        public int Line => Source.Line;
        public int Column => Source.Column;
        public int Offset => Source.Offset;

        public ISourcePosition Advance(char c, int tabsize)
        {
            return new FilePosition(Source.Advance(c, tabsize), Filename);
        }

        public override string ToString()
        {
            return Filename + ":" + Source.ToString();
        }
    }
}
