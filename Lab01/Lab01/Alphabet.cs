namespace Lab01
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for store alphabet.
    /// </summary>
    public class Alphabet
    {
        #region Fields

        /// <summary>
        /// The letters
        /// </summary>
        private readonly Dictionary<String, String> letters;

        #endregion

        #region Private Methods

        /// <summary>
        /// Prevents a default instance of the <see cref="Alphabet"/> class from being created.
        /// </summary>
        /// <param name="letters">The letters.</param>
        private Alphabet(String letters)
        {
            this.letters = new Dictionary<String, String>();

            var size = Convert.ToInt32(Math.Ceiling(Math.Log(letters.Length, 2)));

            for (var i = 0; i < letters.Length; i++)
            {
                var bin = ConvertToBinary(i, size);

                this.letters.Add(letters[i].ToString(CultureInfo.InvariantCulture), bin);
            }
        }

        /// <summary>
        /// Converts the automatic binary.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="length">The length.</param>
        /// <returns>Binaby represents on number.</returns>
        private String ConvertToBinary(int number, int length)
        {
            var result = new StringBuilder(length);

            for (var i = 0; i < length; i++)
            {
                result.Append(number % 2);
                number /= 2;
            }

            return new String(result.ToString().ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Gets the specified letters.
        /// </summary>
        /// <param name="letters">The letters.</param>
        /// <returns>Alphabet combination.</returns>
        private static IEnumerable<String> Get(IList<String> letters)
        {
            if (letters.Count == 2)
            {
                return new List<String>(new[] { letters[0] + letters[1], letters[1] + letters[0] });
            }

            var sets = new List<String>();

            foreach (var let in letters)
            {
                var newLetters = new List<String>(letters);

                newLetters.Remove(let);

                var result = Get(newLetters);

                foreach (var res in result)
                {
                    sets.Add(let + res);
                }
            }

            return sets;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all alphabets.
        /// </summary>
        /// <param name="letters">The letters.</param>
        /// <returns>All alphaber combinations.</returns>
        public static List<Alphabet> GetAllAlphabets(List<String> letters)
        {
            var alphabets = new List<Alphabet>();

            foreach (var value in Get(letters))
            {
                alphabets.Add(new Alphabet(value));
            }

            return alphabets;
        }

        /// <summary>
        /// Encodeds the letter.
        /// </summary>
        /// <param name="letter">The letter.</param>
        /// <returns>Return letter by key.</returns>
        public String EncodedLetter(String letter)
        {
            return letters[letter];
        }

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override String ToString()
        {
            var builder = new StringBuilder();

            foreach (var letter in letters.Keys.ToList())
            {
                builder.Append(letter).Append(" - ").Append(letters[letter]).Append("  ");
            }

            return builder.ToString();
        }

        #endregion
    }
}