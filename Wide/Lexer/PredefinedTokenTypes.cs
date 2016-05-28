using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Lexical
{
    public class PredefinedTokenTypes
    {
        private class PredefinedTokenType : ITokenType
        {
            public PredefinedTokenType(string name, bool isFixed = true)
            {
                Name = name;
                FixedSource = isFixed ? name : null;
            }

            public string Name { get; private set; }
            public string FixedSource { get; private set; }
        }

        public static readonly ITokenType OpenBracket = new PredefinedTokenType("(");
        public static readonly ITokenType CloseBracket = new PredefinedTokenType(")");
        public static readonly ITokenType Dot = new PredefinedTokenType(".");
        public static readonly ITokenType Semicolon = new PredefinedTokenType(";");
        public static readonly ITokenType LeftShift = new PredefinedTokenType("<<");
        public static readonly ITokenType RightShift = new PredefinedTokenType(">>");
        public static readonly ITokenType OpenCurlyBracket = new PredefinedTokenType("{");
        public static readonly ITokenType CloseCurlyBracket = new PredefinedTokenType("}");
        public static readonly ITokenType Return = new PredefinedTokenType("return");
        public static readonly ITokenType Assignment = new PredefinedTokenType("=");
        public static readonly ITokenType VarCreate = new PredefinedTokenType(":=");
        public static readonly ITokenType Comma = new PredefinedTokenType(",");
        public static readonly ITokenType Using = new PredefinedTokenType("using");
        public static readonly ITokenType Module = new PredefinedTokenType("module");
        public static readonly ITokenType Break = new PredefinedTokenType("break");
        public static readonly ITokenType Continue = new PredefinedTokenType("continue");
        public static readonly ITokenType If = new PredefinedTokenType("if");
        public static readonly ITokenType Else = new PredefinedTokenType("else");
        public static readonly ITokenType EqCmp = new PredefinedTokenType("==");
        public static readonly ITokenType Exclaim = new PredefinedTokenType("!");
        public static readonly ITokenType While = new PredefinedTokenType("while");
        public static readonly ITokenType NotEqCmp = new PredefinedTokenType("!=");
        public static readonly ITokenType This = new PredefinedTokenType("this");
        public static readonly ITokenType Type = new PredefinedTokenType("type");
        public static readonly ITokenType Operator = new PredefinedTokenType("operator");
        public static readonly ITokenType Function = new PredefinedTokenType("function");
        public static readonly ITokenType OpenSquareBracket = new PredefinedTokenType("[");
        public static readonly ITokenType CloseSquareBracket = new PredefinedTokenType("]");
        public static readonly ITokenType Colon = new PredefinedTokenType(":");
        public static readonly ITokenType Star = new PredefinedTokenType("*");
        public static readonly ITokenType PointerAccess = new PredefinedTokenType("->");
        public static readonly ITokenType Negate = new PredefinedTokenType("~");
        public static readonly ITokenType Plus = new PredefinedTokenType("+");
        public static readonly ITokenType Increment = new PredefinedTokenType("++");
        public static readonly ITokenType Decrement = new PredefinedTokenType("--");
        public static readonly ITokenType Minus = new PredefinedTokenType("-");
        public static readonly ITokenType LT = new PredefinedTokenType("<");
        public static readonly ITokenType LTE = new PredefinedTokenType("<=");
        public static readonly ITokenType GT = new PredefinedTokenType(">");
        public static readonly ITokenType GTE = new PredefinedTokenType(">=");
        public static readonly ITokenType Or = new PredefinedTokenType("|");
        public static readonly ITokenType DoubleOr = new PredefinedTokenType("||");
        public static readonly ITokenType And = new PredefinedTokenType("&");
        public static readonly ITokenType DoubleAnd = new PredefinedTokenType("&&");
        public static readonly ITokenType Xor = new PredefinedTokenType("^");
        public static readonly ITokenType RightShiftAssign = new PredefinedTokenType(">>=");
        public static readonly ITokenType LeftShiftAssign = new PredefinedTokenType("<<=");
        public static readonly ITokenType MinusAssign = new PredefinedTokenType("-=");
        public static readonly ITokenType PlusAssign = new PredefinedTokenType("+=");
        public static readonly ITokenType AndAssign = new PredefinedTokenType("&=");
        public static readonly ITokenType OrAssign = new PredefinedTokenType("|=");
        public static readonly ITokenType MulAssign = new PredefinedTokenType("*=");
        public static readonly ITokenType Modulo = new PredefinedTokenType("%");
        public static readonly ITokenType ModAssign = new PredefinedTokenType("%=");
        public static readonly ITokenType Divide = new PredefinedTokenType("/");
        public static readonly ITokenType DivAssign = new PredefinedTokenType("/=");
        public static readonly ITokenType XorAssign = new PredefinedTokenType("^=");
        public static readonly ITokenType Ellipsis = new PredefinedTokenType("...");
        public static readonly ITokenType Lambda = new PredefinedTokenType("=>");
        public static readonly ITokenType Template = new PredefinedTokenType("template");
        public static readonly ITokenType Concept = new PredefinedTokenType("concept");
        public static readonly ITokenType ConceptMap = new PredefinedTokenType("concept_map");
        public static readonly ITokenType Public = new PredefinedTokenType("public");
        public static readonly ITokenType Private = new PredefinedTokenType("private");
        public static readonly ITokenType Protected = new PredefinedTokenType("protected");
        public static readonly ITokenType Dynamic = new PredefinedTokenType("dynamic");
        public static readonly ITokenType Decltype = new PredefinedTokenType("decltype");
        public static readonly ITokenType True = new PredefinedTokenType("true");
        public static readonly ITokenType False = new PredefinedTokenType("false");
        public static readonly ITokenType Typeid = new PredefinedTokenType("typeid");
        public static readonly ITokenType DynamicCast = new PredefinedTokenType("dynamic_cast");
        public static readonly ITokenType Try = new PredefinedTokenType("try");
        public static readonly ITokenType Catch = new PredefinedTokenType("catch");
        public static readonly ITokenType Throw = new PredefinedTokenType("throw");
        public static readonly ITokenType QuestionMark = new PredefinedTokenType("?");
        public static readonly ITokenType Abstract = new PredefinedTokenType("abstract");
        public static readonly ITokenType Delete = new PredefinedTokenType("delete");
        public static readonly ITokenType Default = new PredefinedTokenType("default");

        public static readonly ITokenType Import = new PredefinedTokenType("import");
        public static readonly ITokenType From = new PredefinedTokenType("from");
        public static readonly ITokenType Hiding = new PredefinedTokenType("hiding");

        public static readonly ITokenType Comment = new PredefinedTokenType("comment", false);
        public static readonly ITokenType Error = new PredefinedTokenType("error", false);

        public static readonly ITokenType Identifier = new PredefinedTokenType("identifier", false);
        public static readonly ITokenType String = new PredefinedTokenType("string", false);
        public static readonly ITokenType Integer = new PredefinedTokenType("integer", false);
    }
}
