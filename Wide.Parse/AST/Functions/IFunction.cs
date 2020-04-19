using System.Collections.Generic;
using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Functions
{
    public interface IFunction
    {
        IASTLocation Location { get; }
        IEnumerable<FunctionArgument> Arguments { get; }
        IEnumerable<IStatement> Body { get; }
    }
}
