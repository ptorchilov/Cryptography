namespace Lab04
{
    using System;
    using System.Linq;

    /// <summary>
    /// Calss for realize Fiat-Shamir algorithm.
    /// </summary>
    public class FiatShamir
    {
        #region Algorithm params

        /// <summary>
        /// Gets the Ksi1.
        /// </summary>
        /// <value>
        /// The Ksi1.
        /// </value>
        public int Ksi1 { get; private set; }

        /// <summary>
        /// Gets the Ksi2.
        /// </summary>
        /// <value>
        /// The Ksi2.
        /// </value>
        public int Ksi2 { get; private set; }

        /// <summary>
        /// Gets the m.
        /// </summary>
        /// <value>
        /// The m.
        /// </value>
        public int M { get; private set; }

        /// <summary>
        /// Gets the alpha.
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public int Alpha { get; private set; }

        /// <summary>
        /// Gets the beta.
        /// </summary>
        /// <value>
        /// The beta.
        /// </value>
        public int Beta { get; private set; } 

        #endregion

        #region Fields

        /// <summary>
        /// The random
        /// </summary>
        private readonly Random random; 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FiatShamir"/> class.
        /// </summary>
        /// <param name="ksi1">The ksi1.</param>
        /// <param name="ksi2">The ksi2.</param>
        public FiatShamir(int ksi1, int ksi2)
        {
            Ksi1 = ksi1;
            Ksi2 = ksi2;

            random = new Random();
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates the signature.
        /// </summary>
        public void GenerateSignature()
        {
            M = Ksi1 * Ksi2;

            Alpha = random.Next(1, M - 1); //TODO: check this condition

            Beta = (int)Math.Pow(Alpha, 2) % M;

            var mu = Convert.ToString(Beta, 2);

            var hashResult = GetHash(mu);
        } 

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="mu">The mu.</param>
        /// <returns></returns>
        private String GetHash(String mu)
        {
            var hashResult = mu.Count(character => character == '1');

            return Convert.ToString(hashResult, 2);
        } 

        #endregion
    }
}
