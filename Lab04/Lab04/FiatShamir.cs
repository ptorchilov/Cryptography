namespace Lab04
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

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

        public int[] A { get; private set; }

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
        /// <param name="mu">The message.</param>
        public void GenerateSignature(String mu)
        {
            //1. Определяем модуль сравнения на основе Кси1 и Кси2
            M = Ksi1 * Ksi2;

            //2. Выбираем случайное число 0 < Alpha <= M -1
            Alpha = random.Next(1, M);

            //3. Вычисляем Beta = Alpha ^ 2 (mod M)
            Beta = (int)Math.Pow(Alpha, 2) % M;

            //4. Вычисляем хэш функцию для сообщения Mu
            var hashResult = GetHashFunction(mu, Beta);

            A = new int[hashResult.Length];
        } 

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the hash function.
        /// </summary>
        /// <param name="mu">The mu.</param>
        /// <param name="beta">The beta.</param>
        /// <returns></returns>
        private String GetHashFunction(String mu, int beta)
        {
            var coder = new Coder();

            var formattedMsg = coder.FormatMessage(mu);

            var codedMsg = coder.CodeMessage(formattedMsg);

            var betaBinary = Convert.ToString(beta, 2);

            while (betaBinary.Length < Coder.CodeLength)
            {
                betaBinary = "0" + betaBinary;
            }

            return GetHash(codedMsg + betaBinary);
        }

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

        /// <summary>
        /// Gets the greatest common divisor.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>GCD</returns>
        private int GetGreatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : GetGreatestCommonDivisor(b, a % b) ;
        }

//        private int[] GetAParams(int length)
//        {
//            for (var i = 0; i < length; i++)
//            {
//                
//            }
//        }

        #endregion
    }
}
