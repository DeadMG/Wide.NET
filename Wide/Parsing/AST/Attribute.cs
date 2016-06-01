using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST
{
    public class Attribute
    {
        public Attribute(ISourceRange location, IExpression initializer, IExpression initialized)
        {
            Location = location;
            Initializer = initializer;
            Initialized = initialized;
        }

        public ISourceRange Location { get; }
        public IExpression Initializer { get; }
        public IExpression Initialized { get; }
    }
}
