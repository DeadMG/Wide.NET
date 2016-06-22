using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class Integer : IExpression
    {
        public Integer(ISourceRange loc, string value)
        {
            Location = loc;
            Value = value;
        }

        public ISourceRange Location { get; }
        public string Value { get; }
    }
}
