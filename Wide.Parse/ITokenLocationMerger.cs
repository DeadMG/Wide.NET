using Wide.Lex;
using Wide.Parse.AST;

namespace Wide.Parse
{
    public interface ITokenLocationMerger
    {
        IASTLocation Merge(ITokenLocation begin, ITokenLocation end);
    }
}
