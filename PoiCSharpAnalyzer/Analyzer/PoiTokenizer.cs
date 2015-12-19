/*
 * PoiTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 *
 *
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage {

    /**
     * <remarks>A character stream tokenizer.</remarks>
     */
    internal class PoiTokenizer : Tokenizer {

        /**
         * <summary>Creates a new tokenizer for the specified input
         * stream.</summary>
         *
         * <param name='input'>the input stream to read</param>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        public PoiTokenizer(TextReader input)
            : base(input, false) {

            CreatePatterns();
        }

        /**
         * <summary>Initializes the tokenizer by creating all the token
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            TokenPattern  pattern;

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_LEFT_PAREN,
                                       "SYMBOL_LEFT_PAREN",
                                       TokenPattern.PatternType.STRING,
                                       "(");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_RIGHT_PAREN,
                                       "SYMBOL_RIGHT_PAREN",
                                       TokenPattern.PatternType.STRING,
                                       ")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_LEFT_BRACE,
                                       "SYMBOL_LEFT_BRACE",
                                       TokenPattern.PatternType.STRING,
                                       "{");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_RIGHT_BRACE,
                                       "SYMBOL_RIGHT_BRACE",
                                       TokenPattern.PatternType.STRING,
                                       "}");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_LEFT_BRACKET,
                                       "SYMBOL_LEFT_BRACKET",
                                       TokenPattern.PatternType.STRING,
                                       "[");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_RIGHT_BRACKET,
                                       "SYMBOL_RIGHT_BRACKET",
                                       TokenPattern.PatternType.STRING,
                                       "]");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_QUESTION_MARK,
                                       "SYMBOL_QUESTION_MARK",
                                       TokenPattern.PatternType.STRING,
                                       "?");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_COLON_MARK,
                                       "SYMBOL_COLON_MARK",
                                       TokenPattern.PatternType.STRING,
                                       ":");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_SEMICOLON,
                                       "SYMBOL_SEMICOLON",
                                       TokenPattern.PatternType.STRING,
                                       ";");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_COMMA,
                                       "SYMBOL_COMMA",
                                       TokenPattern.PatternType.STRING,
                                       ",");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_DOT,
                                       "SYMBOL_DOT",
                                       TokenPattern.PatternType.STRING,
                                       ".");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SYMBOL_ARROW,
                                       "SYMBOL_ARROW",
                                       TokenPattern.PatternType.STRING,
                                       "->");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_ASSIGN,
                                       "OPERATOR_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_ADD_ASSIGN,
                                       "OPERATOR_ADD_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "+=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_SUB_ASSIGN,
                                       "OPERATOR_SUB_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "-=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_MUL_ASSIGN,
                                       "OPERATOR_MUL_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "*=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_DIV_ASSIGN,
                                       "OPERATOR_DIV_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "/=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_MOD_ASSIGN,
                                       "OPERATOR_MOD_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "%=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_SHIFT_LEFT_ASSIGN,
                                       "OPERATOR_SHIFT_LEFT_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "<<=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_SHIFT_RIGHT_ASSIGN,
                                       "OPERATOR_SHIFT_RIGHT_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       ">>=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_AND_ASSIGN,
                                       "OPERATOR_BIT_AND_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "&=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_OR_ASSIGN,
                                       "OPERATOR_BIT_OR_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "^=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_XOR_ASSIGN,
                                       "OPERATOR_BIT_XOR_ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "|=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_ADD,
                                       "OPERATOR_ADD",
                                       TokenPattern.PatternType.STRING,
                                       "+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_SUB,
                                       "OPERATOR_SUB",
                                       TokenPattern.PatternType.STRING,
                                       "-");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_MUL,
                                       "OPERATOR_MUL",
                                       TokenPattern.PatternType.STRING,
                                       "*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_DIV,
                                       "OPERATOR_DIV",
                                       TokenPattern.PatternType.STRING,
                                       "/");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_MODULAR,
                                       "OPERATOR_MODULAR",
                                       TokenPattern.PatternType.STRING,
                                       "%");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_LESS,
                                       "OPERATOR_LESS",
                                       TokenPattern.PatternType.STRING,
                                       "<");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_GREATER,
                                       "OPERATOR_GREATER",
                                       TokenPattern.PatternType.STRING,
                                       ">");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_UNEQUAL,
                                       "OPERATOR_UNEQUAL",
                                       TokenPattern.PatternType.STRING,
                                       "!=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_EQUAL,
                                       "OPERATOR_EQUAL",
                                       TokenPattern.PatternType.STRING,
                                       "==");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_LESS_EQUAL,
                                       "OPERATOR_LESS_EQUAL",
                                       TokenPattern.PatternType.STRING,
                                       "<=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_GREATER_EQUAL,
                                       "OPERATOR_GREATER_EQUAL",
                                       TokenPattern.PatternType.STRING,
                                       ">=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_LOGIC_AND,
                                       "OPERATOR_LOGIC_AND",
                                       TokenPattern.PatternType.STRING,
                                       "&&");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_LOGIC_OR,
                                       "OPERATOR_LOGIC_OR",
                                       TokenPattern.PatternType.STRING,
                                       "||");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_LOGIC_NOT,
                                       "OPERATOR_LOGIC_NOT",
                                       TokenPattern.PatternType.STRING,
                                       "!");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_AND,
                                       "OPERATOR_BIT_AND",
                                       TokenPattern.PatternType.STRING,
                                       "&");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_OR,
                                       "OPERATOR_BIT_OR",
                                       TokenPattern.PatternType.STRING,
                                       "|");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_NOT,
                                       "OPERATOR_BIT_NOT",
                                       TokenPattern.PatternType.STRING,
                                       "~");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_BIT_XOR,
                                       "OPERATOR_BIT_XOR",
                                       TokenPattern.PatternType.STRING,
                                       "^");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_INC,
                                       "OPERATOR_INC",
                                       TokenPattern.PatternType.STRING,
                                       "++");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_DEC,
                                       "OPERATOR_DEC",
                                       TokenPattern.PatternType.STRING,
                                       "--");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_SHIFT_LEFT,
                                       "OPERATOR_SHIFT_LEFT",
                                       TokenPattern.PatternType.STRING,
                                       "<<");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_SHIFT_RIGHT,
                                       "OPERATOR_SHIFT_RIGHT",
                                       TokenPattern.PatternType.STRING,
                                       ">>");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.OPERATOR_CAST,
                                       "OPERATOR_CAST",
                                       TokenPattern.PatternType.STRING,
                                       "cast");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER8,
                                       "PRIMITIVE_INTEGER8",
                                       TokenPattern.PatternType.STRING,
                                       "int8");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER8_ALIAS,
                                       "PRIMITIVE_INTEGER8_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "byte");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER16,
                                       "PRIMITIVE_INTEGER16",
                                       TokenPattern.PatternType.STRING,
                                       "int16");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER16_ALIAS,
                                       "PRIMITIVE_INTEGER16_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "short");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER32,
                                       "PRIMITIVE_INTEGER32",
                                       TokenPattern.PatternType.STRING,
                                       "int32");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER32_ALIAS,
                                       "PRIMITIVE_INTEGER32_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "int");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER64,
                                       "PRIMITIVE_INTEGER64",
                                       TokenPattern.PatternType.STRING,
                                       "int64");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_INTEGER64_ALIAS,
                                       "PRIMITIVE_INTEGER64_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "long");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER8,
                                       "PRIMITIVE_UINTEGER8",
                                       TokenPattern.PatternType.STRING,
                                       "uint8");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER8_ALIAS,
                                       "PRIMITIVE_UINTEGER8_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "ubyte");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER16,
                                       "PRIMITIVE_UINTEGER16",
                                       TokenPattern.PatternType.STRING,
                                       "uint16");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER16_ALIAS,
                                       "PRIMITIVE_UINTEGER16_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "ushort");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER32,
                                       "PRIMITIVE_UINTEGER32",
                                       TokenPattern.PatternType.STRING,
                                       "uint32");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER32_ALIAS,
                                       "PRIMITIVE_UINTEGER32_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "uint");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER64,
                                       "PRIMITIVE_UINTEGER64",
                                       TokenPattern.PatternType.STRING,
                                       "uint64");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_UINTEGER64_ALIAS,
                                       "PRIMITIVE_UINTEGER64_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "ulong");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_SINGLE,
                                       "PRIMITIVE_SINGLE",
                                       TokenPattern.PatternType.STRING,
                                       "single");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_SINGLE_ALIAS,
                                       "PRIMITIVE_SINGLE_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "float");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_DOUBLE,
                                       "PRIMITIVE_DOUBLE",
                                       TokenPattern.PatternType.STRING,
                                       "double");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_EXTENDED,
                                       "PRIMITIVE_EXTENDED",
                                       TokenPattern.PatternType.STRING,
                                       "extended");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_BOOLEAN,
                                       "PRIMITIVE_BOOLEAN",
                                       TokenPattern.PatternType.STRING,
                                       "boolean");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_BOOLEAN_ALIAS,
                                       "PRIMITIVE_BOOLEAN_ALIAS",
                                       TokenPattern.PatternType.STRING,
                                       "bool");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.PRIMITIVE_CHARACTER,
                                       "PRIMITIVE_CHARACTER",
                                       TokenPattern.PatternType.STRING,
                                       "char");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CONTAINER_STRING,
                                       "CONTAINER_STRING",
                                       TokenPattern.PatternType.STRING,
                                       "string");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CONTAINER_ARRAY,
                                       "CONTAINER_ARRAY",
                                       TokenPattern.PatternType.STRING,
                                       "array");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CONTAINER_MAP,
                                       "CONTAINER_MAP",
                                       TokenPattern.PatternType.STRING,
                                       "map");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CONTAINER_EVENT,
                                       "CONTAINER_EVENT",
                                       TokenPattern.PatternType.STRING,
                                       "event");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.FUNCTION_TYPE,
                                       "FUNCTION_TYPE",
                                       TokenPattern.PatternType.STRING,
                                       "function");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.FUNCTION_SIGN,
                                       "FUNCTION_SIGN",
                                       TokenPattern.PatternType.STRING,
                                       "@");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.FUNCTION_RETURN,
                                       "FUNCTION_RETURN",
                                       TokenPattern.PatternType.STRING,
                                       "return");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOGIC_TRUE,
                                       "LOGIC_TRUE",
                                       TokenPattern.PatternType.STRING,
                                       "true");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOGIC_FALSE,
                                       "LOGIC_FALSE",
                                       TokenPattern.PatternType.STRING,
                                       "false");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.DECLARATION_GETTER,
                                       "DECLARATION_GETTER",
                                       TokenPattern.PatternType.STRING,
                                       "get");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.DECLARATION_SETTER,
                                       "DECLARATION_SETTER",
                                       TokenPattern.PatternType.STRING,
                                       "set");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.DECLARATION_ALLOC,
                                       "DECLARATION_ALLOC",
                                       TokenPattern.PatternType.STRING,
                                       "new");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CLASS_TYPE,
                                       "CLASS_TYPE",
                                       TokenPattern.PatternType.STRING,
                                       "struct");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CLASS_EXTEND,
                                       "CLASS_EXTEND",
                                       TokenPattern.PatternType.STRING,
                                       "as");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CLASS_PUBLIC,
                                       "CLASS_PUBLIC",
                                       TokenPattern.PatternType.STRING,
                                       "public");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CLASS_PRIVATE,
                                       "CLASS_PRIVATE",
                                       TokenPattern.PatternType.STRING,
                                       "private");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.CLASS_PROTECTED,
                                       "CLASS_PROTECTED",
                                       TokenPattern.PatternType.STRING,
                                       "protected");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.BRANCH_IF,
                                       "BRANCH_IF",
                                       TokenPattern.PatternType.STRING,
                                       "if");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.BRANCH_ELSE,
                                       "BRANCH_ELSE",
                                       TokenPattern.PatternType.STRING,
                                       "else");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_FOR,
                                       "LOOP_FOR",
                                       TokenPattern.PatternType.STRING,
                                       "for");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_INITIAL,
                                       "LOOP_INITIAL",
                                       TokenPattern.PatternType.STRING,
                                       "init");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_WHILE,
                                       "LOOP_WHILE",
                                       TokenPattern.PatternType.STRING,
                                       "while");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_STEP,
                                       "LOOP_STEP",
                                       TokenPattern.PatternType.STRING,
                                       "step");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_UNTIL,
                                       "LOOP_UNTIL",
                                       TokenPattern.PatternType.STRING,
                                       "until");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_BREAK,
                                       "LOOP_BREAK",
                                       TokenPattern.PatternType.STRING,
                                       "break");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LOOP_CONTINUE,
                                       "LOOP_CONTINUE",
                                       TokenPattern.PatternType.STRING,
                                       "continue");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_BOOLEAN_TRUE,
                                       "LITERAL_BOOLEAN_TRUE",
                                       TokenPattern.PatternType.STRING,
                                       "true");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_BOOLEAN_FALSE,
                                       "LITERAL_BOOLEAN_FALSE",
                                       TokenPattern.PatternType.STRING,
                                       "false");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_NUMERIC_INTEGER_DECIMAL,
                                       "LITERAL_NUMERIC_INTEGER_DECIMAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "-?(0|([1-9][0-9]*))");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_NUMERIC_INTEGER_OCTAL,
                                       "LITERAL_NUMERIC_INTEGER_OCTAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "0(0|[1-7][0-7]*)");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_NUMERIC_INTEGER_HEXADECIMAL,
                                       "LITERAL_NUMERIC_INTEGER_HEXADECIMAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "0x[0-9a-fA-F]+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_NUMERIC_REAL,
                                       "LITERAL_NUMERIC_REAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "-?((0|[1-9][0-9]*)\\.[0-9]+)");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_NUMERIC_UINTEGER_DECIMAL,
                                       "LITERAL_NUMERIC_UINTEGER_DECIMAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "(0|([1-9][0-9]*))U");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_STRING,
                                       "LITERAL_STRING",
                                       TokenPattern.PatternType.REGEXP,
                                       "\"[^\"]*\"");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LITERAL_CHARACTER,
                                       "LITERAL_CHARACTER",
                                       TokenPattern.PatternType.REGEXP,
                                       "'[^']'");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.IDENTIFIER,
                                       "IDENTIFIER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[a-zA-Z_][a-zA-Z0-9_]*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SINGLE_LINE_COMMENT,
                                       "SINGLE_LINE_COMMENT",
                                       TokenPattern.PatternType.REGEXP,
                                       "//.*");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.MULTI_LINE_COMMENT,
                                       "MULTI_LINE_COMMENT",
                                       TokenPattern.PatternType.REGEXP,
                                       "/\\*([^*]|\\*+[^*/])*\\*+/");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.ERRORTOKEN,
                                       "ERRORTOKEN",
                                       TokenPattern.PatternType.REGEXP,
                                       ".");
            pattern.ErrorMessage = "unexpected token";
            AddPattern(pattern);
        }
    }
}
