using Wide.Lex;

namespace Wide.Parse.AST.Expressions
{
    public class Identifier : IExpression
    {
        public Identifier(Name name, Import import, ISourceRange location)
        {
            Name = name;
            Import = import;
            Location = location;
        }

        public Name Name { get; }
        public Import Import { get; }
        public ISourceRange Location { get; }
    }
}
