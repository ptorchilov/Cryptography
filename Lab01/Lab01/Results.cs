namespace Lab01
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for store results.
    /// </summary>
    public class Results
    {
        #region Fields

        /// <summary>
        /// Gets the words.
        /// </summary>
        /// <value>
        /// The words.
        /// </value>
        public List<String> Words { get; private set; }

        /// <summary>
        /// Gets the alphabet.
        /// </summary>
        /// <value>
        /// The alphabet.
        /// </value>
        public Alphabet Alphabet { get; private set; }

        /// <summary>
        /// Gets the noise.
        /// </summary>
        /// <value>
        /// The noise.
        /// </value>
        public String Noise { get; private set; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Results"/> class.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="alph">The alph.</param>
        /// <param name="noise">The noise.</param>
        public Results(List<String> words, Alphabet alph, String noise)
        {
            Words = words;
            Alphabet = alph;
            Noise = noise;
        } 

        #endregion
    }
}
