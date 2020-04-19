using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class Using
    {
        public Using(IASTLocation location, IExpression expr)
        {
            Location = location;
            Expression = expr;
        }

        public IASTLocation Location { get; }
        public IExpression Expression { get; }
    }
}
