using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class String : IExpression
    {
        public String(string value, IASTLocation location)
        {
            Value = value;
            Location = location;
        }

        public IASTLocation Location { get; }
        public string Value { get; }
    }
}
