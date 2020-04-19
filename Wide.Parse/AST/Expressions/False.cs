using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class False : IExpression
    {
        public False(ISourceRange loc)
        {
            Location = loc;
        }

        public ISourceRange Location { get; }
    }
}
