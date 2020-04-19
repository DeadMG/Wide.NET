using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
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
