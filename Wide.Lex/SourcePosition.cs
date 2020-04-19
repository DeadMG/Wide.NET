using System;

namespace Wide.Lex
{
    public class SourcePosition
    {
        public SourcePosition(string source, int line, int column, int offset)
        {
            Source = source;
            Line = line;
            Column = column;
            Offset = offset;
        }

        public SourcePosition Advance(char c, int tabsize)
        {
            if (c == '\n')
            {
                return new SourcePosition(Source, Line + 1, 0, Offset + 1);
            }
            if (c == '\t')
            {
                return new SourcePosition(Source, Line, Column + tabsize, Offset + 1);
            }
            return new SourcePosition(Source, Line, Column + 1, Offset + 1);
        }

        public int Line { get; }
        public int Column { get; }
        public int Offset { get; }
        public string Source { get; }

        public override bool Equals(object obj)
        {
            var otherpos = obj as SourcePosition;
            if (otherpos == null) return false;
            return ToString() == otherpos.ToString();
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }

        public string Description => String.Join(":", Source, Line.ToString(), Column.ToString());
    }
}
