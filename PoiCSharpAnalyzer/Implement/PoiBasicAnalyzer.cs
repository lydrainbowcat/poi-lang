using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerCederberg.Grammatica.Runtime;
using System.IO;

namespace PoiLanguage
{
    class PoiBasicAnalyzer : PoiAnalyzer
    {
        private PoiAnalyzerScopeStack scopeStack;
        
        private const String POI_PREFIX = "__";

        private const String POI_TEMP_VARIABLE = POI_PREFIX + "poi_temp_variable";
        private const String POI_TEMP_RETURN = POI_PREFIX + "poi_temp_return";
        private const String POI_TEMP_RETURN_CLEAR_CODE = POI_TEMP_RETURN + ".length = 0;";

        private const String POI_FUNCTION_BODY_LABEL = POI_PREFIX + "poi_function_body";
        private const String POI_FUNCTION_RETURN_CODE = "break " + POI_FUNCTION_BODY_LABEL + ";";

        private const String POI_JAVASCRIPT_HEADER_PATH = "scripts/PoiJsHeader.js";

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public override void EnterSymbolLeftParen(Token node)
        {
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
        public override Node ExitSymbolLeftParen(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolRightParen(Token node)
        {
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
        public override Node ExitSymbolRightParen(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolLeftBrace(Token node)
        {
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
        public override Node ExitSymbolLeftBrace(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolRightBrace(Token node)
        {
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
        public override Node ExitSymbolRightBrace(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolLeftBracket(Token node)
        {
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
        public override Node ExitSymbolLeftBracket(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolRightBracket(Token node)
        {
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
        public override Node ExitSymbolRightBracket(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolQuestionMark(Token node)
        {
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
        public override Node ExitSymbolQuestionMark(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolColonMark(Token node)
        {
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
        public override Node ExitSymbolColonMark(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolSemicolon(Token node)
        {
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
        public override Node ExitSymbolSemicolon(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage() + "\r\n"));
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
        public override void EnterSymbolComma(Token node)
        {
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
        public override Node ExitSymbolComma(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolDot(Token node)
        {
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
        public override Node ExitSymbolDot(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterSymbolArrow(Token node)
        {
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
        public override Node ExitSymbolArrow(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorAssign(Token node)
        {
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
        public override Node ExitOperatorAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorAddAssign(Token node)
        {
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
        public override Node ExitOperatorAddAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorSubAssign(Token node)
        {
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
        public override Node ExitOperatorSubAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorMulAssign(Token node)
        {
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
        public override Node ExitOperatorMulAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorDivAssign(Token node)
        {
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
        public override Node ExitOperatorDivAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorModAssign(Token node)
        {
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
        public override Node ExitOperatorModAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorShiftLeftAssign(Token node)
        {
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
        public override Node ExitOperatorShiftLeftAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorShiftRightAssign(Token node)
        {
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
        public override Node ExitOperatorShiftRightAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitAndAssign(Token node)
        {
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
        public override Node ExitOperatorBitAndAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitOrAssign(Token node)
        {
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
        public override Node ExitOperatorBitOrAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitXorAssign(Token node)
        {
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
        public override Node ExitOperatorBitXorAssign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorAdd(Token node)
        {
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
        public override Node ExitOperatorAdd(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorSub(Token node)
        {
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
        public override Node ExitOperatorSub(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorMul(Token node)
        {
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
        public override Node ExitOperatorMul(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorDiv(Token node)
        {
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
        public override Node ExitOperatorDiv(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorModular(Token node)
        {
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
        public override Node ExitOperatorModular(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorLess(Token node)
        {
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
        public override Node ExitOperatorLess(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorGreater(Token node)
        {
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
        public override Node ExitOperatorGreater(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorUnequal(Token node)
        {
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
        public override Node ExitOperatorUnequal(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorEqual(Token node)
        {
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
        public override Node ExitOperatorEqual(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorLessEqual(Token node)
        {
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
        public override Node ExitOperatorLessEqual(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorGreaterEqual(Token node)
        {
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
        public override Node ExitOperatorGreaterEqual(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorLogicAnd(Token node)
        {
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
        public override Node ExitOperatorLogicAnd(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorLogicOr(Token node)
        {
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
        public override Node ExitOperatorLogicOr(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorLogicNot(Token node)
        {
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
        public override Node ExitOperatorLogicNot(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitAnd(Token node)
        {
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
        public override Node ExitOperatorBitAnd(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitOr(Token node)
        {
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
        public override Node ExitOperatorBitOr(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitNot(Token node)
        {
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
        public override Node ExitOperatorBitNot(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorBitXor(Token node)
        {
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
        public override Node ExitOperatorBitXor(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorInc(Token node)
        {
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
        public override Node ExitOperatorInc(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorDec(Token node)
        {
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
        public override Node ExitOperatorDec(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorShiftLeft(Token node)
        {
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
        public override Node ExitOperatorShiftLeft(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorShiftRight(Token node)
        {
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
        public override Node ExitOperatorShiftRight(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterOperatorCast(Token node)
        {
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
        public override Node ExitOperatorCast(Token node)
        {
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
        public override void EnterPrimitiveInteger8(Token node)
        {
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
        public override Node ExitPrimitiveInteger8(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger8Alias(Token node)
        {
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
        public override Node ExitPrimitiveInteger8Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger16(Token node)
        {
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
        public override Node ExitPrimitiveInteger16(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger16Alias(Token node)
        {
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
        public override Node ExitPrimitiveInteger16Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger32(Token node)
        {
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
        public override Node ExitPrimitiveInteger32(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger32Alias(Token node)
        {
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
        public override Node ExitPrimitiveInteger32Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger64(Token node)
        {
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
        public override Node ExitPrimitiveInteger64(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveInteger64Alias(Token node)
        {
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
        public override Node ExitPrimitiveInteger64Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger8(Token node)
        {
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
        public override Node ExitPrimitiveUinteger8(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger8Alias(Token node)
        {
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
        public override Node ExitPrimitiveUinteger8Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger16(Token node)
        {
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
        public override Node ExitPrimitiveUinteger16(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger16Alias(Token node)
        {
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
        public override Node ExitPrimitiveUinteger16Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger32(Token node)
        {
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
        public override Node ExitPrimitiveUinteger32(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger32Alias(Token node)
        {
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
        public override Node ExitPrimitiveUinteger32Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger64(Token node)
        {
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
        public override Node ExitPrimitiveUinteger64(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveUinteger64Alias(Token node)
        {
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
        public override Node ExitPrimitiveUinteger64Alias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveSingle(Token node)
        {
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
        public override Node ExitPrimitiveSingle(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveSingleAlias(Token node)
        {
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
        public override Node ExitPrimitiveSingleAlias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveDouble(Token node)
        {
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
        public override Node ExitPrimitiveDouble(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveExtended(Token node)
        {
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
        public override Node ExitPrimitiveExtended(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveBoolean(Token node)
        {
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
        public override Node ExitPrimitiveBoolean(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveBooleanAlias(Token node)
        {
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
        public override Node ExitPrimitiveBooleanAlias(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterPrimitiveCharacter(Token node)
        {
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
        public override Node ExitPrimitiveCharacter(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterContainerString(Token node)
        {
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
        public override Node ExitContainerString(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "var"));
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
        public override void EnterContainerArray(Token node)
        {
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
        public override Node ExitContainerArray(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterContainerMap(Token node)
        {
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
        public override Node ExitContainerMap(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterContainerEvent(Token node)
        {
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
        public override Node ExitContainerEvent(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterFunctionType(Token node)
        {
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
        public override Node ExitFunctionType(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterFunctionSign(Token node)
        {
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
        public override Node ExitFunctionSign(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterFunctionReturn(Token node)
        {
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
        public override Node ExitFunctionReturn(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterLogicTrue(Token node)
        {
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
        public override Node ExitLogicTrue(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterLogicFalse(Token node)
        {
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
        public override Node ExitLogicFalse(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterDeclarationGetter(Token node)
        {
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
        public override Node ExitDeclarationGetter(Token node)
        {
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
        public override void EnterDeclarationSetter(Token node)
        {
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
        public override Node ExitDeclarationSetter(Token node)
        {
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
        public override void EnterDeclarationAlloc(Token node)
        {
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
        public override Node ExitDeclarationAlloc(Token node)
        {
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
        public override void EnterClassType(Token node)
        {
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
        public override Node ExitClassType(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage(), PoiVariableType.Undefined));
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
        public override void EnterClassExtend(Token node)
        {
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
        public override Node ExitClassExtend(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage(), PoiVariableType.Undefined));
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
        public override void EnterClassPublic(Token node)
        {
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
        public override Node ExitClassPublic(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterClassPrivate(Token node)
        {
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
        public override Node ExitClassPrivate(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterClassProtected(Token node)
        {
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
        public override Node ExitClassProtected(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage()));
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
        public override void EnterBranchIf(Token node)
        {
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
        public override Node ExitBranchIf(Token node)
        {
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
        public override void EnterBranchElse(Token node)
        {
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
        public override Node ExitBranchElse(Token node)
        {
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
        public override void EnterLoopFor(Token node)
        {
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
        public override Node ExitLoopFor(Token node)
        {
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
        public override void EnterLoopInitial(Token node)
        {
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
        public override Node ExitLoopInitial(Token node)
        {
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
        public override void EnterLoopStep(Token node)
        {
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
        public override Node ExitLoopStep(Token node)
        {
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
        public override void EnterLoopUntil(Token node)
        {
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
        public override Node ExitLoopUntil(Token node)
        {
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
        public override void EnterLoopBreak(Token node)
        {
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
        public override Node ExitLoopBreak(Token node)
        {
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
        public override void EnterLoopContinue(Token node)
        {
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
        public override Node ExitLoopContinue(Token node)
        {
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
        public override void EnterEventTrigger(Token node)
        {
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
        public override Node ExitEventTrigger(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "poi~", PoiVariableType.Boolean));
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
        public override void EnterLiteralBooleanTrue(Token node)
        {
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
        public override Node ExitLiteralBooleanTrue(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "true", PoiVariableType.Boolean));
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
        public override void EnterLiteralBooleanFalse(Token node)
        {
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
        public override Node ExitLiteralBooleanFalse(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "false", PoiVariableType.Boolean));
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
        public override void EnterLiteralNumericIntegerDecimal(Token node)
        {
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
        public override Node ExitLiteralNumericIntegerDecimal(Token node)
        {
            long integer = Convert.ToInt64(node.GetImage(), 10);
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, integer.ToString(), IntegerType(integer)));
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
        public override void EnterLiteralNumericIntegerOctal(Token node)
        {
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
        public override Node ExitLiteralNumericIntegerOctal(Token node)
        {
            long integer = Convert.ToInt64(node.GetImage(), 8);
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, integer.ToString(), IntegerType(integer)));
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
        public override void EnterLiteralNumericIntegerHexadecimal(Token node)
        {
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
        public override Node ExitLiteralNumericIntegerHexadecimal(Token node)
        {
            long integer = Convert.ToInt64(node.GetImage(), 16);
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, integer.ToString(), IntegerType(integer)));
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
        public override void EnterLiteralNumericReal(Token node)
        {
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
        public override Node ExitLiteralNumericReal(Token node)
        {
            double real = Convert.ToDouble(node.GetImage());
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, real.ToString(), RealNumberType(real)));
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
        public override void EnterLiteralNumericUintegerDecimal(Token node)
        {
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
        public override Node ExitLiteralNumericUintegerDecimal(Token node)
        {
            String image = node.GetImage();
            ulong integer = Convert.ToUInt64(image.Substring(0, image.Length - 1), 10);
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, integer.ToString(), UIntegerType(integer)));
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
        public override void EnterLiteralString(Token node)
        {
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
        public override Node ExitLiteralString(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage(), PoiVariableType.String));
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
        public override void EnterLiteralCharacter(Token node)
        {
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
        public override Node ExitLiteralCharacter(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage(), PoiVariableType.Character));
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
        public override void EnterIdentifier(Token node)
        {
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
        public override Node ExitIdentifier(Token node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, node.GetImage(), scopeStack.GetVariableType(node.GetImage())));
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
        public override void EnterErrortoken(Token node)
        {
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
        public override Node ExitErrortoken(Token node)
        {
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
        public override void EnterPoiSource(Production node)
        {
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
        public override Node ExitPoiSource(Production node)
        {
            String code = MergeChildList(node).ToString();

            try
            {
                StreamReader sr = new StreamReader(POI_JAVASCRIPT_HEADER_PATH, System.Text.Encoding.GetEncoding("utf-8"));
                string header = sr.ReadToEnd().ToString();
                sr.Close();

                code = header + code;
            }
            catch (Exception)
            {
                throw new PoiAnalyzeException("Can not read header of javascript. Please check " + POI_JAVASCRIPT_HEADER_PATH + " is existed and try again");
            }

            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, code));
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
        public override void ChildPoiSource(Production node, Node child)
        {
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
        public override void EnterStatementList(Production node)
        {
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
        public override Node ExitStatementList(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildStatementList(Production node, Node child)
        {
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
        public override void EnterStatement(Production node)
        {
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
        public override Node ExitStatement(Production node)
        {
            if (node.GetChildCount() != 1)
                throw new PoiAnalyzeException("Statement doesn't have 1 child");
            Node child = node.GetChildAt(0);
            if (child.Name == "ExpressionStatement" || child.Name == "DeclarationStatement" || child.Name == "StructualStatement" || child.Name == "ReturnStatement" || child.Name == "EventStatement")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            }
            else if (child.Name == "EmptyStatement")
            {
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, ";"));
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
        public override void ChildStatement(Production node, Node child)
        {
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
        public override void EnterExpressionStatement(Production node)
        {
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
        public override Node ExitExpressionStatement(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildExpressionStatement(Production node, Node child)
        {
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
        public override void EnterDeclarationStatement(Production node)
        {
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
        public override Node ExitDeclarationStatement(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildDeclarationStatement(Production node, Node child)
        {
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
        public override void EnterEmptyStatement(Production node)
        {
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
        public override Node ExitEmptyStatement(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildEmptyStatement(Production node, Node child)
        {
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
        public override void EnterExpression(Production node)
        {
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
        public override Node ExitExpression(Production node)
        {
            if (node.GetChildCount() != 1)
                throw new PoiAnalyzeException("Expression doesn't have 1 child");
            Node child = node.GetChildAt(0);
            if (child.Name == "AssignExpression")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            }
            else if (child.Name == "FunctionExpression")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            }
            else throw new PoiAnalyzeException("Expression not supported");
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
        public override void ChildExpression(Production node, Node child)
        {
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
        public override void EnterFunctionExpression(Production node)
        {
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
        public override Node ExitFunctionExpression(Production node)
        {
            Node parameter = node.GetChildAt(1);
            Node returnVariables = node.GetChildAt(3);
            Node functionBody = node.GetChildAt(4);

            List<PoiObject> parameterList;
            List<PoiObject> returnVariablesList;
            String body;

            try
            {
                parameterList = (parameter.GetValue(0) as PoiObject).ToPair();
                returnVariablesList = (returnVariables.GetValue(0) as PoiObject).ToPair();
                body = (functionBody.GetValue(0) as PoiObject).ToString();
            }
            catch (PoiObjectException ex)
            {
                throw new PoiAnalyzeException("FunctionExpression: invalid parameter pair, return pair or functionBody String: " + ex.Message);
            }

            String variableAccess = "";
            String variables = "";
            String variablesDeclaration = "";
            parameterList.ForEach(delegate(PoiObject param)
            {
                String paramDeclaration = param.ToString();

                int variableDeclarationStart = paramDeclaration.LastIndexOf("var");
                int variableStart = variableDeclarationStart + 4;

                if (variables != "")
                    variables += ",";
                variables += paramDeclaration.Substring(variableStart, paramDeclaration.Length - variableStart);
                variableAccess += paramDeclaration.Substring(0, variableDeclarationStart);
            });

            String[] returnVariablesArray = new String[returnVariablesList.Count];
            int vi = 0;
            returnVariablesList.ForEach(delegate(PoiObject param)
            {
                String paramDeclaration = param.ToString();

                int variableDeclarationStart = paramDeclaration.LastIndexOf("var");
                int variableStart = variableDeclarationStart + 4;

                returnVariablesArray[vi++] = paramDeclaration.Substring(variableStart, paramDeclaration.Length - variableStart);
                variableAccess += paramDeclaration.Substring(0, variableDeclarationStart);
                variablesDeclaration += paramDeclaration.Substring(variableDeclarationStart, paramDeclaration.Length - variableDeclarationStart) + ";";
            });

            String bodyLabel = POI_FUNCTION_BODY_LABEL + ":";

            String returnAssignCode = "";
            for (int i = 0; i < returnVariablesArray.Length; i++)
            {
                returnAssignCode += POI_TEMP_RETURN + "[" + i + "] = " + returnVariablesArray[i] + ";";
            }

            int bodyStart = body.IndexOf("{");
            int bodyEnd = body.LastIndexOf("}");
            body = "{" + body.Substring(bodyStart + 1, bodyEnd - bodyStart - 1) + POI_FUNCTION_RETURN_CODE + "}";
            body = "{" + variableAccess + variablesDeclaration + bodyLabel + body + returnAssignCode + "}";

            String function = "function(" + variables + ")" + body;
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, function, PoiVariableType.Function));
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
        public override void ChildFunctionExpression(Production node, Node child)
        {
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
        public override void EnterFunctionParameter(Production node)
        {
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
        public override Node ExitFunctionParameter(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildFunctionParameter(Production node, Node child)
        {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysisH
         * discovered errors</exception>
         */
        public override void EnterFunctionReturnValue(Production node)
        {
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
        public override Node ExitFunctionReturnValue(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildFunctionReturnValue(Production node, Node child)
        {
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
        public override void EnterFunctionBody(Production node)
        {
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
        public override Node ExitFunctionBody(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildFunctionBody(Production node, Node child)
        {
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
        public override void EnterPairDeclaration(Production node)
        {
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
        public override Node ExitPairDeclaration(Production node)
        {
            if (node.GetChildCount() == 2)
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Pair, new List<PoiObject>()));
            else
                PoiInfo.AddValuePos(node, node.GetChildAt(1).GetValue(0) as PoiObject);
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
        public override void ChildPairDeclaration(Production node, Node child)
        {
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
        public override void EnterPairExpression(Production node)
        {
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
        public override Node ExitPairExpression(Production node)
        {
            if (node.GetChildCount() == 2)
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Pair, new List<PoiObject>()));
            else
                PoiInfo.AddValuePos(node, node.GetChildAt(1).GetValue(0) as PoiObject);
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
        public override void ChildPairExpression(Production node, Node child)
        {
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
        public override void EnterPairDeclarationContent(Production node)
        {
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
        public override Node ExitPairDeclarationContent(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                List<PoiObject> list = new List<PoiObject>();
                list.Insert(0, node.GetChildAt(0).GetValue(0) as PoiObject);
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Pair, list, PoiVariableType.Pair));
            }
            else
            {
                List<PoiObject> list = (node.GetChildAt(2).GetValue(0) as PoiObject).ToPair();
                list.Insert(0, node.GetChildAt(0).GetValue(0) as PoiObject);
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Pair, list, PoiVariableType.Pair));
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
        public override void ChildPairDeclarationContent(Production node, Node child)
        {
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
        public override void EnterPairExpressionContent(Production node)
        {
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
        public override Node ExitPairExpressionContent(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                List<PoiObject> list = new List<PoiObject>();
                list.Insert(0, node.GetChildAt(0).GetValue(0) as PoiObject);
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Pair, list, PoiVariableType.Pair));
            }
            else
            {
                List<PoiObject> list = (node.GetChildAt(2).GetValue(0) as PoiObject).ToPair();
                list.Insert(0, node.GetChildAt(0).GetValue(0) as PoiObject);
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Pair, list, PoiVariableType.Pair));
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
        public override void ChildPairExpressionContent(Production node, Node child)
        {
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
        public override void EnterStatementBlock(Production node)
        {
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
        public override Node ExitStatementBlock(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildStatementBlock(Production node, Node child)
        {
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
        public override void EnterArithmeticExpression(Production node)
        {
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
        public override Node ExitArithmeticExpression(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildArithmeticExpression(Production node, Node child)
        {
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
        public override void EnterAssignExpression(Production node)
        {
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
        public override Node ExitAssignExpression(Production node)
        {
            Node child = node.GetChildAt(0);
            if (child.Name == "ArithmeticExpression")
            {
                if (node.GetChildCount() == 1)
                {
                    PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
                }
                else
                {
                    Node left = node.GetChildAt(0);
                    Node right = node.GetChildAt(1);

                    String variable = (left.GetValue(0) as PoiObject).ToString();
                    String assignOperator = (right.GetChildAt(0).GetValue(0) as PoiObject).ToString();
                    String variableExpression = (right.GetChildAt(1).GetValue(0) as PoiObject).ToString();

                    String assignExpression = variable + assignOperator + variableExpression;

                    // Type Check
                    PoiVariableType leftType = (left.GetValue(0) as PoiObject).VariableType;
                    PoiVariableType rightType = (right.GetChildAt(1).GetValue(0) as PoiObject).VariableType;

                    if (leftType == PoiVariableType.Event &&
                        (assignOperator == "+=" || assignOperator == "-=") &&
                        rightType == PoiVariableType.Function)
                    {
                        if (assignOperator == "+=")
                        {
                            if (right.GetChildAt(1).GetName() == "FunctionExpression")
                            {
                                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, variable + ".add(\"\", " + variableExpression + ")"));
                            }
                            else
                            {
                                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, variable + ".add(\"" + variableExpression + "\", " + variableExpression + ")"));
                            }
                        }
                        else if (assignOperator == "-=")
                        {
                            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, variable + ".remove(\"" + variableExpression + "\")"));
                        }
                    }
                    else
                    {
                        PoiType.CheckAssign(leftType, rightType);
                        PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, assignExpression));
                    }
                }
            }
            else if (child.Name == "PairExpression")
            {
                if (node.GetChildCount() == 1)
                {
                    List<PoiObject> left = (node.GetChildAt(0).GetValue(0) as PoiObject).ToPair();
                    string result = "";
                    for (int i = 0; i < left.Count; i++)
                    {
                        string str = left[i].ToString() + (i == left.Count - 1 ? "" : ";\r\n");
                        result += str;
                    }
                    PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, result));
                }
                else
                {
                    List<PoiObject> left = (node.GetChildAt(0).GetValue(0) as PoiObject).ToPair();
                    PoiObject rightObject = node.GetChildAt(2).GetValue(0) as PoiObject;
                    if (rightObject.Type == PoiObjectType.Pair)
                    {
                        List<PoiObject> right = rightObject.ToPair();
                        if (left.Count != right.Count)
                            throw new PoiAnalyzeException("AssignExpression pairs are in different counts");
                        string result = "{\r\n";
                        for (int i = 0; i < left.Count; i++)
                        {
                            string variable = left[i].ToString();
                            string str = variable + " = " + right[i].ToString() + ";\r\n";
                            result += str;
                        }
                        result += "}";
                        PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, result));
                    }
                    else if (rightObject.Type == PoiObjectType.String)
                    {
                        string right = rightObject.ToString();
                        string result = "{\r\n";

                        result += right + ";";

                        for (int i = 0; i < left.Count; i++)
                        {
                            string variable = left[i].ToString();
                            string str = variable + " = " + POI_TEMP_RETURN + "[" + i + "];\r\n";
                            result += str;
                        }

                        result += "}";
                        PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, result));
                    }
                }
            }
            else throw new PoiAnalyzeException("AssignExpression not supported");
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
        public override void ChildAssignExpression(Production node, Node child)
        {
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
        public override void EnterAssignExpressionT(Production node)
        {
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
        public override Node ExitAssignExpressionT(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildAssignExpressionT(Production node, Node child)
        {
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
        public override void EnterPairOrFunctionExpression(Production node)
        {
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
        public override Node ExitPairOrFunctionExpression(Production node)
        {
            Node child = node.GetChildAt(0);
            if (child.Name == "PairExpression")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            }
            else if (child.Name == "BasicExpression")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            }
            else throw new PoiAnalyzeException("PairOrFunctionExpression not supported");
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
        public override void ChildPairOrFunctionExpression(Production node, Node child)
        {
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
        public override void EnterConditionExpression(Production node)
        {
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
        public override Node ExitConditionExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                PoiObject right = node.GetChildAt(1).GetValue(0) as PoiObject;

                if (left.VariableType != PoiVariableType.Boolean)
                {
                    throw new PoiAnalyzeException("Error type of first argument of Condition expression");
                }
                
                PoiObject expr = MergeChildList(node);
                expr.VariableType = right.VariableType;
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildConditionExpression(Production node, Node child)
        {
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
        public override void EnterConditionExpressionT(Production node)
        {
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
        public override Node ExitConditionExpressionT(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(1).GetValue(0) as PoiObject;
                PoiObject right = node.GetChildAt(3).GetValue(0) as PoiObject;

                if (left.VariableType != right.VariableType)
                {
                    throw new PoiAnalyzeException("Error type of second and third argument of Condition expression");
                }

                PoiObject expr = MergeChildList(node);
                expr.VariableType = right.VariableType;
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildConditionExpressionT(Production node, Node child)
        {
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
        public override void EnterLogicalOrExpression(Production node)
        {
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
        public override Node ExitLogicalOrExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.LogicalOrExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildLogicalOrExpression(Production node, Node child)
        {
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
        public override void EnterLogicalOrExpressionT(Production node)
        {
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
        public override Node ExitLogicalOrExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildLogicalOrExpressionT(Production node, Node child)
        {
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
        public override void EnterLogicalAndExpression(Production node)
        {
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
        public override Node ExitLogicalAndExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.LogicalAndExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildLogicalAndExpression(Production node, Node child)
        {
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
        public override void EnterLogicalAndExpressionT(Production node)
        {
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
        public override Node ExitLogicalAndExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildLogicalAndExpressionT(Production node, Node child)
        {
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
        public override void EnterBitOrExpression(Production node)
        {
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
        public override Node ExitBitOrExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.BitOrExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildBitOrExpression(Production node, Node child)
        {
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
        public override void EnterBitOrExpressionT(Production node)
        {
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
        public override Node ExitBitOrExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildBitOrExpressionT(Production node, Node child)
        {
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
        public override void EnterBitXorExpression(Production node)
        {
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
        public override Node ExitBitXorExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.BitXorExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildBitXorExpression(Production node, Node child)
        {
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
        public override void EnterBitXorExpressionT(Production node)
        {
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
        public override Node ExitBitXorExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildBitXorExpressionT(Production node, Node child)
        {
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
        public override void EnterBitAndExpression(Production node)
        {
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
        public override Node ExitBitAndExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.BitAndExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildBitAndExpression(Production node, Node child)
        {
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
        public override void EnterBitAndExpressionT(Production node)
        {
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
        public override Node ExitBitAndExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildBitAndExpressionT(Production node, Node child)
        {
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
        public override void EnterEqualityExpression(Production node)
        {
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
        public override Node ExitEqualityExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.EqualityExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildEqualityExpression(Production node, Node child)
        {
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
        public override void EnterEqualityExpressionT(Production node)
        {
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
        public override Node ExitEqualityExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildEqualityExpressionT(Production node, Node child)
        {
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
        public override void EnterRelationalExpression(Production node)
        {
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
        public override Node ExitRelationalExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.RelationalExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildRelationalExpression(Production node, Node child)
        {
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
        public override void EnterRelationalExpressionT(Production node)
        {
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
        public override Node ExitRelationalExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildRelationalExpressionT(Production node, Node child)
        {
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
        public override void EnterShiftExpression(Production node)
        {
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
        public override Node ExitShiftExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.ShiftExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildShiftExpression(Production node, Node child)
        {
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
        public override void EnterShiftExpressionT(Production node)
        {
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
        public override Node ExitShiftExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildShiftExpressionT(Production node, Node child)
        {
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
        public override void EnterAddSubExpression(Production node)
        {
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
        public override Node ExitAddSubExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.AddSubExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildAddSubExpression(Production node, Node child)
        {
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
        public override void EnterAddSubExpressionT(Production node)
        {
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
        public override Node ExitAddSubExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> { node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject };
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildAddSubExpressionT(Production node, Node child)
        {
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
        public override void EnterMulDivModExpression(Production node)
        {
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
        public override Node ExitMulDivModExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                List<PoiObject> tail = (node.GetChildAt(1).GetValue(0) as PoiObject).ToPair();

                PoiObject expr = left + tail[0] + tail[1];
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.MulDivModExpression, tail[0].ToString(), new List<PoiVariableType> { left.VariableType, tail[1].VariableType });
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildMulDivModExpression(Production node, Node child)
        {
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
        public override void EnterMulDivModExpressionT(Production node)
        {
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
        public override Node ExitMulDivModExpressionT(Production node)
        {
            List<PoiObject> tailList = new List<PoiObject> {node.GetChildAt(0).GetValue(0) as PoiObject, node.GetChildAt(1).GetValue(0) as PoiObject};
            PoiObject tail = new PoiObject(PoiObjectType.Pair, tailList);
            PoiInfo.AddValuePos(node, tail);
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
        public override void ChildMulDivModExpressionT(Production node, Node child)
        {
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
        public override void EnterUnaryExpression(Production node)
        {
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
        public override Node ExitUnaryExpression(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
            }
            else
            {
                PoiObject left = node.GetChildAt(0).GetValue(0) as PoiObject;
                PoiObject right = node.GetChildAt(1).GetValue(0) as PoiObject;

                PoiObject expr = MergeChildList(node);
                expr.VariableType = PoiType.GetArithmeticExpressionType(PoiExpressionType.UnaryExpression, left.ToString(), new List<PoiVariableType>{right.VariableType});
                PoiInfo.AddValuePos(node, expr);
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
        public override void ChildUnaryExpression(Production node, Node child)
        {
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
        public override void EnterBasicExpression(Production node)
        {
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
        public override Node ExitBasicExpression(Production node)
        {
            if (node.GetChildCount() < 1)
                throw new PoiAnalyzeException("BasicExpression has no child");
            Node child0 = node.GetChildAt(0);
            if (child0.Name == "PrimaryExpression")
            {
                PoiObject left = child0.GetValue(0) as PoiObject;
                PoiObject right = new PoiObject(PoiObjectType.String, "");
                if (node.GetChildCount() > 1)
                {
                    right = node.GetChildAt(1).GetValue(0) as PoiObject;
                    if (node.GetChildAt(1).GetChildAt(0).GetName() == "SYMBOL_DOT" && right.ToString().IndexOf("static") == 0)
                        left = new PoiObject(PoiObjectType.String, "// " + left.ToString() + " ");
                }

                PoiObject expr = left + right;
                expr.VariableType = left.VariableType;

                PoiInfo.AddValuePos(node, expr);
            }
            else if (child0.Name == "SYMBOL_LEFT_PAREN")
            {
                string expression = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
                PoiObject left = new PoiObject(PoiObjectType.String, "(" + expression + ")");
                PoiObject right;
                if (node.GetChildCount() > 3)
                    right = node.GetChildAt(3).GetValue(0) as PoiObject;
                else
                    right = new PoiObject(PoiObjectType.String, "");
                PoiInfo.AddValuePos(node, left + right);
            }
            else if (child0.Name == "ArrayVariable")
            {
                string arrayvariable = (node.GetChildAt(0).GetValue(0) as PoiObject).ToString();
                string expression = (node.GetChildAt(2).GetValue(0) as PoiObject).ToString();
                PoiObject left = new PoiObject(PoiObjectType.String, arrayvariable + "[" + expression + "]");
                int current = 4;
                while (current + 3 <= node.GetChildCount())
                {
                    expression = (node.GetChildAt(current + 1).GetValue(0) as PoiObject).ToString();
                    left = new PoiObject(PoiObjectType.String, left + "[" + expression + "]");
                    current += 3;
                }
                PoiObject right;
                if (node.GetChildCount() > current)
                    right = node.GetChildAt(4).GetValue(0) as PoiObject;
                else right = new PoiObject(PoiObjectType.String, "");
                PoiInfo.AddValuePos(node, left + right);
            }
            else if (child0.Name == "FunctionVariable")
            {
                string functionVariable = (node.GetChildAt(0).GetValue(0) as PoiObject).ToString();
                string parameter = "";

                if (node.GetChildAt(2).Name == "Expression")
                {
                    string[] functionParameter = (node.GetChildAt(2).GetValue(0) as PoiObject).ToString().Split(';');
                    for (int i = 0; i < functionParameter.Length; i++)
                    {
                        if (parameter != "")
                            parameter += ",";
                        parameter += functionParameter[i].ToString();
                    }
                }

                PoiObject left = new PoiObject(PoiObjectType.String, functionVariable + "(" + parameter + ")");
                PoiObject right;
                if (node.GetChildCount() > 4)
                    right = node.GetChildAt(4).GetValue(0) as PoiObject;
                else right = new PoiObject(PoiObjectType.String, "");
                PoiInfo.AddValuePos(node, left + right);
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
        public override void ChildBasicExpression(Production node, Node child)
        {
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
        public override void EnterBasicExpressionT(Production node)
        {
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
        public override Node ExitBasicExpressionT(Production node)
        {
            if (node.GetChildCount() < 1)
                throw new PoiAnalyzeException("BasicExpressionT has no child");
            Node child0 = node.GetChildAt(0);
            if (child0.Name == "OPERATOR_INC" || child0.Name == "OPERATOR_DEC")
            {
                PoiObject left = child0.GetValue(0) as PoiObject;
                PoiObject right;
                if (node.GetChildCount() > 1)
                    right = node.GetChildAt(1).GetValue(0) as PoiObject;
                else
                    right = new PoiObject(PoiObjectType.String, "");
                PoiInfo.AddValuePos(node, left + right);
            }
            else if (child0.Name == "SYMBOL_DOT")
            {
                Node fa = GetParent(node);
                if (fa.GetChildCount() < 1 || fa.GetChildAt(0).GetName() != "PrimaryExpression")
                    throw new PoiAnalyzeException("BasicExpressionT, DOT: " + fa.GetChildCount() + " children not supported.");
                if (node.GetChildAt(1).GetChildAt(0).GetName() != "FunctionVariable")
                    throw new PoiAnalyzeException("BasicExpressionT, DOT: FunctionVariable expected, " + node.GetChildAt(1).GetChildAt(0).GetName() + " found.");
                string name = (fa.GetChildAt(0).GetValue(0) as PoiObject).ToString();
                if (!PoiHtmlLayout.Map.ContainsKey(name))
                    throw new PoiAnalyzeException("Not an existing struct: " + name);
                PoiHtmlLayout handle = PoiHtmlLayout.Map[name];
                string function = (node.GetChildAt(1).GetChildAt(0).GetValue(0) as PoiObject).ToString();
                Node expression = node.GetChildAt(1).GetChildAt(2);
                PoiObject text = handle.Solve(function, expression);
                PoiInfo.AddValuePos(node, text);
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
        public override void ChildBasicExpressionT(Production node, Node child)
        {
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
        public override void EnterFunctionVariable(Production node)
        {
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
        public override Node ExitFunctionVariable(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildFunctionVariable(Production node, Node child)
        {
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
        public override void EnterArrayVariable(Production node)
        {
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
        public override Node ExitArrayVariable(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0) as PoiObject);
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
        public override void ChildArrayVariable(Production node, Node child)
        {
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
        public override void EnterPrimaryExpression(Production node)
        {
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
        public override Node ExitPrimaryExpression(Production node)
        {
            if (node.GetChildCount() != 1)
                throw new PoiAnalyzeException("PrimaryExpression doesn't have 1 child");
            Node child = node.GetChildAt(0);
            if (child.Name == "Literal")
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            else if (child.Name == "IDENTIFIER")
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            else throw new PoiAnalyzeException("PrimaryExpression not supported");
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
        public override void ChildPrimaryExpression(Production node, Node child)
        {
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
        public override void EnterLiteral(Production node)
        {
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
        public override Node ExitLiteral(Production node)
        {
            if (node.GetChildCount() != 1)
                throw new PoiAnalyzeException("Literal doesn't have 1 child");
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0) as PoiObject);
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
        public override void ChildLiteral(Production node, Node child)
        {
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
        public override void EnterDeclaration(Production node)
        {
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
        public override Node ExitDeclaration(Production node)
        {
            Node child = node.GetChildAt(0);
            if (child.GetName() == "VariableDeclaration")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
            }
            else if (child.GetName() == "ClassDeclaration")
            {
                PoiInfo.AddValuePos(node, child.GetValue(0) as PoiObject);
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
        public override void ChildDeclaration(Production node, Node child)
        {
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
        public override void EnterVariableDeclaration(Production node)
        {
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
        public override Node ExitVariableDeclaration(Production node)
        {
            Node typeNode = node.GetChildAt(0);
            string type = typeNode.GetChildAt(0).GetName();
            bool fromClassPub = false;
            if (type == "PrimitiveType")
            {
                Node identifierNode = node.GetChildAt(1);
                Node initializerNode = null;
                string variableType = "var";
                PoiVariableType leftType = PoiType.StringToVariableType((typeNode.GetValue(0) as PoiObject).ToString());

                if (node.GetChildCount() == 3)
                {
                    Node child = node.GetChildAt(2);
                    if (child.GetName() == "VariableInitializer")
                    {
                        initializerNode = child;

                        // Type Check
                        PoiVariableType rightType = (initializerNode.GetChildAt(1).GetValue(0) as PoiObject).VariableType;
                        PoiType.CheckAssign(leftType, rightType);
                    }
                }

                String identifier = (identifierNode.GetValue(0) as PoiObject).ToString();

                String initializer = generateInitializer(initializerNode);

                String declaration = "";
                if (fromClassPub) declaration += "this.";
                else declaration += variableType + " ";
                declaration += identifier + initializer;

                // Type Check
                scopeStack.DefiniteVariable(identifier, PoiType.StringToVariableType((typeNode.GetValue(0) as PoiObject).ToString()));

                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, declaration));
            }
            else if (type == "ContainerType")
            {
                Node containerNode = typeNode.GetChildAt(0).GetChildAt(0);
                if (containerNode.Name == "ArrayContainer")
                {
                    List<string> array = (typeNode.GetValue(0) as PoiObject).ToArray();
                    string identifier = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
                    int num = Convert.ToInt32(array[0]);
                    string result = (fromClassPub ? "this." : "var ") + "__num = new Array(" + (num + 1).ToString() + ");\r\n";
                    for (int i = 1; i <= num; i++)
                    {
                        result += "__num[" + i.ToString() + "] = " + array[i] + ";\r\n";
                    }
                    result += "var " + identifier + "= new Array(__num[1]);\r\n";
                    for (int i = 1; i < num; i++)
                    {
                        string index = i.ToString();
                        result += "for (var __i" + index + "= 0; __i" + index + "< __num[" + index + "];" +
                                  "++ __i" + index + ")\r\n{\r\n";
                        result += identifier;
                        for (int j = 1; j <= i; j++)
                        {
                            result += "[__i" + j.ToString() + "]";
                        }
                        result += " = new Array(__num[" + (i + 1).ToString() + "]);\r\n";
                    }
                    for (int i = 1; i < num; i++)
                    {
                        result += "}\r\n";
                    }

                    scopeStack.DefiniteVariable(identifier, PoiVariableType.Array);

                    PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, result, PoiVariableType.Array));
                }
                else if (containerNode.Name == "StringContainer")
                {
                    PoiObject left = typeNode.GetValue(0) as PoiObject;
                    PoiObject right = node.GetChildAt(1).GetValue(0) as PoiObject;
                    if (fromClassPub)
                        PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "this.") + right);
                    else
                        PoiInfo.AddValuePos(node, left + new PoiObject(PoiObjectType.String, " ") + right);

                    scopeStack.DefiniteVariable(right.ToString(), PoiVariableType.String);
                }
                else if (containerNode.Name == "MapContainer")
                {
                    string identifier = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
                    scopeStack.DefiniteVariable(identifier, PoiVariableType.Map);
                    PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, (fromClassPub ? "this." : "var ") + identifier + " = new Object()"));
                }
                else if (containerNode.Name == "EventContainer")
                {
                    string identifier = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
                    scopeStack.DefiniteVariable(identifier, PoiVariableType.Event);
                    PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "var " + identifier + " = new Event()"));
                }
            }
            else if (type == "UserType")
            {
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
        public override void ChildVariableDeclaration(Production node, Node child)
        {
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
        public override void EnterVariableType(Production node)
        {
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
        public override Node ExitVariableType(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildVariableType(Production node, Node child)
        {
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
        public override void EnterPrimitiveType(Production node)
        {
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
        public override Node ExitPrimitiveType(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildPrimitiveType(Production node, Node child)
        {
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
        public override void EnterContainerType(Production node)
        {
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
        public override Node ExitContainerType(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildContainerType(Production node, Node child)
        {
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
        public override void EnterUserType(Production node)
        {
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
        public override Node ExitUserType(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildUserType(Production node, Node child)
        {
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
        public override void EnterVariableInitializer(Production node)
        {
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
        public override Node ExitVariableInitializer(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildVariableInitializer(Production node, Node child)
        {
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
        public override void EnterStringContainer(Production node)
        {
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
        public override Node ExitStringContainer(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildStringContainer(Production node, Node child)
        {
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
        public override void EnterArrayContainer(Production node)
        {
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
        public override Node ExitArrayContainer(Production node)
        {
            List<string> array = new List<string>();

            array.Add("1");
            int num = 1;
            string expression = (node.GetChildAt(4).GetValue(0) as PoiObject).ToString();
            array.Add(expression);
            while (num * 2 + 4 < node.GetChildCount())
            {
                num++;
                expression = (node.GetChildAt(2 + 2 * num).GetValue(0) as PoiObject).ToString();
                array.Add(expression);
            }
            array[0] = num.ToString();
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Array, array));
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
        public override void ChildArrayContainer(Production node, Node child)
        {
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
        public override void EnterMapContainer(Production node)
        {
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
        public override Node ExitMapContainer(Production node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, "map"));
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
        public override void ChildMapContainer(Production node, Node child)
        {
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
        public override void EnterEventContainer(Production node)
        {
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
        public override Node ExitEventContainer(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildEventContainer(Production node, Node child)
        {
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
        public override void EnterClassDeclaration(Production node)
        {
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
        public override Node ExitClassDeclaration(Production node)
        {
            if (node.GetChildCount() != 5)
                throw new PoiAnalyzeException("ClassDeclaration not supported");
            string name = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
            string type = (node.GetChildAt(3).GetValue(0) as PoiObject).ToString();
            PoiHtmlLayout layout = new PoiHtmlLayout(name, type, (node.GetChildAt(4).GetValue(0) as PoiObject).ToStruct());
            PoiHtmlLayout.Map[name] = layout;
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, string.Format("// Created {0} {1}", type, name)));
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
        public override void ChildClassDeclaration(Production node, Node child)
        {
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
        public override void EnterClassName(Production node)
        {
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
        public override Node ExitClassName(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0) as PoiObject);
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
        public override void ChildClassName(Production node, Node child)
        {
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
        public override void EnterSuperClassName(Production node)
        {
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
        public override Node ExitSuperClassName(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0) as PoiObject);
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
        public override void ChildSuperClassName(Production node, Node child)
        {
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
        public override void EnterClassBody(Production node)
        {
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
        public override Node ExitClassBody(Production node)
        {
            PoiObject body = new PoiObject(PoiObjectType.Struct, new List<KeyValuePair<string, string>>());
            for (int i = 1; i < node.GetChildCount() - 1; i++)
                body += node.GetChildAt(i).GetValue(0) as PoiObject;
            PoiInfo.AddValuePos(node, body);
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
        public override void ChildClassBody(Production node, Node child)
        {
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
        public override void EnterClassContent(Production node)
        {
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
        public override Node ExitClassContent(Production node)
        {
            List<KeyValuePair<string, string>> rec = new List<KeyValuePair<string, string>>();
            string key = (node.GetChildAt(0).GetValue(0) as PoiObject).ToString();
            string value = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
            rec.Add(new KeyValuePair<string, string>(key, value));
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.Struct, rec));
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
        public override void ChildClassContent(Production node, Node child)
        {
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
        public override void EnterClassVariable(Production node)
        {
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
        public override Node ExitClassVariable(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0) as PoiObject);
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
        public override void ChildClassVariable(Production node, Node child)
        {
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
        public override void EnterClassAccessModifier(Production node)
        {
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
        public override Node ExitClassAccessModifier(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0) as PoiObject);
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
        public override void ChildClassAccessModifier(Production node, Node child)
        {
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
        public override void EnterReturnStatement(Production node)
        {
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
        public override Node ExitReturnStatement(Production node)
        {
            PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, POI_FUNCTION_RETURN_CODE));
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
        public override void ChildReturnStatement(Production node, Node child)
        {
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
        public override void EnterStructualStatement(Production node)
        {
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
        public override Node ExitStructualStatement(Production node)
        {
            PoiInfo.AddValuePos(node, MergeChildList(node));
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
        public override void ChildStructualStatement(Production node, Node child)
        {
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
        public override void EnterBranchStatement(Production node)
        {
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
        public override Node ExitBranchStatement(Production node)
        {
            if (node.GetChildCount() < 3)
                throw new PoiAnalyzeException("BranchCondition has no 3 child");
            string expression = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
            string statement = (node.GetChildAt(2).GetValue(0) as PoiObject).ToString();
            PoiObject left = new PoiObject(PoiObjectType.String, "if " + expression + statement);
            PoiObject right;
            if (node.GetChildCount() > 3)
            {
                right = node.GetChildAt(4).GetValue(0) as PoiObject;
                right = new PoiObject(PoiObjectType.String, "else " + right);
            }
            else
                right = new PoiObject(PoiObjectType.String, "");
            PoiInfo.AddValuePos(node, left + right);
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
        public override void ChildBranchStatement(Production node, Node child)
        {
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
        public override void EnterBranchCondition(Production node)
        {
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
        public override Node ExitBranchCondition(Production node)
        {
            if (node.GetChildCount() < 3)
                throw new PoiAnalyzeException("BranchCondition doesn't have 3 children");
            string expression = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
            PoiObject value = new PoiObject(PoiObjectType.String, "(" + expression + ")");
            PoiInfo.AddValuePos(node, value);
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
        public override void ChildBranchCondition(Production node, Node child)
        {
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
        public override void EnterBranchTargetStatement(Production node)
        {
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
        public override Node ExitBranchTargetStatement(Production node)
        {
            if (node.GetChildCount() < 1)
                throw new PoiAnalyzeException("BranchTargetStatement has no child");
            Node child0 = node.GetChildAt(0);
            if (child0.Name == "Statement")
            {
                PoiInfo.AddValuePos(node, child0.GetValue(0) as PoiObject);
            }
            else if (child0.Name == "SYMBOL_LEFT_BRACE")
            {
                string expression = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
                PoiObject value = new PoiObject(PoiObjectType.String, "\r\n{\r\n" + expression + "}\r\n");
                PoiInfo.AddValuePos(node, value);
            }
            else
            {
                throw new PoiAnalyzeException("BranchTargetStatement not supported");
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
        public override void ChildBranchTargetStatement(Production node, Node child)
        {
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
        public override void EnterLoopStatement(Production node)
        {
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
        public override Node ExitLoopStatement(Production node)
        {
            int current = 1;
            string a1, a2, a3, a4, b;
            if (node.GetChildAt(current).Name == "LOOP_INITIAL")
            {
                a1 = (node.GetChildAt(current + 1).GetValue(0) as PoiObject).ToString();
                current += 2;
            }
            else a1 = "";
            if (node.GetChildAt(current).Name == "LOOP_WHILE")
            {
                a2 = (node.GetChildAt(current + 1).GetValue(0) as PoiObject).ToString();
                current += 2;
            }
            else a2 = "true";
            if (node.GetChildAt(current).Name == "LOOP_STEP")
            {
                a3 = (node.GetChildAt(current + 1).GetValue(0) as PoiObject).ToString();
                current += 2;
            }
            else a3 = "";
            b = (node.GetChildAt(current).GetValue(0) as PoiObject).ToString();
            current++;
            PoiObject value = new PoiObject(PoiObjectType.String, "{\r\n" + a1 + "while(" + a2 + "){\r\n" + b);
            if (node.GetChildCount() != current)
            {
                a4 = (node.GetChildAt(current + 1).GetValue(0) as PoiObject).ToString();
                value = new PoiObject(PoiObjectType.String, value + "if" + a4 + " break;\r\n" + a3 + "}\r\n}\r\n");
            }
            else value = new PoiObject(PoiObjectType.String, value + a3 + "}\r\n}\r\n");

            PoiInfo.AddValuePos(node, value);
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
        public override void ChildLoopStatement(Production node, Node child)
        {
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
        public override void EnterLoopStartCondition(Production node)
        {
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
        public override Node ExitLoopStartCondition(Production node)
        {
            if (node.GetChildCount() == 2)
            {
                PoiInfo.AddValuePos(node, new PoiObject(PoiObjectType.String, ""));
            }
            else
                PoiInfo.AddValuePos(node, node.GetChildAt(1).GetValue(0) as PoiObject);
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
        public override void ChildLoopStartCondition(Production node, Node child)
        {
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
        public override void EnterLoopInitStatement(Production node)
        {
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
        public override Node ExitLoopInitStatement(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(1).GetValue(0) as PoiObject);
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
        public override void ChildLoopInitStatement(Production node, Node child)
        {
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
        public override void EnterLoopStepStatement(Production node)
        {
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
        public override Node ExitLoopStepStatement(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(1).GetValue(0) as PoiObject);
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
        public override void ChildLoopStepStatement(Production node, Node child)
        {
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
        public override void EnterLoopTargetStatement(Production node)
        {
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
        public override Node ExitLoopTargetStatement(Production node)
        {
            if (node.GetChildCount() == 1)
            {
                PoiInfo.AddValuePos(node, MergeChildList(node));
            }
            else
            {
                PoiInfo.AddValuePos(node, node.GetChildAt(1).GetValue(0) as PoiObject);
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
        public override void ChildLoopTargetStatement(Production node, Node child)
        {
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
        public override void EnterLoopStopCondition(Production node)
        {
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
        public override Node ExitLoopStopCondition(Production node)
        {
            if (node.GetChildCount() < 3)
                throw new PoiAnalyzeException("BranchCondition has no 3 child");
            string expression = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
            PoiObject value = new PoiObject(PoiObjectType.String, "(" + expression + ")");
            PoiInfo.AddValuePos(node, value);
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
        public override void ChildLoopStopCondition(Production node, Node child)
        {
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
        public override void EnterEventStatement(Production node)
        {
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
        public override Node ExitEventStatement(Production node)
        {
            string eventVariable = (node.GetChildAt(1).GetValue(0) as PoiObject).ToString();
            string parameter = "";

            if (node.GetChildAt(3).GetName() == "Expression")
            {
                string[] functionParameter = (node.GetChildAt(3).GetValue(0) as PoiObject).ToString().Split(';');
                for (int i = 0; i < functionParameter.Length; i++)
                {
                    if (parameter != "")
                        parameter += ",";
                    parameter += functionParameter[i].ToString();
                }
            }

            PoiObject left = new PoiObject(PoiObjectType.String, eventVariable + ".execute(" + parameter + ");");
            PoiInfo.AddValuePos(node, left);
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
        public override void ChildEventStatement(Production node, Node child)
        {
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
        public override void EnterEventVariable(Production node)
        {
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
        public override Node ExitEventVariable(Production node)
        {
            PoiInfo.AddValuePos(node, node.GetChildAt(0).GetValue(0));
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
        public override void ChildEventVariable(Production node, Node child)
        {
            node.AddChild(child);
        }


        #region 自定义方法

        private PoiObject MergeChildList(Node node)
        {
            if (node.GetChildCount() == 0)
                return new PoiObject();
            PoiObject result = node.GetChildAt(0).GetValue(0) as PoiObject;
            for (int i = 1; i < node.GetChildCount(); i++)
            {
                result += node.GetChildAt(i).GetValue(0) as PoiObject;
            }
            return result;
        }

        public void InitializeAnalyzerStatus()
        {
            InitScopeStack();
        }

        public void InitScopeStack()
        {
            scopeStack = new PoiAnalyzerScopeStack();
            scopeStack.Clear();
        }

        private string generateInitializer(Node initializerNode)
        {
            string initializer = "";
            if (initializerNode != null)
            {
                initializer = (initializerNode.GetValue(0) as PoiObject).ToString();
            }
            return initializer;
        }

        private PoiVariableType IntegerType(long number)
        {
            int length = 1;
            if (number > 0)
            {
                length = (int)(Math.Log(number) / Math.Log(2)) + 1;
            }
            else if (number < 0)
            {
                length = (int)(Math.Log(~number) / Math.Log(2)) + 1;
            }

            if (length < 8) {
                return PoiVariableType.Integer8;
            }
            else if (length < 16) {
                return PoiVariableType.Integer16;
            }
            else if (length < 32) {
                return PoiVariableType.Integer32;
            }
            else if (length < 64) {
                return PoiVariableType.Integer64;
            }
            else {
                // throw error number exception;
            }

            return PoiVariableType.Undefined;
        }

        private PoiVariableType RealNumberType(double number)
        {
            double num = Math.Abs(Convert.ToDouble(Convert.ToSingle(number)) - number);
            if (Math.Abs(Convert.ToSingle(number) - number) < 1e-7 * number)
            {
                return PoiVariableType.Single;
            }
            return PoiVariableType.Double;
        }

        private PoiVariableType UIntegerType(ulong number)
        {
            int length = (int)(Math.Log(number) / Math.Log(2)) + 1;

            if (length <= 8) {
                return PoiVariableType.UInteger8;
            }
            else if (length <= 16) {
                return PoiVariableType.UInteger16;
            }
            else if (length <= 32) {
                return PoiVariableType.UInteger32;
            }
            else if (length <= 64) {
                return PoiVariableType.UInteger64;
            }
            else {
                // throw error number exception;
            }

            return PoiVariableType.Undefined;
        }

        private Node GetParent(Node node)
        {
            return node.GetValue(2) as Node;
        }

        public List<KeyValuePair<String, PoiVariableType>> GetTypeInformation()
        {
            return scopeStack.GetVariableTypeInformation();
        }

        #endregion
    }
}