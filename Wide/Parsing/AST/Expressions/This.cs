using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class This : IExpression
    {
        public This(ISourceRange location)
        {
            Location = location;
        }

        public ISourceRange Location { get; }
    }
}
