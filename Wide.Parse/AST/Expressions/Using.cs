using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class Using
    {
        public Using(ISourceRange location, IExpression expr)
        {
            Location = location;
            Expression = expr;
        }

        public ISourceRange Location { get; }
        public IExpression Expression { get; }
    }
}
