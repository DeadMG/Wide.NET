using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Statements
{
    public class Throw : IStatement
    {
        public Throw(ISourceRange where)
        {
            Location = where;
        }

        public Throw(ISourceRange where, IExpression what)
            : this(where)
        {
            Exception = what;
        }

        public ISourceRange Location { get; }
        public IExpression Exception { get; }
    }
}
