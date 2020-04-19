using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class MemberAccess : IExpression
    {
        public MemberAccess(IASTLocation location, IExpression obj, Name member)
        {
            Location = location;
            Object = obj;
            Member = member;
        }

        public IASTLocation Location { get; }
        public IExpression Object { get; }
        public Name Member { get; }
    }
}
