using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class This : IExpression
    {
        public This(IASTLocation location)
        {
            Location = location;
        }

        public IASTLocation Location { get; }
    }
}
