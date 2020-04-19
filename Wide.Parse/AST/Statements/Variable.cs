using System.Collections.Generic;
using Wide.Lex;
using Wide.Parse.AST.Expressions;

namespace Wide.Parse.AST.Statements
{
    public class Variable : IStatement
    {
        public Variable(IASTLocation location, IEnumerable<Name> names, IExpression type, IExpression initializer)
        {
            Location = location;
            Names = names;
            Type = type;
            Initializer = initializer;
        }

        public IASTLocation Location { get; }
        public IEnumerable<Name> Names { get; }
        public IExpression Type { get; }
        public IExpression Initializer { get; }
    }
}
