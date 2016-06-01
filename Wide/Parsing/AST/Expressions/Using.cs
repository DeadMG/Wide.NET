using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class Using
    {
        public Using(ISourceRange location, IExpression expr)
        {
            Location = location;
            Expression = expr;
        }

        public ISourceRange Location { get; }
        public IExpression Expression { get; }
    }
}
