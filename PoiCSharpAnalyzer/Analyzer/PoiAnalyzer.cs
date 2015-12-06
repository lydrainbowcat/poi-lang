/*
 * PoiAnalyzer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 *
 *
 */

using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage {

    /**
     * <remarks>A class providing callback methods for the
     * parser.</remarks>
     */
    internal abstract class PoiAnalyzer : Analyzer {

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        static Node curptr;
        public override void Enter(Node node) {
            PoiInfo.AddValuePos(node, curptr, 2);
            curptr = node;
            switch (node.Id) {
            case (int) PoiConstants.SYMBOL_LEFT_PAREN:
                EnterSymbolLeftParen((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_RIGHT_PAREN:
                EnterSymbolRightParen((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_LEFT_BRACE:
                EnterSymbolLeftBrace((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_RIGHT_BRACE:
                EnterSymbolRightBrace((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_LEFT_BRACKET:
                EnterSymbolLeftBracket((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_RIGHT_BRACKET:
                EnterSymbolRightBracket((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_QUESTION_MARK:
                EnterSymbolQuestionMark((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_COLON_MARK:
                EnterSymbolColonMark((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_SEMICOLON:
                EnterSymbolSemicolon((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_COMMA:
                EnterSymbolComma((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_DOT:
                EnterSymbolDot((Token) node);
                break;
            case (int) PoiConstants.SYMBOL_ARROW:
                EnterSymbolArrow((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_ASSIGN:
                EnterOperatorAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_ADD_ASSIGN:
                EnterOperatorAddAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_SUB_ASSIGN:
                EnterOperatorSubAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_MUL_ASSIGN:
                EnterOperatorMulAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_DIV_ASSIGN:
                EnterOperatorDivAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_MOD_ASSIGN:
                EnterOperatorModAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_SHIFT_LEFT_ASSIGN:
                EnterOperatorShiftLeftAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_SHIFT_RIGHT_ASSIGN:
                EnterOperatorShiftRightAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_AND_ASSIGN:
                EnterOperatorBitAndAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_OR_ASSIGN:
                EnterOperatorBitOrAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_XOR_ASSIGN:
                EnterOperatorBitXorAssign((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_ADD:
                EnterOperatorAdd((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_SUB:
                EnterOperatorSub((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_MUL:
                EnterOperatorMul((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_DIV:
                EnterOperatorDiv((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_MODULAR:
                EnterOperatorModular((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_LESS:
                EnterOperatorLess((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_GREATER:
                EnterOperatorGreater((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_UNEQUAL:
                EnterOperatorUnequal((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_EQUAL:
                EnterOperatorEqual((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_LESS_EQUAL:
                EnterOperatorLessEqual((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_GREATER_EQUAL:
                EnterOperatorGreaterEqual((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_LOGIC_AND:
                EnterOperatorLogicAnd((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_LOGIC_OR:
                EnterOperatorLogicOr((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_LOGIC_NOT:
                EnterOperatorLogicNot((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_AND:
                EnterOperatorBitAnd((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_OR:
                EnterOperatorBitOr((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_NOT:
                EnterOperatorBitNot((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_BIT_XOR:
                EnterOperatorBitXor((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_INC:
                EnterOperatorInc((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_DEC:
                EnterOperatorDec((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_SHIFT_LEFT:
                EnterOperatorShiftLeft((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_SHIFT_RIGHT:
                EnterOperatorShiftRight((Token) node);
                break;
            case (int) PoiConstants.OPERATOR_CAST:
                EnterOperatorCast((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER8:
                EnterPrimitiveInteger8((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER8_ALIAS:
                EnterPrimitiveInteger8Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER16:
                EnterPrimitiveInteger16((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER16_ALIAS:
                EnterPrimitiveInteger16Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER32:
                EnterPrimitiveInteger32((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER32_ALIAS:
                EnterPrimitiveInteger32Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER64:
                EnterPrimitiveInteger64((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_INTEGER64_ALIAS:
                EnterPrimitiveInteger64Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER8:
                EnterPrimitiveUinteger8((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER8_ALIAS:
                EnterPrimitiveUinteger8Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER16:
                EnterPrimitiveUinteger16((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER16_ALIAS:
                EnterPrimitiveUinteger16Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER32:
                EnterPrimitiveUinteger32((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER32_ALIAS:
                EnterPrimitiveUinteger32Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER64:
                EnterPrimitiveUinteger64((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_UINTEGER64_ALIAS:
                EnterPrimitiveUinteger64Alias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_SINGLE:
                EnterPrimitiveSingle((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_SINGLE_ALIAS:
                EnterPrimitiveSingleAlias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_DOUBLE:
                EnterPrimitiveDouble((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_EXTENDED:
                EnterPrimitiveExtended((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_BOOLEAN:
                EnterPrimitiveBoolean((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_BOOLEAN_ALIAS:
                EnterPrimitiveBooleanAlias((Token) node);
                break;
            case (int) PoiConstants.PRIMITIVE_CHARACTER:
                EnterPrimitiveCharacter((Token) node);
                break;
            case (int) PoiConstants.CONTAINER_STRING:
                EnterContainerString((Token) node);
                break;
            case (int) PoiConstants.CONTAINER_ARRAY:
                EnterContainerArray((Token) node);
                break;
            case (int) PoiConstants.CONTAINER_MAP:
                EnterContainerMap((Token) node);
                break;
            case (int) PoiConstants.CONTAINER_EVENT:
                EnterContainerEvent((Token) node);
                break;
            case (int) PoiConstants.FUNCTION_TYPE:
                EnterFunctionType((Token) node);
                break;
            case (int) PoiConstants.FUNCTION_SIGN:
                EnterFunctionSign((Token) node);
                break;
            case (int) PoiConstants.FUNCTION_RETURN:
                EnterFunctionReturn((Token) node);
                break;
            case (int) PoiConstants.LOGIC_TRUE:
                EnterLogicTrue((Token) node);
                break;
            case (int) PoiConstants.LOGIC_FALSE:
                EnterLogicFalse((Token) node);
                break;
            case (int) PoiConstants.DECLARATION_GETTER:
                EnterDeclarationGetter((Token) node);
                break;
            case (int) PoiConstants.DECLARATION_SETTER:
                EnterDeclarationSetter((Token) node);
                break;
            case (int) PoiConstants.DECLARATION_ALLOC:
                EnterDeclarationAlloc((Token) node);
                break;
            case (int) PoiConstants.CLASS_TYPE:
                EnterClassType((Token) node);
                break;
            case (int) PoiConstants.CLASS_EXTEND:
                EnterClassExtend((Token) node);
                break;
            case (int) PoiConstants.CLASS_PUBLIC:
                EnterClassPublic((Token) node);
                break;
            case (int) PoiConstants.CLASS_PRIVATE:
                EnterClassPrivate((Token) node);
                break;
            case (int) PoiConstants.CLASS_PROTECTED:
                EnterClassProtected((Token) node);
                break;
            case (int) PoiConstants.BRANCH_IF:
                EnterBranchIf((Token) node);
                break;
            case (int) PoiConstants.BRANCH_ELSE:
                EnterBranchElse((Token) node);
                break;
            case (int) PoiConstants.LOOP_FOR:
                EnterLoopFor((Token) node);
                break;
            case (int) PoiConstants.LOOP_INITIAL:
                EnterLoopInitial((Token) node);
                break;
            case (int) PoiConstants.LOOP_WHILE:
                EnterLoopWhile((Token) node);
                break;
            case (int) PoiConstants.LOOP_STEP:
                EnterLoopStep((Token) node);
                break;
            case (int) PoiConstants.LOOP_UNTIL:
                EnterLoopUntil((Token) node);
                break;
            case (int) PoiConstants.LOOP_BREAK:
                EnterLoopBreak((Token) node);
                break;
            case (int) PoiConstants.LOOP_CONTINUE:
                EnterLoopContinue((Token) node);
                break;
            case (int) PoiConstants.LITERAL_BOOLEAN_TRUE:
                EnterLiteralBooleanTrue((Token) node);
                break;
            case (int) PoiConstants.LITERAL_BOOLEAN_FALSE:
                EnterLiteralBooleanFalse((Token) node);
                break;
            case (int) PoiConstants.LITERAL_NUMERIC_INTEGER_DECIMAL:
                EnterLiteralNumericIntegerDecimal((Token) node);
                break;
            case (int) PoiConstants.LITERAL_NUMERIC_INTEGER_OCTAL:
                EnterLiteralNumericIntegerOctal((Token) node);
                break;
            case (int) PoiConstants.LITERAL_NUMERIC_INTEGER_HEXADECIMAL:
                EnterLiteralNumericIntegerHexadecimal((Token) node);
                break;
            case (int) PoiConstants.LITERAL_NUMERIC_REAL:
                EnterLiteralNumericReal((Token) node);
                break;
            case (int) PoiConstants.LITERAL_STRING:
                EnterLiteralString((Token) node);
                break;
            case (int) PoiConstants.LITERAL_CHARACTER:
                EnterLiteralCharacter((Token) node);
                break;
            case (int) PoiConstants.IDENTIFIER:
                EnterIdentifier((Token) node);
                break;
            case (int) PoiConstants.ERRORTOKEN:
                EnterErrortoken((Token) node);
                break;
            case (int) PoiConstants.POI_SOURCE:
                EnterPoiSource((Production) node);
                break;
            case (int) PoiConstants.STATEMENT_LIST:
                EnterStatementList((Production) node);
                break;
            case (int) PoiConstants.STATEMENT:
                EnterStatement((Production) node);
                break;
            case (int) PoiConstants.EXPRESSION_STATEMENT:
                EnterExpressionStatement((Production) node);
                break;
            case (int) PoiConstants.DECLARATION_STATEMENT:
                EnterDeclarationStatement((Production) node);
                break;
            case (int) PoiConstants.EMPTY_STATEMENT:
                EnterEmptyStatement((Production) node);
                break;
            case (int) PoiConstants.EXPRESSION:
                EnterExpression((Production) node);
                break;
            case (int) PoiConstants.FUNCTION_EXPRESSION:
                EnterFunctionExpression((Production) node);
                break;
            case (int) PoiConstants.FUNCTION_PARAMETER:
                EnterFunctionParameter((Production) node);
                break;
            case (int) PoiConstants.FUNCTION_RETURN_VALUE:
                EnterFunctionReturnValue((Production) node);
                break;
            case (int) PoiConstants.FUNCTION_BODY:
                EnterFunctionBody((Production) node);
                break;
            case (int) PoiConstants.STATEMENT_BLOCK:
                EnterStatementBlock((Production) node);
                break;
            case (int) PoiConstants.PAIR_DECLARATION:
                EnterPairDeclaration((Production) node);
                break;
            case (int) PoiConstants.PAIR_DECLARATION_CONTENT:
                EnterPairDeclarationContent((Production) node);
                break;
            case (int) PoiConstants.ASSIGN_EXPRESSION:
                EnterAssignExpression((Production) node);
                break;
            case (int) PoiConstants.ASSIGN_EXPRESSION_T:
                EnterAssignExpressionT((Production) node);
                break;
            case (int) PoiConstants.PAIR_OR_FUNCTION_EXPRESSION:
                EnterPairOrFunctionExpression((Production) node);
                break;
            case (int) PoiConstants.PAIR_EXPRESSION:
                EnterPairExpression((Production) node);
                break;
            case (int) PoiConstants.PAIR_EXPRESSION_CONTENT:
                EnterPairExpressionContent((Production) node);
                break;
            case (int) PoiConstants.ARITHMETIC_EXPRESSION:
                EnterArithmeticExpression((Production) node);
                break;
            case (int) PoiConstants.CONDITION_EXPRESSION:
                EnterConditionExpression((Production) node);
                break;
            case (int) PoiConstants.CONDITION_EXPRESSION_T:
                EnterConditionExpressionT((Production) node);
                break;
            case (int) PoiConstants.LOGICAL_OR_EXPRESSION:
                EnterLogicalOrExpression((Production) node);
                break;
            case (int) PoiConstants.LOGICAL_OR_EXPRESSION_T:
                EnterLogicalOrExpressionT((Production) node);
                break;
            case (int) PoiConstants.LOGICAL_AND_EXPRESSION:
                EnterLogicalAndExpression((Production) node);
                break;
            case (int) PoiConstants.LOGICAL_AND_EXPRESSION_T:
                EnterLogicalAndExpressionT((Production) node);
                break;
            case (int) PoiConstants.BIT_OR_EXPRESSION:
                EnterBitOrExpression((Production) node);
                break;
            case (int) PoiConstants.BIT_OR_EXPRESSION_T:
                EnterBitOrExpressionT((Production) node);
                break;
            case (int) PoiConstants.BIT_XOR_EXPRESSION:
                EnterBitXorExpression((Production) node);
                break;
            case (int) PoiConstants.BIT_XOR_EXPRESSION_T:
                EnterBitXorExpressionT((Production) node);
                break;
            case (int) PoiConstants.BIT_AND_EXPRESSION:
                EnterBitAndExpression((Production) node);
                break;
            case (int) PoiConstants.BIT_AND_EXPRESSION_T:
                EnterBitAndExpressionT((Production) node);
                break;
            case (int) PoiConstants.EQUALITY_EXPRESSION:
                EnterEqualityExpression((Production) node);
                break;
            case (int) PoiConstants.EQUALITY_EXPRESSION_T:
                EnterEqualityExpressionT((Production) node);
                break;
            case (int) PoiConstants.RELATIONAL_EXPRESSION:
                EnterRelationalExpression((Production) node);
                break;
            case (int) PoiConstants.RELATIONAL_EXPRESSION_T:
                EnterRelationalExpressionT((Production) node);
                break;
            case (int) PoiConstants.SHIFT_EXPRESSION:
                EnterShiftExpression((Production) node);
                break;
            case (int) PoiConstants.SHIFT_EXPRESSION_T:
                EnterShiftExpressionT((Production) node);
                break;
            case (int) PoiConstants.ADD_SUB_EXPRESSION:
                EnterAddSubExpression((Production) node);
                break;
            case (int) PoiConstants.ADD_SUB_EXPRESSION_T:
                EnterAddSubExpressionT((Production) node);
                break;
            case (int) PoiConstants.MUL_DIV_MOD_EXPRESSION:
                EnterMulDivModExpression((Production) node);
                break;
            case (int) PoiConstants.MUL_DIV_MOD_EXPRESSION_T:
                EnterMulDivModExpressionT((Production) node);
                break;
            case (int) PoiConstants.UNARY_EXPRESSION:
                EnterUnaryExpression((Production) node);
                break;
            case (int) PoiConstants.BASIC_EXPRESSION:
                EnterBasicExpression((Production) node);
                break;
            case (int) PoiConstants.BASIC_EXPRESSION_T:
                EnterBasicExpressionT((Production) node);
                break;
            case (int) PoiConstants.FUNCTION_VARIABLE:
                EnterFunctionVariable((Production) node);
                break;
            case (int) PoiConstants.ARRAY_VARIABLE:
                EnterArrayVariable((Production) node);
                break;
            case (int) PoiConstants.PRIMARY_EXPRESSION:
                EnterPrimaryExpression((Production) node);
                break;
            case (int) PoiConstants.LITERAL:
                EnterLiteral((Production) node);
                break;
            case (int) PoiConstants.DECLARATION:
                EnterDeclaration((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_DECLARATION:
                EnterVariableDeclaration((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_TYPE:
                EnterVariableType((Production) node);
                break;
            case (int) PoiConstants.PRIMITIVE_TYPE:
                EnterPrimitiveType((Production) node);
                break;
            case (int) PoiConstants.CONTAINER_TYPE:
                EnterContainerType((Production) node);
                break;
            case (int) PoiConstants.USER_TYPE:
                EnterUserType((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_ACCESS:
                EnterVariableAccess((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_GETTER_SETTER:
                EnterVariableGetterSetter((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_GETTER:
                EnterVariableGetter((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_SETTER:
                EnterVariableSetter((Production) node);
                break;
            case (int) PoiConstants.VARIABLE_INITIALIZER:
                EnterVariableInitializer((Production) node);
                break;
            case (int) PoiConstants.STRING_CONTAINER:
                EnterStringContainer((Production) node);
                break;
            case (int) PoiConstants.ARRAY_CONTAINER:
                EnterArrayContainer((Production) node);
                break;
            case (int) PoiConstants.MAP_CONTAINER:
                EnterMapContainer((Production) node);
                break;
            case (int) PoiConstants.EVENT_CONTAINER:
                EnterEventContainer((Production) node);
                break;
            case (int) PoiConstants.CLASS_DECLARATION:
                EnterClassDeclaration((Production) node);
                break;
            case (int) PoiConstants.CLASS_NAME:
                EnterClassName((Production) node);
                break;
            case (int) PoiConstants.SUPER_CLASS_NAME:
                EnterSuperClassName((Production) node);
                break;
            case (int) PoiConstants.CLASS_BODY:
                EnterClassBody((Production) node);
                break;
            case (int) PoiConstants.CLASS_CONTENT:
                EnterClassContent((Production) node);
                break;
            case (int) PoiConstants.CLASS_VARIABLE:
                EnterClassVariable((Production) node);
                break;
            case (int) PoiConstants.CLASS_ACCESS_MODIFIER:
                EnterClassAccessModifier((Production) node);
                break;
            case (int) PoiConstants.RETURN_STATEMENT:
                EnterReturnStatement((Production) node);
                break;
            case (int) PoiConstants.STRUCTUAL_STATEMENT:
                EnterStructualStatement((Production) node);
                break;
            case (int) PoiConstants.BRANCH_STATEMENT:
                EnterBranchStatement((Production) node);
                break;
            case (int) PoiConstants.BRANCH_CONDITION:
                EnterBranchCondition((Production) node);
                break;
            case (int) PoiConstants.BRANCH_TARGET_STATEMENT:
                EnterBranchTargetStatement((Production) node);
                break;
            case (int) PoiConstants.LOOP_STATEMENT:
                EnterLoopStatement((Production) node);
                break;
            case (int) PoiConstants.LOOP_START_CONDITION:
                EnterLoopStartCondition((Production) node);
                break;
            case (int) PoiConstants.LOOP_INIT_STATEMENT:
                EnterLoopInitStatement((Production) node);
                break;
            case (int) PoiConstants.LOOP_STEP_STATEMENT:
                EnterLoopStepStatement((Production) node);
                break;
            case (int) PoiConstants.LOOP_TARGET_STATEMENT:
                EnterLoopTargetStatement((Production) node);
                break;
            case (int) PoiConstants.LOOP_STOP_CONDITION:
                EnterLoopStopCondition((Production) node);
                break;
            }
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public override Node Exit(Node node) {
            curptr = node.GetValue(2) as Node;
            switch (node.Id) {
            case (int) PoiConstants.SYMBOL_LEFT_PAREN:
                return ExitSymbolLeftParen((Token) node);
            case (int) PoiConstants.SYMBOL_RIGHT_PAREN:
                return ExitSymbolRightParen((Token) node);
            case (int) PoiConstants.SYMBOL_LEFT_BRACE:
                return ExitSymbolLeftBrace((Token) node);
            case (int) PoiConstants.SYMBOL_RIGHT_BRACE:
                return ExitSymbolRightBrace((Token) node);
            case (int) PoiConstants.SYMBOL_LEFT_BRACKET:
                return ExitSymbolLeftBracket((Token) node);
            case (int) PoiConstants.SYMBOL_RIGHT_BRACKET:
                return ExitSymbolRightBracket((Token) node);
            case (int) PoiConstants.SYMBOL_QUESTION_MARK:
                return ExitSymbolQuestionMark((Token) node);
            case (int) PoiConstants.SYMBOL_COLON_MARK:
                return ExitSymbolColonMark((Token) node);
            case (int) PoiConstants.SYMBOL_SEMICOLON:
                return ExitSymbolSemicolon((Token) node);
            case (int) PoiConstants.SYMBOL_COMMA:
                return ExitSymbolComma((Token) node);
            case (int) PoiConstants.SYMBOL_DOT:
                return ExitSymbolDot((Token) node);
            case (int) PoiConstants.SYMBOL_ARROW:
                return ExitSymbolArrow((Token) node);
            case (int) PoiConstants.OPERATOR_ASSIGN:
                return ExitOperatorAssign((Token) node);
            case (int) PoiConstants.OPERATOR_ADD_ASSIGN:
                return ExitOperatorAddAssign((Token) node);
            case (int) PoiConstants.OPERATOR_SUB_ASSIGN:
                return ExitOperatorSubAssign((Token) node);
            case (int) PoiConstants.OPERATOR_MUL_ASSIGN:
                return ExitOperatorMulAssign((Token) node);
            case (int) PoiConstants.OPERATOR_DIV_ASSIGN:
                return ExitOperatorDivAssign((Token) node);
            case (int) PoiConstants.OPERATOR_MOD_ASSIGN:
                return ExitOperatorModAssign((Token) node);
            case (int) PoiConstants.OPERATOR_SHIFT_LEFT_ASSIGN:
                return ExitOperatorShiftLeftAssign((Token) node);
            case (int) PoiConstants.OPERATOR_SHIFT_RIGHT_ASSIGN:
                return ExitOperatorShiftRightAssign((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_AND_ASSIGN:
                return ExitOperatorBitAndAssign((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_OR_ASSIGN:
                return ExitOperatorBitOrAssign((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_XOR_ASSIGN:
                return ExitOperatorBitXorAssign((Token) node);
            case (int) PoiConstants.OPERATOR_ADD:
                return ExitOperatorAdd((Token) node);
            case (int) PoiConstants.OPERATOR_SUB:
                return ExitOperatorSub((Token) node);
            case (int) PoiConstants.OPERATOR_MUL:
                return ExitOperatorMul((Token) node);
            case (int) PoiConstants.OPERATOR_DIV:
                return ExitOperatorDiv((Token) node);
            case (int) PoiConstants.OPERATOR_MODULAR:
                return ExitOperatorModular((Token) node);
            case (int) PoiConstants.OPERATOR_LESS:
                return ExitOperatorLess((Token) node);
            case (int) PoiConstants.OPERATOR_GREATER:
                return ExitOperatorGreater((Token) node);
            case (int) PoiConstants.OPERATOR_UNEQUAL:
                return ExitOperatorUnequal((Token) node);
            case (int) PoiConstants.OPERATOR_EQUAL:
                return ExitOperatorEqual((Token) node);
            case (int) PoiConstants.OPERATOR_LESS_EQUAL:
                return ExitOperatorLessEqual((Token) node);
            case (int) PoiConstants.OPERATOR_GREATER_EQUAL:
                return ExitOperatorGreaterEqual((Token) node);
            case (int) PoiConstants.OPERATOR_LOGIC_AND:
                return ExitOperatorLogicAnd((Token) node);
            case (int) PoiConstants.OPERATOR_LOGIC_OR:
                return ExitOperatorLogicOr((Token) node);
            case (int) PoiConstants.OPERATOR_LOGIC_NOT:
                return ExitOperatorLogicNot((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_AND:
                return ExitOperatorBitAnd((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_OR:
                return ExitOperatorBitOr((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_NOT:
                return ExitOperatorBitNot((Token) node);
            case (int) PoiConstants.OPERATOR_BIT_XOR:
                return ExitOperatorBitXor((Token) node);
            case (int) PoiConstants.OPERATOR_INC:
                return ExitOperatorInc((Token) node);
            case (int) PoiConstants.OPERATOR_DEC:
                return ExitOperatorDec((Token) node);
            case (int) PoiConstants.OPERATOR_SHIFT_LEFT:
                return ExitOperatorShiftLeft((Token) node);
            case (int) PoiConstants.OPERATOR_SHIFT_RIGHT:
                return ExitOperatorShiftRight((Token) node);
            case (int) PoiConstants.OPERATOR_CAST:
                return ExitOperatorCast((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER8:
                return ExitPrimitiveInteger8((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER8_ALIAS:
                return ExitPrimitiveInteger8Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER16:
                return ExitPrimitiveInteger16((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER16_ALIAS:
                return ExitPrimitiveInteger16Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER32:
                return ExitPrimitiveInteger32((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER32_ALIAS:
                return ExitPrimitiveInteger32Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER64:
                return ExitPrimitiveInteger64((Token) node);
            case (int) PoiConstants.PRIMITIVE_INTEGER64_ALIAS:
                return ExitPrimitiveInteger64Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER8:
                return ExitPrimitiveUinteger8((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER8_ALIAS:
                return ExitPrimitiveUinteger8Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER16:
                return ExitPrimitiveUinteger16((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER16_ALIAS:
                return ExitPrimitiveUinteger16Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER32:
                return ExitPrimitiveUinteger32((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER32_ALIAS:
                return ExitPrimitiveUinteger32Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER64:
                return ExitPrimitiveUinteger64((Token) node);
            case (int) PoiConstants.PRIMITIVE_UINTEGER64_ALIAS:
                return ExitPrimitiveUinteger64Alias((Token) node);
            case (int) PoiConstants.PRIMITIVE_SINGLE:
                return ExitPrimitiveSingle((Token) node);
            case (int) PoiConstants.PRIMITIVE_SINGLE_ALIAS:
                return ExitPrimitiveSingleAlias((Token) node);
            case (int) PoiConstants.PRIMITIVE_DOUBLE:
                return ExitPrimitiveDouble((Token) node);
            case (int) PoiConstants.PRIMITIVE_EXTENDED:
                return ExitPrimitiveExtended((Token) node);
            case (int) PoiConstants.PRIMITIVE_BOOLEAN:
                return ExitPrimitiveBoolean((Token) node);
            case (int) PoiConstants.PRIMITIVE_BOOLEAN_ALIAS:
                return ExitPrimitiveBooleanAlias((Token) node);
            case (int) PoiConstants.PRIMITIVE_CHARACTER:
                return ExitPrimitiveCharacter((Token) node);
            case (int) PoiConstants.CONTAINER_STRING:
                return ExitContainerString((Token) node);
            case (int) PoiConstants.CONTAINER_ARRAY:
                return ExitContainerArray((Token) node);
            case (int) PoiConstants.CONTAINER_MAP:
                return ExitContainerMap((Token) node);
            case (int) PoiConstants.CONTAINER_EVENT:
                return ExitContainerEvent((Token) node);
            case (int) PoiConstants.FUNCTION_TYPE:
                return ExitFunctionType((Token) node);
            case (int) PoiConstants.FUNCTION_SIGN:
                return ExitFunctionSign((Token) node);
            case (int) PoiConstants.FUNCTION_RETURN:
                return ExitFunctionReturn((Token) node);
            case (int) PoiConstants.LOGIC_TRUE:
                return ExitLogicTrue((Token) node);
            case (int) PoiConstants.LOGIC_FALSE:
                return ExitLogicFalse((Token) node);
            case (int) PoiConstants.DECLARATION_GETTER:
                return ExitDeclarationGetter((Token) node);
            case (int) PoiConstants.DECLARATION_SETTER:
                return ExitDeclarationSetter((Token) node);
            case (int) PoiConstants.DECLARATION_ALLOC:
                return ExitDeclarationAlloc((Token) node);
            case (int) PoiConstants.CLASS_TYPE:
                return ExitClassType((Token) node);
            case (int) PoiConstants.CLASS_EXTEND:
                return ExitClassExtend((Token) node);
            case (int) PoiConstants.CLASS_PUBLIC:
                return ExitClassPublic((Token) node);
            case (int) PoiConstants.CLASS_PRIVATE:
                return ExitClassPrivate((Token) node);
            case (int) PoiConstants.CLASS_PROTECTED:
                return ExitClassProtected((Token) node);
            case (int) PoiConstants.BRANCH_IF:
                return ExitBranchIf((Token) node);
            case (int) PoiConstants.BRANCH_ELSE:
                return ExitBranchElse((Token) node);
            case (int) PoiConstants.LOOP_FOR:
                return ExitLoopFor((Token) node);
            case (int) PoiConstants.LOOP_INITIAL:
                return ExitLoopInitial((Token) node);
            case (int) PoiConstants.LOOP_WHILE:
                return ExitLoopWhile((Token) node);
            case (int) PoiConstants.LOOP_STEP:
                return ExitLoopStep((Token) node);
            case (int) PoiConstants.LOOP_UNTIL:
                return ExitLoopUntil((Token) node);
            case (int) PoiConstants.LOOP_BREAK:
                return ExitLoopBreak((Token) node);
            case (int) PoiConstants.LOOP_CONTINUE:
                return ExitLoopContinue((Token) node);
            case (int) PoiConstants.LITERAL_BOOLEAN_TRUE:
                return ExitLiteralBooleanTrue((Token) node);
            case (int) PoiConstants.LITERAL_BOOLEAN_FALSE:
                return ExitLiteralBooleanFalse((Token) node);
            case (int) PoiConstants.LITERAL_NUMERIC_INTEGER_DECIMAL:
                return ExitLiteralNumericIntegerDecimal((Token) node);
            case (int) PoiConstants.LITERAL_NUMERIC_INTEGER_OCTAL:
                return ExitLiteralNumericIntegerOctal((Token) node);
            case (int) PoiConstants.LITERAL_NUMERIC_INTEGER_HEXADECIMAL:
                return ExitLiteralNumericIntegerHexadecimal((Token) node);
            case (int) PoiConstants.LITERAL_NUMERIC_REAL:
                return ExitLiteralNumericReal((Token) node);
            case (int) PoiConstants.LITERAL_STRING:
                return ExitLiteralString((Token) node);
            case (int) PoiConstants.LITERAL_CHARACTER:
                return ExitLiteralCharacter((Token) node);
            case (int) PoiConstants.IDENTIFIER:
                return ExitIdentifier((Token) node);
            case (int) PoiConstants.ERRORTOKEN:
                return ExitErrortoken((Token) node);
            case (int) PoiConstants.POI_SOURCE:
                return ExitPoiSource((Production) node);
            case (int) PoiConstants.STATEMENT_LIST:
                return ExitStatementList((Production) node);
            case (int) PoiConstants.STATEMENT:
                return ExitStatement((Production) node);
            case (int) PoiConstants.EXPRESSION_STATEMENT:
                return ExitExpressionStatement((Production) node);
            case (int) PoiConstants.DECLARATION_STATEMENT:
                return ExitDeclarationStatement((Production) node);
            case (int) PoiConstants.EMPTY_STATEMENT:
                return ExitEmptyStatement((Production) node);
            case (int) PoiConstants.EXPRESSION:
                return ExitExpression((Production) node);
            case (int) PoiConstants.FUNCTION_EXPRESSION:
                return ExitFunctionExpression((Production) node);
            case (int) PoiConstants.FUNCTION_PARAMETER:
                return ExitFunctionParameter((Production) node);
            case (int) PoiConstants.FUNCTION_RETURN_VALUE:
                return ExitFunctionReturnValue((Production) node);
            case (int) PoiConstants.FUNCTION_BODY:
                return ExitFunctionBody((Production) node);
            case (int) PoiConstants.STATEMENT_BLOCK:
                return ExitStatementBlock((Production) node);
            case (int) PoiConstants.PAIR_DECLARATION:
                return ExitPairDeclaration((Production) node);
            case (int) PoiConstants.PAIR_DECLARATION_CONTENT:
                return ExitPairDeclarationContent((Production) node);
            case (int) PoiConstants.ASSIGN_EXPRESSION:
                return ExitAssignExpression((Production) node);
            case (int) PoiConstants.ASSIGN_EXPRESSION_T:
                return ExitAssignExpressionT((Production) node);
            case (int) PoiConstants.PAIR_OR_FUNCTION_EXPRESSION:
                return ExitPairOrFunctionExpression((Production) node);
            case (int) PoiConstants.PAIR_EXPRESSION:
                return ExitPairExpression((Production) node);
            case (int) PoiConstants.PAIR_EXPRESSION_CONTENT:
                return ExitPairExpressionContent((Production) node);
            case (int) PoiConstants.ARITHMETIC_EXPRESSION:
                return ExitArithmeticExpression((Production) node);
            case (int) PoiConstants.CONDITION_EXPRESSION:
                return ExitConditionExpression((Production) node);
            case (int) PoiConstants.CONDITION_EXPRESSION_T:
                return ExitConditionExpressionT((Production) node);
            case (int) PoiConstants.LOGICAL_OR_EXPRESSION:
                return ExitLogicalOrExpression((Production) node);
            case (int) PoiConstants.LOGICAL_OR_EXPRESSION_T:
                return ExitLogicalOrExpressionT((Production) node);
            case (int) PoiConstants.LOGICAL_AND_EXPRESSION:
                return ExitLogicalAndExpression((Production) node);
            case (int) PoiConstants.LOGICAL_AND_EXPRESSION_T:
                return ExitLogicalAndExpressionT((Production) node);
            case (int) PoiConstants.BIT_OR_EXPRESSION:
                return ExitBitOrExpression((Production) node);
            case (int) PoiConstants.BIT_OR_EXPRESSION_T:
                return ExitBitOrExpressionT((Production) node);
            case (int) PoiConstants.BIT_XOR_EXPRESSION:
                return ExitBitXorExpression((Production) node);
            case (int) PoiConstants.BIT_XOR_EXPRESSION_T:
                return ExitBitXorExpressionT((Production) node);
            case (int) PoiConstants.BIT_AND_EXPRESSION:
                return ExitBitAndExpression((Production) node);
            case (int) PoiConstants.BIT_AND_EXPRESSION_T:
                return ExitBitAndExpressionT((Production) node);
            case (int) PoiConstants.EQUALITY_EXPRESSION:
                return ExitEqualityExpression((Production) node);
            case (int) PoiConstants.EQUALITY_EXPRESSION_T:
                return ExitEqualityExpressionT((Production) node);
            case (int) PoiConstants.RELATIONAL_EXPRESSION:
                return ExitRelationalExpression((Production) node);
            case (int) PoiConstants.RELATIONAL_EXPRESSION_T:
                return ExitRelationalExpressionT((Production) node);
            case (int) PoiConstants.SHIFT_EXPRESSION:
                return ExitShiftExpression((Production) node);
            case (int) PoiConstants.SHIFT_EXPRESSION_T:
                return ExitShiftExpressionT((Production) node);
            case (int) PoiConstants.ADD_SUB_EXPRESSION:
                return ExitAddSubExpression((Production) node);
            case (int) PoiConstants.ADD_SUB_EXPRESSION_T:
                return ExitAddSubExpressionT((Production) node);
            case (int) PoiConstants.MUL_DIV_MOD_EXPRESSION:
                return ExitMulDivModExpression((Production) node);
            case (int) PoiConstants.MUL_DIV_MOD_EXPRESSION_T:
                return ExitMulDivModExpressionT((Production) node);
            case (int) PoiConstants.UNARY_EXPRESSION:
                return ExitUnaryExpression((Production) node);
            case (int) PoiConstants.BASIC_EXPRESSION:
                return ExitBasicExpression((Production) node);
            case (int) PoiConstants.BASIC_EXPRESSION_T:
                return ExitBasicExpressionT((Production) node);
            case (int) PoiConstants.FUNCTION_VARIABLE:
                return ExitFunctionVariable((Production) node);
            case (int) PoiConstants.ARRAY_VARIABLE:
                return ExitArrayVariable((Production) node);
            case (int) PoiConstants.PRIMARY_EXPRESSION:
                return ExitPrimaryExpression((Production) node);
            case (int) PoiConstants.LITERAL:
                return ExitLiteral((Production) node);
            case (int) PoiConstants.DECLARATION:
                return ExitDeclaration((Production) node);
            case (int) PoiConstants.VARIABLE_DECLARATION:
                return ExitVariableDeclaration((Production) node);
            case (int) PoiConstants.VARIABLE_TYPE:
                return ExitVariableType((Production) node);
            case (int) PoiConstants.PRIMITIVE_TYPE:
                return ExitPrimitiveType((Production) node);
            case (int) PoiConstants.CONTAINER_TYPE:
                return ExitContainerType((Production) node);
            case (int) PoiConstants.USER_TYPE:
                return ExitUserType((Production) node);
            case (int) PoiConstants.VARIABLE_ACCESS:
                return ExitVariableAccess((Production) node);
            case (int) PoiConstants.VARIABLE_GETTER_SETTER:
                return ExitVariableGetterSetter((Production) node);
            case (int) PoiConstants.VARIABLE_GETTER:
                return ExitVariableGetter((Production) node);
            case (int) PoiConstants.VARIABLE_SETTER:
                return ExitVariableSetter((Production) node);
            case (int) PoiConstants.VARIABLE_INITIALIZER:
                return ExitVariableInitializer((Production) node);
            case (int) PoiConstants.STRING_CONTAINER:
                return ExitStringContainer((Production) node);
            case (int) PoiConstants.ARRAY_CONTAINER:
                return ExitArrayContainer((Production) node);
            case (int) PoiConstants.MAP_CONTAINER:
                return ExitMapContainer((Production) node);
            case (int) PoiConstants.EVENT_CONTAINER:
                return ExitEventContainer((Production) node);
            case (int) PoiConstants.CLASS_DECLARATION:
                return ExitClassDeclaration((Production) node);
            case (int) PoiConstants.CLASS_NAME:
                return ExitClassName((Production) node);
            case (int) PoiConstants.SUPER_CLASS_NAME:
                return ExitSuperClassName((Production) node);
            case (int) PoiConstants.CLASS_BODY:
                return ExitClassBody((Production) node);
            case (int) PoiConstants.CLASS_CONTENT:
                return ExitClassContent((Production) node);
            case (int) PoiConstants.CLASS_VARIABLE:
                return ExitClassVariable((Production) node);
            case (int) PoiConstants.CLASS_ACCESS_MODIFIER:
                return ExitClassAccessModifier((Production) node);
            case (int) PoiConstants.RETURN_STATEMENT:
                return ExitReturnStatement((Production) node);
            case (int) PoiConstants.STRUCTUAL_STATEMENT:
                return ExitStructualStatement((Production) node);
            case (int) PoiConstants.BRANCH_STATEMENT:
                return ExitBranchStatement((Production) node);
            case (int) PoiConstants.BRANCH_CONDITION:
                return ExitBranchCondition((Production) node);
            case (int) PoiConstants.BRANCH_TARGET_STATEMENT:
                return ExitBranchTargetStatement((Production) node);
            case (int) PoiConstants.LOOP_STATEMENT:
                return ExitLoopStatement((Production) node);
            case (int) PoiConstants.LOOP_START_CONDITION:
                return ExitLoopStartCondition((Production) node);
            case (int) PoiConstants.LOOP_INIT_STATEMENT:
                return ExitLoopInitStatement((Production) node);
            case (int) PoiConstants.LOOP_STEP_STATEMENT:
                return ExitLoopStepStatement((Production) node);
            case (int) PoiConstants.LOOP_TARGET_STATEMENT:
                return ExitLoopTargetStatement((Production) node);
            case (int) PoiConstants.LOOP_STOP_CONDITION:
                return ExitLoopStopCondition((Production) node);
            }
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public override void Child(Production node, Node child) {
            switch (node.Id) {
            case (int) PoiConstants.POI_SOURCE:
                ChildPoiSource(node, child);
                break;
            case (int) PoiConstants.STATEMENT_LIST:
                ChildStatementList(node, child);
                break;
            case (int) PoiConstants.STATEMENT:
                ChildStatement(node, child);
                break;
            case (int) PoiConstants.EXPRESSION_STATEMENT:
                ChildExpressionStatement(node, child);
                break;
            case (int) PoiConstants.DECLARATION_STATEMENT:
                ChildDeclarationStatement(node, child);
                break;
            case (int) PoiConstants.EMPTY_STATEMENT:
                ChildEmptyStatement(node, child);
                break;
            case (int) PoiConstants.EXPRESSION:
                ChildExpression(node, child);
                break;
            case (int) PoiConstants.FUNCTION_EXPRESSION:
                ChildFunctionExpression(node, child);
                break;
            case (int) PoiConstants.FUNCTION_PARAMETER:
                ChildFunctionParameter(node, child);
                break;
            case (int) PoiConstants.FUNCTION_RETURN_VALUE:
                ChildFunctionReturnValue(node, child);
                break;
            case (int) PoiConstants.FUNCTION_BODY:
                ChildFunctionBody(node, child);
                break;
            case (int) PoiConstants.STATEMENT_BLOCK:
                ChildStatementBlock(node, child);
                break;
            case (int) PoiConstants.PAIR_DECLARATION:
                ChildPairDeclaration(node, child);
                break;
            case (int) PoiConstants.PAIR_DECLARATION_CONTENT:
                ChildPairDeclarationContent(node, child);
                break;
            case (int) PoiConstants.ASSIGN_EXPRESSION:
                ChildAssignExpression(node, child);
                break;
            case (int) PoiConstants.ASSIGN_EXPRESSION_T:
                ChildAssignExpressionT(node, child);
                break;
            case (int) PoiConstants.PAIR_OR_FUNCTION_EXPRESSION:
                ChildPairOrFunctionExpression(node, child);
                break;
            case (int) PoiConstants.PAIR_EXPRESSION:
                ChildPairExpression(node, child);
                break;
            case (int) PoiConstants.PAIR_EXPRESSION_CONTENT:
                ChildPairExpressionContent(node, child);
                break;
            case (int) PoiConstants.ARITHMETIC_EXPRESSION:
                ChildArithmeticExpression(node, child);
                break;
            case (int) PoiConstants.CONDITION_EXPRESSION:
                ChildConditionExpression(node, child);
                break;
            case (int) PoiConstants.CONDITION_EXPRESSION_T:
                ChildConditionExpressionT(node, child);
                break;
            case (int) PoiConstants.LOGICAL_OR_EXPRESSION:
                ChildLogicalOrExpression(node, child);
                break;
            case (int) PoiConstants.LOGICAL_OR_EXPRESSION_T:
                ChildLogicalOrExpressionT(node, child);
                break;
            case (int) PoiConstants.LOGICAL_AND_EXPRESSION:
                ChildLogicalAndExpression(node, child);
                break;
            case (int) PoiConstants.LOGICAL_AND_EXPRESSION_T:
                ChildLogicalAndExpressionT(node, child);
                break;
            case (int) PoiConstants.BIT_OR_EXPRESSION:
                ChildBitOrExpression(node, child);
                break;
            case (int) PoiConstants.BIT_OR_EXPRESSION_T:
                ChildBitOrExpressionT(node, child);
                break;
            case (int) PoiConstants.BIT_XOR_EXPRESSION:
                ChildBitXorExpression(node, child);
                break;
            case (int) PoiConstants.BIT_XOR_EXPRESSION_T:
                ChildBitXorExpressionT(node, child);
                break;
            case (int) PoiConstants.BIT_AND_EXPRESSION:
                ChildBitAndExpression(node, child);
                break;
            case (int) PoiConstants.BIT_AND_EXPRESSION_T:
                ChildBitAndExpressionT(node, child);
                break;
            case (int) PoiConstants.EQUALITY_EXPRESSION:
                ChildEqualityExpression(node, child);
                break;
            case (int) PoiConstants.EQUALITY_EXPRESSION_T:
                ChildEqualityExpressionT(node, child);
                break;
            case (int) PoiConstants.RELATIONAL_EXPRESSION:
                ChildRelationalExpression(node, child);
                break;
            case (int) PoiConstants.RELATIONAL_EXPRESSION_T:
                ChildRelationalExpressionT(node, child);
                break;
            case (int) PoiConstants.SHIFT_EXPRESSION:
                ChildShiftExpression(node, child);
                break;
            case (int) PoiConstants.SHIFT_EXPRESSION_T:
                ChildShiftExpressionT(node, child);
                break;
            case (int) PoiConstants.ADD_SUB_EXPRESSION:
                ChildAddSubExpression(node, child);
                break;
            case (int) PoiConstants.ADD_SUB_EXPRESSION_T:
                ChildAddSubExpressionT(node, child);
                break;
            case (int) PoiConstants.MUL_DIV_MOD_EXPRESSION:
                ChildMulDivModExpression(node, child);
                break;
            case (int) PoiConstants.MUL_DIV_MOD_EXPRESSION_T:
                ChildMulDivModExpressionT(node, child);
                break;
            case (int) PoiConstants.UNARY_EXPRESSION:
                ChildUnaryExpression(node, child);
                break;
            case (int) PoiConstants.BASIC_EXPRESSION:
                ChildBasicExpression(node, child);
                break;
            case (int) PoiConstants.BASIC_EXPRESSION_T:
                ChildBasicExpressionT(node, child);
                break;
            case (int) PoiConstants.FUNCTION_VARIABLE:
                ChildFunctionVariable(node, child);
                break;
            case (int) PoiConstants.ARRAY_VARIABLE:
                ChildArrayVariable(node, child);
                break;
            case (int) PoiConstants.PRIMARY_EXPRESSION:
                ChildPrimaryExpression(node, child);
                break;
            case (int) PoiConstants.LITERAL:
                ChildLiteral(node, child);
                break;
            case (int) PoiConstants.DECLARATION:
                ChildDeclaration(node, child);
                break;
            case (int) PoiConstants.VARIABLE_DECLARATION:
                ChildVariableDeclaration(node, child);
                break;
            case (int) PoiConstants.VARIABLE_TYPE:
                ChildVariableType(node, child);
                break;
            case (int) PoiConstants.PRIMITIVE_TYPE:
                ChildPrimitiveType(node, child);
                break;
            case (int) PoiConstants.CONTAINER_TYPE:
                ChildContainerType(node, child);
                break;
            case (int) PoiConstants.USER_TYPE:
                ChildUserType(node, child);
                break;
            case (int) PoiConstants.VARIABLE_ACCESS:
                ChildVariableAccess(node, child);
                break;
            case (int) PoiConstants.VARIABLE_GETTER_SETTER:
                ChildVariableGetterSetter(node, child);
                break;
            case (int) PoiConstants.VARIABLE_GETTER:
                ChildVariableGetter(node, child);
                break;
            case (int) PoiConstants.VARIABLE_SETTER:
                ChildVariableSetter(node, child);
                break;
            case (int) PoiConstants.VARIABLE_INITIALIZER:
                ChildVariableInitializer(node, child);
                break;
            case (int) PoiConstants.STRING_CONTAINER:
                ChildStringContainer(node, child);
                break;
            case (int) PoiConstants.ARRAY_CONTAINER:
                ChildArrayContainer(node, child);
                break;
            case (int) PoiConstants.MAP_CONTAINER:
                ChildMapContainer(node, child);
                break;
            case (int) PoiConstants.EVENT_CONTAINER:
                ChildEventContainer(node, child);
                break;
            case (int) PoiConstants.CLASS_DECLARATION:
                ChildClassDeclaration(node, child);
                break;
            case (int) PoiConstants.CLASS_NAME:
                ChildClassName(node, child);
                break;
            case (int) PoiConstants.SUPER_CLASS_NAME:
                ChildSuperClassName(node, child);
                break;
            case (int) PoiConstants.CLASS_BODY:
                ChildClassBody(node, child);
                break;
            case (int) PoiConstants.CLASS_CONTENT:
                ChildClassContent(node, child);
                break;
            case (int) PoiConstants.CLASS_VARIABLE:
                ChildClassVariable(node, child);
                break;
            case (int) PoiConstants.CLASS_ACCESS_MODIFIER:
                ChildClassAccessModifier(node, child);
                break;
            case (int) PoiConstants.RETURN_STATEMENT:
                ChildReturnStatement(node, child);
                break;
            case (int) PoiConstants.STRUCTUAL_STATEMENT:
                ChildStructualStatement(node, child);
                break;
            case (int) PoiConstants.BRANCH_STATEMENT:
                ChildBranchStatement(node, child);
                break;
            case (int) PoiConstants.BRANCH_CONDITION:
                ChildBranchCondition(node, child);
                break;
            case (int) PoiConstants.BRANCH_TARGET_STATEMENT:
                ChildBranchTargetStatement(node, child);
                break;
            case (int) PoiConstants.LOOP_STATEMENT:
                ChildLoopStatement(node, child);
                break;
            case (int) PoiConstants.LOOP_START_CONDITION:
                ChildLoopStartCondition(node, child);
                break;
            case (int) PoiConstants.LOOP_INIT_STATEMENT:
                ChildLoopInitStatement(node, child);
                break;
            case (int) PoiConstants.LOOP_STEP_STATEMENT:
                ChildLoopStepStatement(node, child);
                break;
            case (int) PoiConstants.LOOP_TARGET_STATEMENT:
                ChildLoopTargetStatement(node, child);
                break;
            case (int) PoiConstants.LOOP_STOP_CONDITION:
                ChildLoopStopCondition(node, child);
                break;
            }
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolLeftParen(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolLeftParen(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolRightParen(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolRightParen(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolLeftBrace(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolLeftBrace(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolRightBrace(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolRightBrace(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolLeftBracket(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolLeftBracket(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolRightBracket(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolRightBracket(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolQuestionMark(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolQuestionMark(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolColonMark(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolColonMark(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolSemicolon(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolSemicolon(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolComma(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolComma(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolDot(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolDot(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSymbolArrow(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSymbolArrow(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorAddAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorAddAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorSubAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorSubAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorMulAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorMulAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorDivAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorDivAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorModAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorModAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorShiftLeftAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorShiftLeftAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorShiftRightAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorShiftRightAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitAndAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitAndAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitOrAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitOrAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitXorAssign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitXorAssign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorAdd(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorAdd(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorSub(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorSub(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorMul(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorMul(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorDiv(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorDiv(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorModular(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorModular(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorLess(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorLess(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorGreater(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorGreater(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorUnequal(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorUnequal(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorEqual(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorEqual(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorLessEqual(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorLessEqual(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorGreaterEqual(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorGreaterEqual(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorLogicAnd(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorLogicAnd(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorLogicOr(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorLogicOr(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorLogicNot(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorLogicNot(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitAnd(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitAnd(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitOr(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitOr(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitNot(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitNot(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorBitXor(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorBitXor(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorInc(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorInc(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorDec(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorDec(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorShiftLeft(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorShiftLeft(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorShiftRight(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorShiftRight(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOperatorCast(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOperatorCast(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger8(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger8(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger8Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger8Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger16(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger16(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger16Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger16Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger32(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger32(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger32Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger32Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger64(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger64(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveInteger64Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveInteger64Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger8(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger8(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger8Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger8Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger16(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger16(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger16Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger16Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger32(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger32(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger32Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger32Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger64(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger64(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveUinteger64Alias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveUinteger64Alias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveSingle(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveSingle(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveSingleAlias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveSingleAlias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveDouble(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveDouble(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveExtended(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveExtended(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveBoolean(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveBoolean(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveBooleanAlias(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveBooleanAlias(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveCharacter(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveCharacter(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterContainerString(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitContainerString(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterContainerArray(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitContainerArray(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterContainerMap(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitContainerMap(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterContainerEvent(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitContainerEvent(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionType(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionType(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionSign(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionSign(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionReturn(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionReturn(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogicTrue(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogicTrue(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogicFalse(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogicFalse(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDeclarationGetter(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDeclarationGetter(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDeclarationSetter(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDeclarationSetter(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDeclarationAlloc(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDeclarationAlloc(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassType(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassType(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassExtend(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassExtend(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassPublic(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassPublic(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassPrivate(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassPrivate(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassProtected(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassProtected(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBranchIf(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBranchIf(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBranchElse(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBranchElse(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopFor(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopFor(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopInitial(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopInitial(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopWhile(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopWhile(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopStep(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopStep(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopUntil(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopUntil(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopBreak(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopBreak(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopContinue(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopContinue(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralBooleanTrue(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralBooleanTrue(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralBooleanFalse(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralBooleanFalse(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralNumericIntegerDecimal(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralNumericIntegerDecimal(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralNumericIntegerOctal(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralNumericIntegerOctal(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralNumericIntegerHexadecimal(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralNumericIntegerHexadecimal(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralNumericReal(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralNumericReal(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralString(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralString(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteralCharacter(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteralCharacter(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterIdentifier(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitIdentifier(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterErrortoken(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitErrortoken(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPoiSource(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPoiSource(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPoiSource(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStatementList(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStatementList(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildStatementList(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterExpressionStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitExpressionStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildExpressionStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDeclarationStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDeclarationStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildDeclarationStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEmptyStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEmptyStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildEmptyStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildFunctionExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionParameter(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionParameter(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildFunctionParameter(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionReturnValue(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionReturnValue(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildFunctionReturnValue(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionBody(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionBody(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildFunctionBody(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStatementBlock(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStatementBlock(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildStatementBlock(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPairDeclaration(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPairDeclaration(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPairDeclaration(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPairDeclarationContent(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPairDeclarationContent(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPairDeclarationContent(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAssignExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAssignExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildAssignExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAssignExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAssignExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildAssignExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPairOrFunctionExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPairOrFunctionExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPairOrFunctionExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPairExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPairExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPairExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPairExpressionContent(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPairExpressionContent(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPairExpressionContent(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterArithmeticExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitArithmeticExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildArithmeticExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterConditionExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitConditionExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildConditionExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterConditionExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitConditionExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildConditionExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogicalOrExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogicalOrExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLogicalOrExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogicalOrExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogicalOrExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLogicalOrExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogicalAndExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogicalAndExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLogicalAndExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogicalAndExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogicalAndExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLogicalAndExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBitOrExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBitOrExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBitOrExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBitOrExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBitOrExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBitOrExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBitXorExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBitXorExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBitXorExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBitXorExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBitXorExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBitXorExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBitAndExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBitAndExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBitAndExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBitAndExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBitAndExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBitAndExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEqualityExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEqualityExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildEqualityExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEqualityExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEqualityExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildEqualityExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterRelationalExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitRelationalExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildRelationalExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterRelationalExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitRelationalExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildRelationalExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterShiftExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitShiftExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildShiftExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterShiftExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitShiftExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildShiftExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAddSubExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAddSubExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildAddSubExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAddSubExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAddSubExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildAddSubExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterMulDivModExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitMulDivModExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildMulDivModExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterMulDivModExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitMulDivModExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildMulDivModExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterUnaryExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitUnaryExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildUnaryExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBasicExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBasicExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBasicExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBasicExpressionT(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBasicExpressionT(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBasicExpressionT(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFunctionVariable(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFunctionVariable(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildFunctionVariable(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterArrayVariable(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitArrayVariable(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildArrayVariable(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimaryExpression(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimaryExpression(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPrimaryExpression(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLiteral(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLiteral(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLiteral(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDeclaration(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDeclaration(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildDeclaration(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableDeclaration(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableDeclaration(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableDeclaration(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableType(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableType(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableType(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPrimitiveType(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPrimitiveType(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildPrimitiveType(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterContainerType(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitContainerType(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildContainerType(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterUserType(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitUserType(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildUserType(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableAccess(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableAccess(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableAccess(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableGetterSetter(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableGetterSetter(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableGetterSetter(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableGetter(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableGetter(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableGetter(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableSetter(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableSetter(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableSetter(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVariableInitializer(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVariableInitializer(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildVariableInitializer(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStringContainer(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStringContainer(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildStringContainer(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterArrayContainer(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitArrayContainer(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildArrayContainer(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterMapContainer(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitMapContainer(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildMapContainer(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEventContainer(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEventContainer(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildEventContainer(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassDeclaration(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassDeclaration(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildClassDeclaration(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassName(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassName(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildClassName(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSuperClassName(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSuperClassName(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildSuperClassName(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassBody(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassBody(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildClassBody(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassContent(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassContent(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildClassContent(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassVariable(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassVariable(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildClassVariable(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClassAccessModifier(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClassAccessModifier(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildClassAccessModifier(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterReturnStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitReturnStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildReturnStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStructualStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStructualStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildStructualStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBranchStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBranchStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBranchStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBranchCondition(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBranchCondition(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBranchCondition(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBranchTargetStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBranchTargetStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildBranchTargetStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLoopStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopStartCondition(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopStartCondition(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLoopStartCondition(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopInitStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopInitStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLoopInitStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopStepStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopStepStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLoopStepStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopTargetStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopTargetStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLoopTargetStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopStopCondition(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopStopCondition(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildLoopStopCondition(Production node, Node child) {
            node.AddChild(child);
        }
    }
}
