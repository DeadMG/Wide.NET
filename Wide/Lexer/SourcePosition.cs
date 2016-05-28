using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
{
    public class SourcePosition : ISourcePosition
    {
        public SourcePosition(int line, int column, int offset)
        {
            Line = line;
            Column = column;
            Offset = offset;
        }

        public SourcePosition Advance(char c, int tabsize)
        {
            if (c == '\n')
            {
                return new SourcePosition(Line + 1, 0, Offset + 1);
            }
            if (c == '\t')
            {
                return new SourcePosition(Line, Column + tabsize, Offset + 1);
            }
            return new SourcePosition(Line, Column + 1, Offset + 1);
        }

        ISourcePosition ISourcePosition.Advance(char c, int tabsize)
        {
            return Advance(c, tabsize);
        }

        public int Line { get; private set; }
        public int Column { get; private set; }
        public int Offset { get; private set; }

        public override string ToString()
        {
            return Line + ":" + Column;
        }

        public override bool Equals(object obj)
        {
            var otherpos = obj as SourcePosition;
            if (otherpos == null) return false;
            return ToString() == otherpos.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
