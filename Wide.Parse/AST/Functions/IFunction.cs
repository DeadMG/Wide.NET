using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse.AST.Functions
{
    public interface IFunction
    {
        ISourceRange Location { get; }
        IEnumerable<FunctionArgument> Arguments { get; }
        IEnumerable<IStatement> Body { get; }
    }
}
