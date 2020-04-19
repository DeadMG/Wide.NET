using Wide.Lex;

namespace Wide.Parse.AST
{
    public interface IStatement
    {
        ISourceRange Location { get; }
    }
}
