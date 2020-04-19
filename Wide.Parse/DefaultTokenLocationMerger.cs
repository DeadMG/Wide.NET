using Wide.Lex;
using Wide.Parse.AST;

namespace Wide.Parse
{
    public class DefaultTokenLocationMerger : ITokenLocationMerger
    {
        public IASTLocation Merge(ITokenLocation begin, ITokenLocation end)
        {
            if (begin is SourceRange beginrange && end is SourceRange endrange)
            {
                return new TokenRangeASTLocation(beginrange, endrange);
            }

            return new TokenLocationsASTLocation(begin, end);
        }

        private class TokenLocationsASTLocation : IASTLocation
        {
            public TokenLocationsASTLocation(ITokenLocation begin, ITokenLocation end)
            {
                this.Begin = begin;
                this.End = end;
            }

            public ITokenLocation Begin { get; }
            public ITokenLocation End { get; }
            public string Description => Begin.Description + " - " + End.Description;
        }

        private class TokenRangeASTLocation : IASTLocation
        {
            public TokenRangeASTLocation(SourceRange begin, SourceRange end)
            {
                this.Begin = begin;
                this.End = end;
            }

            public SourceRange Begin { get; }
            public SourceRange End { get; }
            public string Description => new SourceRange(Begin.Begin, End.End).Description;
        }
    }
}
