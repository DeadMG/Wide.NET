using System;
using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse
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
