using Wide.Parse.AST.Expressions;

namespace Wide.Parse.AST
{
    public class Attribute
    {
        public Attribute(IASTLocation location, IExpression initializer, IExpression initialized)
        {
            Location = location;
            Initializer = initializer;
            Initialized = initialized;
        }

        public IASTLocation Location { get; }
        public IExpression Initializer { get; }
        public IExpression Initialized { get; }
    }
}
