using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Functions
{
    public interface IFunction
    {
        ISourceRange Location { get; }
        IEnumerable<FunctionArgument> Arguments { get; }
        IEnumerable<IStatement> Body { get; }
    }
}
