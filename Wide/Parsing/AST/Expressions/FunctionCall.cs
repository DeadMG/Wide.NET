using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
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
