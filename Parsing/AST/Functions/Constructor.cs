using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse.AST.Functions
{
    public class Constructor : IAttributeFunction, IDefaultedFunction
    {
        public Constructor(ISourceRange location, IEnumerable<FunctionArgument> args, IEnumerable<Attribute> attributes, IEnumerable<IStatement> body, bool defaulted)
        {
            Location = location;
            Arguments = args;
            Attributes = attributes;
            Body = body;
            Defaulted = defaulted;
        }

        public IEnumerable<FunctionArgument> Arguments { get; }
        public IEnumerable<Attribute> Attributes { get; }
        public IEnumerable<IStatement> Body { get; }
        public bool Defaulted { get; }
        public ISourceRange Location { get; }
    }
}
