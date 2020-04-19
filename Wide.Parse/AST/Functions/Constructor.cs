using System.Collections.Generic;
using Wide.Lex;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Functions
{
    public class Constructor : IAttributeFunction, IDefaultedFunction
    {
        public Constructor(IASTLocation location, IEnumerable<FunctionArgument> args, IEnumerable<Attribute> attributes, IEnumerable<IStatement> body, bool defaulted)
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
        public IASTLocation Location { get; }
    }
}
