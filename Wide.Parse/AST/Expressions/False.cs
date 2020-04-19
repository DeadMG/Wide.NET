using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class False : IExpression
    {
        public False(IASTLocation loc)
        {
            Location = loc;
        }

        public IASTLocation Location { get; }
    }
}
