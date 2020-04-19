using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class DestructorAccess : IExpression
    {
        public DestructorAccess(IASTLocation location, IExpression obj)
        {
            Location = location;
            Object = obj;
        }

        public IASTLocation Location { get; }
        public IExpression Object { get; }
    }
}
