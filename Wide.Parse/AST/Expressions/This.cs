using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class This : IExpression
    {
        public This(ISourceRange location)
        {
            Location = location;
        }

        public ISourceRange Location { get; }
    }
}
