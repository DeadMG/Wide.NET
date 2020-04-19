using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class FunctionCall : IExpression
    {
        public FunctionCall(ISourceRange location, IExpression callee, IEnumerable<IExpression> arguments)
        {
            Location = location;
            Callee = callee;
            Arguments = arguments;
        }

        public IExpression Callee { get; }
        public IEnumerable<IExpression> Arguments { get; }
        public ISourceRange Location { get; }
    }
}
