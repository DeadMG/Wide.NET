using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class IndexExpression : IExpression
    {
        public IndexExpression(IASTLocation location, IExpression obj, IExpression index)
        {
            Location = location;
            Object = obj;
            Index = index;
        }

        public IExpression Object { get; }
        public IExpression Index { get; }
        public IASTLocation Location { get; }
    }
}
