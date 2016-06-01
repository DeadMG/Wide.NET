using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class Identifier : IExpression
    {
        public Identifier(Name name, Import import, ISourceRange location)
        {
            Name = name;
            Import = import;
            Location = location;
        }

        public Name Name { get; }
        public Import Import { get; }
        public ISourceRange Location { get; }
    }
}
