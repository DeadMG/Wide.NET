using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse.AST.Functions
{
    public class Function : IDynamicFunction, IDefaultedFunction, IAbstractFunction, IAttributeFunction
    {
        public Function(
            ISourceRange location,
            IEnumerable<FunctionArgument> arguments, 
            IEnumerable<IStatement> body,
            IEnumerable<Attribute> attributes,
            IExpression explicitReturn, 
            bool @abstract,
            bool defaulted,
            bool dynamic)
        {
            Location = location;
            Arguments = arguments;
            Body = body;
            Attributes = attributes;
            ExplicitReturn = explicitReturn;
            Abstract = @abstract;
            Defaulted = defaulted;
            Dynamic = dynamic;
        }

        public ISourceRange Location { get; }
        public IEnumerable<FunctionArgument> Arguments { get; }
        public IEnumerable<IStatement> Body { get; }
        public IEnumerable<Attribute> Attributes { get; }
        public IExpression ExplicitReturn { get; }
        public bool Abstract { get; }
        public bool Defaulted { get; }
        public bool Dynamic { get; }
    }
}
