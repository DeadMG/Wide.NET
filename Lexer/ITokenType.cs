using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wide.Util;

namespace Wide.Lexical
{
    public interface ITokenType : Equality.ReferenceEqual
    {
        string Name { get; }
        string FixedSource { get; }
    }
}
