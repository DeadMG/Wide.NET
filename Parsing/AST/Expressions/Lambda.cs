using System.Collections.Generic;
using Wide.Lex;
using Wide.Parse.AST.Functions;
using Wide.Parse.AST.Statements;

namespace Wide.Parse.AST.Expressions
{
    public class Lambda : IExpression, IFunction
    {
        public enum CaptureMode
        {
            ByValue,
            ByReference
        }

        public Lambda(ISourceRange location, IEnumerable<FunctionArgument> args, IEnumerable<IStatement> body, IEnumerable<Variable> captures, CaptureMode defaultref)
        {
            Location = location;
            Arguments = args;
            Body = body;
            Captures = captures;
            CaptureByRefByDefault = defaultref;
        }

        public CaptureMode CaptureByRefByDefault { get; }
        public IEnumerable<Variable> Captures { get; }
        public IEnumerable<FunctionArgument> Arguments { get; }
        public IEnumerable<IStatement> Body { get; }
        public ISourceRange Location { get; }
    }
}
