using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST
{
    public interface IStatement
    {
        ISourceRange Location { get; }
    }
}
