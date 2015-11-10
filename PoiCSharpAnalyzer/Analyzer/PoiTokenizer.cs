/*
 * PoiTokenizer.cs
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

            pattern = new TokenPattern((int) PoiConstants.ADD,
                                       "ADD",
                                       TokenPattern.PatternType.STRING,
                                       "+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.SUB,
                                       "SUB",
                                       TokenPattern.PatternType.STRING,
                                       "-");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.MUL,
                                       "MUL",
                                       TokenPattern.PatternType.STRING,
                                       "*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.DIV,
                                       "DIV",
                                       TokenPattern.PatternType.STRING,
                                       "/");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.LEFT_PAREN,
                                       "LEFT_PAREN",
                                       TokenPattern.PatternType.STRING,
                                       "(");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.RIGHT_PAREN,
                                       "RIGHT_PAREN",
                                       TokenPattern.PatternType.STRING,
                                       ")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.NUMBER,
                                       "NUMBER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[0-9]+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.IDENTIFIER,
                                       "IDENTIFIER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[a-z]");
            AddPattern(pattern);

            pattern = new TokenPattern((int) PoiConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);
        }
    }
}
