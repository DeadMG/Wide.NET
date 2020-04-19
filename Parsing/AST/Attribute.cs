using Wide.Lex;

namespace Wide.Parse.AST
{
    public class Attribute
    {
        public Attribute(ISourceRange location, IExpression initializer, IExpression initialized)
        {
            Location = location;
            Initializer = initializer;
            Initialized = initialized;
        }

        public ISourceRange Location { get; }
        public IExpression Initializer { get; }
        public IExpression Initialized { get; }
    }
}
