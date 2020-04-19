using System.Collections.Generic;
using Wide.Parse.AST.Expressions;

namespace Wide.Parse.AST
{
    public class Import
    {
        public Import(IExpression from, IEnumerable<Name> names, Import prev, IEnumerable<Name> hidden)
        {
            From = from;
            Names = names;
            Previous = prev;
            Hidden = hidden;
        }

        public IExpression From { get; }
        public IEnumerable<Name> Names { get; }
        public Import Previous { get; }
        public IEnumerable<Name> Hidden { get; }
    }
}
