using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class MemberAccess : IExpression
    {
        public MemberAccess(ISourceRange location, IExpression obj, Name member)
        {
            Location = location;
            Object = obj;
            Member = member;
        }

        public ISourceRange Location { get; }
        public IExpression Object { get; }
        public Name Member { get; }
    }
}
