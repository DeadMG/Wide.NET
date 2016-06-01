using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class DestructorAccess : IExpression
    {
        public DestructorAccess(ISourceRange location, IExpression obj)
        {
            Location = location;
            Object = obj;
        }

        public ISourceRange Location { get; }
        public IExpression Object { get; }
    }
}
