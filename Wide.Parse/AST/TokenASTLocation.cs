using Wide.Lex;

namespace Wide.Parse.AST
{
    public class TokenASTLocation : IASTLocation
    {
        public TokenASTLocation(ITokenLocation tokenLocation)
        {
            this.TokenLocation = tokenLocation;
        }

        public ITokenLocation TokenLocation { get; }
        public string Description => TokenLocation.Description;
    }
}
