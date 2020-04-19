using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse.AST.Statements
{
    public class Variable : IStatement
    {
        public Variable(ISourceRange location, IEnumerable<Name> names, IExpression type, IExpression initializer)
        {
            Location = location;
            Names = names;
            Type = type;
            Initializer = initializer;
        }

        public ISourceRange Location { get; }
        public IEnumerable<Name> Names { get; }
        public IExpression Type { get; }
        public IExpression Initializer { get; }
    }
}
