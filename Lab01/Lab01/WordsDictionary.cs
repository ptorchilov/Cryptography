namespace Lab01
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for store words.
    /// </summary>
    public class WordsDictionary
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsDictionary"/> class.
        /// </summary>
        /// <param name="words">The words.</param>
        public WordsDictionary(List<String> words)
        {
            Words = words;
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Gets the words.
        /// </summary>
        /// <value>
        /// The words.
        /// </value>
        public List<String> Words { get; private set; } 

        #endregion
    }
}
