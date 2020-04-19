using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class DestructorAccess : IExpression
    {
        public DestructorAccess(ISourceRange location, IExpression obj)
        {
            Location = location;
            Object = obj;
        }

        public ISourceRange Location { get; }
        public IExpression Object { get; }
    }
}
