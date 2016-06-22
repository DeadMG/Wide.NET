using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class True : IExpression
    {
        public True(ISourceRange loc)
        {
            Location = loc;
        }

        public ISourceRange Location { get; }
    }
}
