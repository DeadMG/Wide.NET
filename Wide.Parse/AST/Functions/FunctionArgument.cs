using Wide.Lex;
using Wide.Parse.AST.Expressions;

namespace Wide.Parse.AST.Functions
{
    public class FunctionArgument
    {
        public FunctionArgument(IExpression type, IExpression defaultValue, string name, IASTLocation location)
        {
            Type = type;
            DefaultValue = defaultValue;
            Name = name;
            Location = location;
        }

        public IExpression Type { get; }
        public IExpression DefaultValue { get; }
        public string Name { get; }
        public IASTLocation Location { get; }
    }
}
