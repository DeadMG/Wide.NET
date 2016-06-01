using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Statements
{
    public class Variable : IStatement
    {
        public Variable(ISourceRange location, IEnumerable<Name> names, IExpression type, IExpression initializer)
        {
            Location = location;
            Names = names;
            Type = type;
            Initializer = initializer;
        }

        public ISourceRange Location { get; }
        public IEnumerable<Name> Names { get; }
        public IExpression Type { get; }
        public IExpression Initializer { get; }
    }
}
