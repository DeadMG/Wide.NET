using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
{
    public interface IToken<out T>
    {
        T Location { get; }
        string Value { get; }
        ITokenType Type { get; }
    }
}
