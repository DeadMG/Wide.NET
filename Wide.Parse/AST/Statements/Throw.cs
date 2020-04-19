using Wide.Parse.AST.Expressions;

namespace Wide.Parse.AST.Statements
{
    public class Throw : IStatement
    {
        public Throw(IASTLocation where)
        {
            Location = where;
        }

        public Throw(IASTLocation where, IExpression what)
            : this(where)
        {
            Exception = what;
        }

        public IASTLocation Location { get; }
        public IExpression Exception { get; }
    }
}
