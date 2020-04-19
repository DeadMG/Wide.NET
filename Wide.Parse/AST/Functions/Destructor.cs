using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse.AST.Functions
{
    public class Destructor : IFunction, IDefaultedFunction, IAttributeFunction, IDynamicFunction
    {
        public Destructor(IEnumerable<FunctionArgument> arguments, IEnumerable<Attribute> attributes, IEnumerable<IStatement> body, bool defaulted, bool dynamic, ISourceRange location)
        {
            Arguments = arguments;
            Attributes = attributes;
            Body = body;
            Defaulted = defaulted;
            Dynamic = dynamic;
            Location = location;
        }

        public IEnumerable<FunctionArgument> Arguments { get; }
        public IEnumerable<Attribute> Attributes { get; }
        public IEnumerable<IStatement> Body { get; }
        public bool Defaulted { get; }
        public bool Dynamic { get; }
        public ISourceRange Location { get; }
    }
}
