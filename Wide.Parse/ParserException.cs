using System;
using System.Collections.Generic;
using Wide.Lex;

namespace Wide.Parse
{
    public class ParserException : Exception
    {
        public ParserException(HashSet<ITokenType> permitted, IToken badToken)
        {
            PermittedTypes = permitted;
            BadToken = badToken;
        }

        public HashSet<ITokenType> PermittedTypes { get; }
        public IToken BadToken { get; }    
    }
}
