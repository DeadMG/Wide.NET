using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class True : IExpression
    {
        public True(ISourceRange loc)
        {
            Location = loc;
        }

        public ISourceRange Location { get; }
    }
}
