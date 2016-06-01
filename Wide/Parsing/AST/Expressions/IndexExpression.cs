using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class IndexExpression : IExpression
    {
        public IndexExpression(ISourceRange location, IExpression obj, IExpression index)
        {
            Location = location;
            Object = obj;
            Index = index;
        }

        public IExpression Object { get; }
        public IExpression Index { get; }
        public ISourceRange Location { get; }
    }
}
