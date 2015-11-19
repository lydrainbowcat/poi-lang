/*
 * PoiParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 *
 *
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    internal class PoiParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
            SUBPRODUCTION_1 = 3001,
            SUBPRODUCTION_2 = 3002,
            SUBPRODUCTION_3 = 3003,
            SUBPRODUCTION_4 = 3004,
            SUBPRODUCTION_5 = 3005,
            SUBPRODUCTION_6 = 3006,
            SUBPRODUCTION_7 = 3007,
            SUBPRODUCTION_8 = 3008,
            SUBPRODUCTION_9 = 3009,
            SUBPRODUCTION_10 = 3010,
            SUBPRODUCTION_11 = 3011,
            SUBPRODUCTION_12 = 3012,
            SUBPRODUCTION_13 = 3013,
            SUBPRODUCTION_14 = 3014
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public PoiParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public PoiParser(TextReader input, PoiAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new PoiTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) PoiConstants.POI_SOURCE,
                                            "PoiSource");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STATEMENT_LIST, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.STATEMENT_LIST,
                                            "StatementList");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STATEMENT, 1, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.STATEMENT,
                                            "Statement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.EXPRESSION_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.DECLARATION_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.RETURN_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STRUCTUAL_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.EMPTY_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EXPRESSION_STATEMENT,
                                            "ExpressionStatement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_SEMICOLON, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.DECLARATION_STATEMENT,
                                            "DeclarationStatement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.DECLARATION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_SEMICOLON, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EMPTY_STATEMENT,
                                            "EmptyStatement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_SEMICOLON, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EXPRESSION,
                                            "Expression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.FUNCTION_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.FUNCTION_EXPRESSION,
                                            "FunctionExpression");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.FUNCTION_SIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.FUNCTION_PARAMETER, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_ARROW, 1, 1);
            alt.AddProduction((int) PoiConstants.FUNCTION_RETURN_VALUE, 1, 1);
            alt.AddProduction((int) PoiConstants.FUNCTION_BODY, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.FUNCTION_PARAMETER,
                                            "FunctionParameter");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PAIR_DECLARATION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.FUNCTION_RETURN_VALUE,
                                            "FunctionReturnValue");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PAIR_DECLARATION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.FUNCTION_BODY,
                                            "FunctionBody");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STATEMENT_BLOCK, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.STATEMENT_BLOCK,
                                            "StatementBlock");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACE, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_LIST, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PAIR_DECLARATION,
                                            "PairDeclaration");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACKET, 1, 1);
            alt.AddProduction((int) PoiConstants.PAIR_DECLARATION_CONTENT, 0, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACKET, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PAIR_DECLARATION_CONTENT,
                                            "PairDeclarationContent");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.VARIABLE_DECLARATION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ASSIGN_EXPRESSION,
                                            "AssignExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ARITHMETIC_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PAIR_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ASSIGN_EXPRESSION_T,
                                            "AssignExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_ADD_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SUB_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_MUL_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_DIV_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_MOD_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SHIFT_LEFT_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SHIFT_RIGHT_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_AND_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_OR_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_XOR_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.ASSIGN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PAIR_OR_FUNCTION_EXPRESSION,
                                            "PairOrFunctionExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PAIR_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PAIR_EXPRESSION,
                                            "PairExpression");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACKET, 1, 1);
            alt.AddProduction((int) PoiConstants.PAIR_EXPRESSION_CONTENT, 0, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACKET, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PAIR_EXPRESSION_CONTENT,
                                            "PairExpressionContent");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ARITHMETIC_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_3, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.FUNCTION_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_4, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ARITHMETIC_EXPRESSION,
                                            "ArithmeticExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.CONDITION_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CONDITION_EXPRESSION,
                                            "ConditionExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.LOGICAL_OR_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.CONDITION_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CONDITION_EXPRESSION_T,
                                            "ConditionExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_QUESTION_MARK, 1, 1);
            alt.AddProduction((int) PoiConstants.CONDITION_EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_COLON_MARK, 1, 1);
            alt.AddProduction((int) PoiConstants.CONDITION_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.CONDITION_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOGICAL_OR_EXPRESSION,
                                            "LogicalOrExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.LOGICAL_AND_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.LOGICAL_OR_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOGICAL_OR_EXPRESSION_T,
                                            "LogicalOrExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_LOGIC_OR, 1, 1);
            alt.AddProduction((int) PoiConstants.LOGICAL_OR_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOGICAL_AND_EXPRESSION,
                                            "LogicalAndExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.BIT_OR_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.LOGICAL_AND_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOGICAL_AND_EXPRESSION_T,
                                            "LogicalAndExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_LOGIC_AND, 1, 1);
            alt.AddProduction((int) PoiConstants.LOGICAL_AND_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BIT_OR_EXPRESSION,
                                            "BitOrExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.BIT_XOR_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.BIT_OR_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BIT_OR_EXPRESSION_T,
                                            "BitOrExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_OR, 1, 1);
            alt.AddProduction((int) PoiConstants.BIT_OR_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BIT_XOR_EXPRESSION,
                                            "BitXorExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.BIT_AND_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.BIT_XOR_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BIT_XOR_EXPRESSION_T,
                                            "BitXorExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_XOR, 1, 1);
            alt.AddProduction((int) PoiConstants.BIT_XOR_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BIT_AND_EXPRESSION,
                                            "BitAndExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.EQUALITY_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.BIT_AND_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BIT_AND_EXPRESSION_T,
                                            "BitAndExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_AND, 1, 1);
            alt.AddProduction((int) PoiConstants.BIT_AND_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EQUALITY_EXPRESSION,
                                            "EqualityExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.RELATIONAL_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.EQUALITY_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EQUALITY_EXPRESSION_T,
                                            "EqualityExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_UNEQUAL, 1, 1);
            alt.AddProduction((int) PoiConstants.RELATIONAL_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_EQUAL, 1, 1);
            alt.AddProduction((int) PoiConstants.RELATIONAL_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.RELATIONAL_EXPRESSION,
                                            "RelationalExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.SHIFT_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.RELATIONAL_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.RELATIONAL_EXPRESSION_T,
                                            "RelationalExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_LESS, 1, 1);
            alt.AddProduction((int) PoiConstants.SHIFT_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_GREATER, 1, 1);
            alt.AddProduction((int) PoiConstants.SHIFT_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_LESS_EQUAL, 1, 1);
            alt.AddProduction((int) PoiConstants.SHIFT_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_GREATER_EQUAL, 1, 1);
            alt.AddProduction((int) PoiConstants.SHIFT_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.SHIFT_EXPRESSION,
                                            "ShiftExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ADD_SUB_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.SHIFT_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.SHIFT_EXPRESSION_T,
                                            "ShiftExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SHIFT_LEFT, 1, 1);
            alt.AddProduction((int) PoiConstants.ADD_SUB_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SHIFT_RIGHT, 1, 1);
            alt.AddProduction((int) PoiConstants.ADD_SUB_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ADD_SUB_EXPRESSION,
                                            "AddSubExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.MUL_DIV_MOD_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.ADD_SUB_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ADD_SUB_EXPRESSION_T,
                                            "AddSubExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_ADD, 1, 1);
            alt.AddProduction((int) PoiConstants.ADD_SUB_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SUB, 1, 1);
            alt.AddProduction((int) PoiConstants.ADD_SUB_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.MUL_DIV_MOD_EXPRESSION,
                                            "MulDivModExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.MUL_DIV_MOD_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.MUL_DIV_MOD_EXPRESSION_T,
                                            "MulDivModExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_MUL, 1, 1);
            alt.AddProduction((int) PoiConstants.MUL_DIV_MOD_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_DIV, 1, 1);
            alt.AddProduction((int) PoiConstants.MUL_DIV_MOD_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_MODULAR, 1, 1);
            alt.AddProduction((int) PoiConstants.MUL_DIV_MOD_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.UNARY_EXPRESSION,
                                            "UnaryExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_ADD, 1, 1);
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_SUB, 1, 1);
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_LOGIC_NOT, 1, 1);
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_BIT_NOT, 1, 1);
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_INC, 1, 1);
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_DEC, 1, 1);
            alt.AddProduction((int) PoiConstants.UNARY_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BASIC_EXPRESSION,
                                            "BasicExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PRIMARY_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.FUNCTION_VARIABLE, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ARRAY_VARIABLE, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_5, 1, -1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BASIC_EXPRESSION_T,
                                            "BasicExpression_T");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_INC, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_DEC, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_DOT, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION, 1, 1);
            alt.AddProduction((int) PoiConstants.BASIC_EXPRESSION_T, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.FUNCTION_VARIABLE,
                                            "FunctionVariable");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PRIMITIVE_TYPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ARRAY_VARIABLE,
                                            "ArrayVariable");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PRIMARY_EXPRESSION,
                                            "PrimaryExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.LITERAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LITERAL,
                                            "Literal");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LITERAL_NUMERIC_INTEGER_DECIMAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LITERAL_NUMERIC_INTEGER_OCTAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LITERAL_NUMERIC_INTEGER_HEXADECIMAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LITERAL_NUMERIC_REAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LITERAL_STRING, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LITERAL_CHARACTER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.DECLARATION,
                                            "Declaration");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.VARIABLE_DECLARATION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.CLASS_DECLARATION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_DECLARATION,
                                            "VariableDeclaration");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.VARIABLE_TYPE, 1, 1);
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            alt.AddProduction((int) PoiConstants.VARIABLE_ACCESS, 0, 1);
            alt.AddProduction((int) PoiConstants.VARIABLE_INITIALIZER, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_TYPE,
                                            "VariableType");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.PRIMITIVE_TYPE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.CONTAINER_TYPE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.USER_TYPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.PRIMITIVE_TYPE,
                                            "PrimitiveType");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER8, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER8_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER16, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER16_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER32, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER32_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER64, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_INTEGER64_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER8, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER8_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER16, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER16_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER32, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER32_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER64, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_UINTEGER64_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_SINGLE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_SINGLE_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_EXTENDED, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_BOOLEAN, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_BOOLEAN_ALIAS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.PRIMITIVE_CHARACTER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.FUNCTION_TYPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CONTAINER_TYPE,
                                            "ContainerType");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STRING_CONTAINER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ARRAY_CONTAINER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.MAP_CONTAINER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.EVENT_CONTAINER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.USER_TYPE,
                                            "UserType");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_ACCESS,
                                            "VariableAccess");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COLON_MARK, 1, 1);
            alt.AddProduction((int) PoiConstants.VARIABLE_GETTER_SETTER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_GETTER_SETTER,
                                            "VariableGetterSetter");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.VARIABLE_GETTER, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_6, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.VARIABLE_SETTER, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_7, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_GETTER,
                                            "VariableGetter");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.DECLARATION_GETTER, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_BLOCK, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_SETTER,
                                            "VariableSetter");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.DECLARATION_SETTER, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_BLOCK, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.VARIABLE_INITIALIZER,
                                            "VariableInitializer");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.STRING_CONTAINER,
                                            "StringContainer");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CONTAINER_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ARRAY_CONTAINER,
                                            "ArrayContainer");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CONTAINER_ARRAY, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACKET, 1, 1);
            alt.AddProduction((int) PoiConstants.VARIABLE_TYPE, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_8, 1, -1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACKET, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.MAP_CONTAINER,
                                            "MapContainer");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CONTAINER_MAP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EVENT_CONTAINER,
                                            "EventContainer");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CONTAINER_EVENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CLASS_DECLARATION,
                                            "ClassDeclaration");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CLASS_TYPE, 1, 1);
            alt.AddProduction((int) PoiConstants.CLASS_NAME, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_9, 0, 1);
            alt.AddProduction((int) PoiConstants.CLASS_BODY, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CLASS_NAME,
                                            "ClassName");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.SUPER_CLASS_NAME,
                                            "SuperClassName");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CLASS_BODY,
                                            "ClassBody");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACE, 1, 1);
            alt.AddProduction((int) PoiConstants.CLASS_CONTENT, 0, -1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CLASS_CONTENT,
                                            "ClassContent");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.CLASS_ACCESS_MODIFIER, 1, 1);
            alt.AddProduction((int) PoiConstants.CLASS_VARIABLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CLASS_VARIABLE,
                                            "ClassVariable");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.DECLARATION_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.CLASS_ACCESS_MODIFIER,
                                            "ClassAccessModifier");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CLASS_PUBLIC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CLASS_PRIVATE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CLASS_PROTECTED, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.RETURN_STATEMENT,
                                            "ReturnStatement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.FUNCTION_RETURN, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_SEMICOLON, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.STRUCTUAL_STATEMENT,
                                            "StructualStatement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.BRANCH_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.LOOP_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BRANCH_STATEMENT,
                                            "BranchStatement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.BRANCH_IF, 1, 1);
            alt.AddProduction((int) PoiConstants.BRANCH_CONDITION, 1, 1);
            alt.AddProduction((int) PoiConstants.BRANCH_TARGET_STATEMENT, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_10, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BRANCH_CONDITION,
                                            "BranchCondition");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.BRANCH_TARGET_STATEMENT,
                                            "BranchTargetStatement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACE, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_LIST, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOOP_STATEMENT,
                                            "LoopStatement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LOOP_FOR, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_11, 0, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_12, 0, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_13, 0, 1);
            alt.AddProduction((int) PoiConstants.LOOP_TARGET_STATEMENT, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_14, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOOP_START_CONDITION,
                                            "LoopStartCondition");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 0, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOOP_INIT_STATEMENT,
                                            "LoopInitStatement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_LIST, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOOP_STEP_STATEMENT,
                                            "LoopStepStatement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_LIST, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOOP_TARGET_STATEMENT,
                                            "LoopTargetStatement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACE, 1, 1);
            alt.AddProduction((int) PoiConstants.STATEMENT_LIST, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.LOOP_STOP_CONDITION,
                                            "LoopStopCondition");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_1,
                                            "Subproduction1");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COMMA, 1, 1);
            alt.AddProduction((int) PoiConstants.PAIR_DECLARATION_CONTENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_2,
                                            "Subproduction2");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.OPERATOR_ASSIGN, 1, 1);
            alt.AddProduction((int) PoiConstants.PAIR_OR_FUNCTION_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_3,
                                            "Subproduction3");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COMMA, 1, 1);
            alt.AddProduction((int) PoiConstants.PAIR_EXPRESSION_CONTENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_4,
                                            "Subproduction4");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COMMA, 1, 1);
            alt.AddProduction((int) PoiConstants.PAIR_EXPRESSION_CONTENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_5,
                                            "Subproduction5");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_LEFT_BRACKET, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_RIGHT_BRACKET, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_6,
                                            "Subproduction6");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COMMA, 1, 1);
            alt.AddProduction((int) PoiConstants.VARIABLE_SETTER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_7,
                                            "Subproduction7");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COMMA, 1, 1);
            alt.AddProduction((int) PoiConstants.VARIABLE_GETTER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_8,
                                            "Subproduction8");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SYMBOL_COMMA, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_9,
                                            "Subproduction9");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.CLASS_EXTEND, 1, 1);
            alt.AddProduction((int) PoiConstants.SUPER_CLASS_NAME, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_10,
                                            "Subproduction10");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.BRANCH_ELSE, 1, 1);
            alt.AddProduction((int) PoiConstants.BRANCH_TARGET_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_11,
                                            "Subproduction11");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LOOP_INITIAL, 1, 1);
            alt.AddProduction((int) PoiConstants.LOOP_INIT_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_12,
                                            "Subproduction12");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LOOP_WHILE, 1, 1);
            alt.AddProduction((int) PoiConstants.LOOP_START_CONDITION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_13,
                                            "Subproduction13");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LOOP_STEP, 1, 1);
            alt.AddProduction((int) PoiConstants.LOOP_STEP_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_14,
                                            "Subproduction14");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LOOP_UNTIL, 1, 1);
            alt.AddProduction((int) PoiConstants.LOOP_STOP_CONDITION, 1, 1);
            alt.AddToken((int) PoiConstants.SYMBOL_SEMICOLON, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
