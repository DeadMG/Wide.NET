using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Functions
{
    public class FunctionArgument
    {
        public FunctionArgument(IExpression type, IExpression defaultValue, string name, ISourceRange location)
        {
            Type = type;
            DefaultValue = defaultValue;
            Name = name;
            Location = location;
        }

        public IExpression Type { get; }
        public IExpression DefaultValue { get; }
        public string Name { get; }
        public ISourceRange Location { get; }
    }
}
