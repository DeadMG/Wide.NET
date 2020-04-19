using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class MemberAccess : IExpression
    {
        public MemberAccess(ISourceRange location, IExpression obj, Name member)
        {
            Location = location;
            Object = obj;
            Member = member;
        }

        public ISourceRange Location { get; }
        public IExpression Object { get; }
        public Name Member { get; }
    }
}
