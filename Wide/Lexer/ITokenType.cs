using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
{
    public interface ITokenType
    {
        string Name { get; }
        string FixedSource { get; }
    }
}
