using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Lexical;

namespace Wide.Parsing
{
    public class ParserException : Exception
    {
        public ParserException(HashSet<ITokenType> permitted, Token badToken)
        {
            PermittedTypes = permitted;
            BadToken = badToken;
        }

        public HashSet<ITokenType> PermittedTypes { get; }
        public Token BadToken { get; }    
    }
}
