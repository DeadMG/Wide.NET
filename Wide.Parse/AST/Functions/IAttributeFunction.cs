using System.Collections.Generic;

namespace Wide.Parse.AST.Functions
{
    public interface IAttributeFunction : IFunction
    {
        IEnumerable<Attribute> Attributes { get; }
    }
}
