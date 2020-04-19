using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class Identifier : IExpression
    {
        public Identifier(Name name, Import import, IASTLocation location)
        {
            Name = name;
            Import = import;
            Location = location;
        }

        public Name Name { get; }
        public Import Import { get; }
        public IASTLocation Location { get; }
    }
}
