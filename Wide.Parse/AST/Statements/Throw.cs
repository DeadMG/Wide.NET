using Wide.Lex;

namespace Wide.Parse.AST.Statements
{
    public class Throw : IStatement
    {
        public Throw(ISourceRange where)
        {
            Location = where;
        }

        public Throw(ISourceRange where, IExpression what)
            : this(where)
        {
            Exception = what;
        }

        public ISourceRange Location { get; }
        public IExpression Exception { get; }
    }
}
