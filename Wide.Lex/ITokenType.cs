using Wide.Util;

namespace Wide.Lex
{
    public interface ITokenType : Equality.ReferenceEqual
    {
        string Name { get; }
        string FixedSource { get; }
    }
}
