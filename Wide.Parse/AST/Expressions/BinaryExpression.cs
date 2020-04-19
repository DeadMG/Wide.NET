using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class BinaryExpression : IExpression
    {
        public BinaryExpression(IASTLocation location, IExpression left, IExpression right, ITokenType type)
        {
            Location = location;
            Left = left;
            Right = right;
            Type = type;
        }

        public IASTLocation Location { get; }
        public IExpression Left { get; }
        public IExpression Right { get; }
        public ITokenType Type { get; }
    }
}
