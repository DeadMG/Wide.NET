using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
{
    public interface ISourcePosition
    {
        int Line { get; }
        int Column { get; }
        int Offset { get; }

        ISourcePosition Advance(char c, int tabsize);
    }
}
