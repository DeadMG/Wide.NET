using System.Collections.Generic;
using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class FunctionCall : IExpression
    {
        public FunctionCall(IASTLocation location, IExpression callee, IEnumerable<IExpression> arguments)
        {
            Location = location;
            Callee = callee;
            Arguments = arguments;
        }

        public IExpression Callee { get; }
        public IEnumerable<IExpression> Arguments { get; }
        public IASTLocation Location { get; }
    }
}
