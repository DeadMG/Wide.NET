using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class String : IExpression
    {
        public String(string value, ISourceRange location)
        {
            Value = value;
            Location = location;
        }

        public ISourceRange Location { get; }
        public string Value { get; }
    }
}
