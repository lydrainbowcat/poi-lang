/*
 * PoiParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 *
 * Permission is granted to copy this document verbatim in any
 * medium, provided that this copyright notice is left intact.
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

            pattern = new ProductionPattern((int) PoiConstants.EXPRESSION,
                                            "Expression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.TERM, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.EXPRESSION_TAIL,
                                            "ExpressionTail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.ADD, 1, 1);
            alt.AddProduction((int) PoiConstants.TERM, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.SUB, 1, 1);
            alt.AddProduction((int) PoiConstants.TERM, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.TERM,
                                            "Term");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.FACTOR, 1, 1);
            alt.AddProduction((int) PoiConstants.TERM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.TERM_TAIL,
                                            "TermTail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.MUL, 1, 1);
            alt.AddProduction((int) PoiConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.DIV, 1, 1);
            alt.AddProduction((int) PoiConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.FACTOR,
                                            "Factor");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) PoiConstants.ATOM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.LEFT_PAREN, 1, 1);
            alt.AddProduction((int) PoiConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) PoiConstants.RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) PoiConstants.ATOM,
                                            "Atom");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.NUMBER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) PoiConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
