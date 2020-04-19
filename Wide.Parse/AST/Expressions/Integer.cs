using Wide.Lex;

namespace Wide.Parse.AST.Expressions
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
