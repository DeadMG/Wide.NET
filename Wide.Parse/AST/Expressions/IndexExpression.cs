using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class IndexExpression : IExpression
    {
        public IndexExpression(ISourceRange location, IExpression obj, IExpression index)
        {
            Location = location;
            Object = obj;
            Index = index;
        }

        public IExpression Object { get; }
        public IExpression Index { get; }
        public ISourceRange Location { get; }
    }
}
