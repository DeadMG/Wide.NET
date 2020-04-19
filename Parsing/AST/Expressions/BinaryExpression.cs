using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing.AST.Expressions
{
    public class BinaryExpression : IExpression
    {
        public BinaryExpression(ISourceRange location, IExpression left, IExpression right, ITokenType type)
        {
            Location = location;
            Left = left;
            Right = right;
            Type = type;
        }

        public ISourceRange Location { get; }
        public IExpression Left { get; }
        public IExpression Right { get; }
        public ITokenType Type { get; }
    }
}
