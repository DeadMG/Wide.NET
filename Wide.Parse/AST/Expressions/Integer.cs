using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class Integer : IExpression
    {
        public Integer(IASTLocation loc, string value)
        {
            Location = loc;
            Value = value;
        }

        public IASTLocation Location { get; }
        public string Value { get; }
    }
}
