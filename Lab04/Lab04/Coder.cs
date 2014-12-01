namespace Lab04
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Class for code message.
    /// </summary>
    public class Coder
    {
        #region Private Fields

        /// <summary>
        /// The alphabet
        /// </summary>
        private static readonly String[] Alphabet =
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",

            "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й",
            "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", 
            "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я",

            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
            "w", "x", "y", "z"
        }; 

        #endregion

        #region Code Tables

        /// <summary>
        /// The letters store
        /// </summary>
        public readonly Dictionary<String, String> LettersStore;

        /// <summary>
        /// The codes store
        /// </summary>
        public readonly Dictionary<String, String> CodesStore;

        /// <summary>
        /// The code length
        /// </summary>
        public static int CodeLength = Convert.ToInt32(Math.Ceiling(Math.Log(Alphabet.Length, 2)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Coder"/> class.
        /// </summary>
        public Coder()
        {
            LettersStore = new Dictionary<String, String>();

            CodesStore = new Dictionary<String, String>();

            CreateCodeTable();
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Codes the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public String CodeMessage(String message)
        {
            var sb = new StringBuilder();

            foreach (var character in message)
            {
                sb.Append(CodesStore[character.ToString(CultureInfo.InvariantCulture)]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Formats the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public String FormatMessage(String message)
        {
            return message.Replace(" ", "").Replace(",", "").Replace(".", "")
                .Replace("!", "").Replace("?", "").ToLower();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the code table.
        /// </summary>
        private void CreateCodeTable()
        {
            for (var i = 0; i < Alphabet.Length; i++)
            {

                var binaryCode = Convert.ToString(i, 2);

                while (binaryCode.Length < CodeLength)
                {
                    binaryCode = "0" + binaryCode;
                }
               
                LettersStore.Add(binaryCode, Alphabet[i]);
                CodesStore.Add(Alphabet[i], binaryCode);
            }
        } 

        #endregion
    }
}
