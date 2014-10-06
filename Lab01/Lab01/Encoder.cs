namespace Lab01
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for encode messages.
    /// </summary>
    public class Encoder
    {
        #region Public Methods

        /// <summary>
        /// Encodes the specified messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="letters">The letters.</param>
        /// <param name="words">The words.</param>
        /// <returns>Finded words.</returns>
        public static List<Results> Encode(List<String> messages,
            List<String> letters, List<String> words)
        {
            var combinations = new List<Results>();

            var alphabets = Alphabet.GetAllAlphabets(letters);


            foreach (var alph in alphabets)
            {
                var xors = new List<String>();
                var positions = new List<List<List<int>>>();

                for (var i = 1; i <= messages.Count; i++)
                {
                    xors.Add(XorWords(messages[i - 1], messages[i % messages.Count]));
                    positions.Add(new List<List<int>>());
                }

                for (var i = 0; i < words.Count; i++)
                {
                    for (var j = i; j < words.Count; j++)
                    {
                        var xor = XorWords(EncodeWord(alph, words[i]),
                            EncodeWord(alph, words[j]));

                        for (var k = 0; k < xors.Count; k++)
                        {
                            if (xor.Equals(xors[k]))
                            {
                                var pos = new List<int> { i, j };
                                positions[k].Add(pos);
                            }
                        }
                    }
                }

                var decode = DecodeWords(positions, words);

                if (decode != null)
                {
                    var noise = XorWords(EncodeWord(alph, decode[0]), messages[0]);

                    if (combinations.FindAll(c => c.Noise.Contains(noise)).Count == 0)
                    {
                        combinations.Add(new Results(decode, alph, noise));
                    }
                }
            }

            return combinations;
        } 

        #endregion

        #region Private Methods

        /// <summary>
        /// Decodes the words.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <param name="words">The words.</param>
        /// <returns>Finded words.</returns>
        private static List<String> DecodeWords(List<List<List<int>>> positions, List<String> words)
        {
            var results = new List<String>();

            for (var i = 0; i < positions.Count; i++)
            {
                var pos = new List<int>();

                foreach (var listI in positions[i])
                {
                    foreach (var listJ in positions[(i + 1) % positions.Count])
                    {
                        pos.AddRange(listI.Intersect(listJ));
                    }
                }

                if (pos.Count > 0)
                {
                    results.Add(words[pos[0]]);
                }
                else
                {
                    return null;
                }
            }

            return results;
        }

        /// <summary>
        /// Encodes the word.
        /// </summary>
        /// <param name="alph">The alph.</param>
        /// <param name="word">The word.</param>
        /// <returns>Encoded word.</returns>
        private static String EncodeWord(Alphabet alph, String word)
        {
            var builder = new StringBuilder();

            foreach (var letter in word)
            {
                builder.Append(alph.EncodedLetter(letter.ToString(CultureInfo.InvariantCulture)));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Xors the words.
        /// </summary>
        /// <param name="word1">The word1.</param>
        /// <param name="word2">The word2.</param>
        /// <returns>Xor of 2 words.</returns>
        private static String XorWords(String word1, String word2)
        {
            var builder = new StringBuilder(word1.Length);

            for (var i = 0; i < word1.Length; i++)
            {
                builder.Append(word1[i] == word2[i] ? '0' : '1');
            }

            return builder.ToString();
        } 

        #endregion
    }
}