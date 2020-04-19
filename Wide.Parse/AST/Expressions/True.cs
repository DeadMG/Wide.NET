using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class True : IExpression
    {
        public True(IASTLocation loc)
        {
            Location = loc;
        }

        public IASTLocation Location { get; }
    }
}
