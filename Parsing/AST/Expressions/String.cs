using Wide.Lex;

namespace Wide.Parse.AST.Expressions
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
