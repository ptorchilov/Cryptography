namespace Lab04
{
    using System;
    using System.Collections.Generic;
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
        public long Ksi1 { get; private set; }

        /// <summary>
        /// Gets the Ksi2.
        /// </summary>
        /// <value>
        /// The Ksi2.
        /// </value>
        public long Ksi2 { get; private set; }

        /// <summary>
        /// Gets the m.
        /// </summary>
        /// <value>
        /// The m.
        /// </value>
        public long M { get; private set; }

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
        public long Beta { get; private set; }

        /// <summary>
        /// Gets the s.
        /// </summary>
        /// <value>
        /// The s.
        /// </value>
        public long S { get;  private set; }

        /// <summary>
        /// Gets a.
        /// </summary>
        /// <value>
        /// a.
        /// </value>
        public long[] A { get; private set; }

        /// <summary>
        /// Gets the t.
        /// </summary>
        /// <value>
        /// The t.
        /// </value>
        public long T { get; private set; }

        /// <summary>
        /// Gets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        public long[] B { get; private set; }

        /// <summary>
        /// Gets the forward.
        /// </summary>
        /// <value>
        /// The forward.
        /// </value>
        public long W { get; private set; }

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <value>
        /// The hash.
        /// </value>
        public long Hash { get; private set; }

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
        public FiatShamir(long ksi1, long ksi2)
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
        /// <returns></returns>
        public long[] GenerateSignature(String mu)
        {
            //1. Определяем модуль сравнения на основе Кси1 и Кси2
            M = Ksi1 * Ksi2;

            //2. Выбираем случайное число 0 < Alpha <= M - 1
            Alpha = random.Next(1, (int) M);

            //3. Вычисляем Beta = Alpha ^ 2 (mod M)
            Beta = (long) Math.Pow(Alpha, 2) % M;

            //4. Вычисляем хэш функцию для сообщения Mu (секретный ключ S)
            S = GetHashFunction(mu, Beta);

            var hashBinary = Convert.ToString(S, 2);

            //5. Выбираем случайные числа A взаимнопростые с M
            A = GetANumbers(hashBinary.Length);

            //6. Вычисляем занчение секретного ключа T
            T = GetTKey(Alpha, A, hashBinary);

            //7. Вычисляем значения открытых ключей B
            B = GetBKeys(A);

            return new[] { S, T };
        }

        /// <summary>
        /// Validates the signature.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="mu">The mu.</param>
        /// <returns></returns>
        public bool ValidateSignature(long[] keys, String mu)
        {
            //1. Определяем параметр w
            W = GetWParam(keys[0], keys[1], B);

            //2. Вычисляем хэш функцию для Mu
            Hash = GetHashFunction(mu, W);

            //3. Проверяем эквивалентность значений
            return Hash == keys[0];
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the forward parameter.
        /// </summary>
        /// <param name="s">The arguments.</param>
        /// <param name="t">The attribute.</param>
        /// <param name="b">The attribute.</param>
        /// <returns></returns>
        private int GetWParam(long s, long t, long[] b)
        {
            var sBinary = Convert.ToString(s, 2);
            long w = t * t;

            for (var i = 0; i < sBinary.Length; i++)
            {
                if (sBinary[i] == '1')
                {
                    w *= b[i];
                }
            }

            return (int) (w % M);
        }

        /// <summary>
        /// Gets the attribute keys.
        /// </summary>
        /// <param name="a">The aggregate.</param>
        /// <returns></returns>
        private long[] GetBKeys(long[] a)
        {
            var b = new long[a.Length];

            for (var i = 0; i < a.Length; i++)
            {
                var value = a[i] * a[i];

                b[i] = GetB(value);
            }

            return b;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="divider">The divider.</param>
        /// <returns></returns>
        private long GetB(long divider)
        {
            var quotients = new List<long>();
            var dividend = M;

            while (divider != 0)
            {
                var quotient = dividend / divider;

                quotients.Add(quotient);

                var temp = dividend;
                dividend = divider;
                divider = temp - (quotient * divider);
            }

            var ps = new List<long>();

            var ps0 = 1;
            ps.Add(ps0);

            var ps1 = quotients[0] * ps[0];  
            ps.Add(ps1);

            for (var i = 1; i < quotients.Count; i++)
            {
                var pi = ps[i] * quotients[i] + ps[i - 1];
                ps.Add(pi);
            }

            var x = Convert.ToInt64(Math.Pow(-1, quotients.Count - 1));

            x *= ps[ps.Count - 2];

            if (x < 0)
            {
                x += M;
            }

            return x;
        }

        /// <summary>
        /// Gets the t key.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="a">a.</param>
        /// <param name="hashBinary">The hash binary.</param>
        /// <returns>T value.</returns>
        private long GetTKey(long alpha, long[] a, String hashBinary)
        {
           var t = alpha;

            for (var i = 0; i < hashBinary.Length; i++)
            {
                if (hashBinary[i] == '1')
                {
                    t *= a[i];
                }
            }

            return t % M;
        }

        /// <summary>
        /// Gets a numbers.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        private long[] GetANumbers(int length)
        {
            var result = new long[length];
            var candidates = new List<int>();

            for (var i = 2; i < M; i++)
            {
                if (GetGreatestCommonDivisor(i, M) == 1)
                {
                    candidates.Add(i);
                }
            }

            if (candidates.Count < length)
            {
                throw new ArgumentException("Недостаточно взаимно простых чисел.");
            }

            for (var i = 0; i < length; i++)
            {
                var index = random.Next(0, candidates.Count);

                result[i] = candidates[index];
                candidates.RemoveAt(index);
            }

            return result.OrderBy(x => x).ToArray();
        }

        /// <summary>
        /// Gets the hash function.
        /// </summary>
        /// <param name="mu">The mu.</param>
        /// <param name="beta">The beta.</param>
        /// <returns></returns>
        private long GetHashFunction(String mu, long beta)
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
        private long GetHash(String mu)
        {
            var hashResult = mu.Count(character => character == '1');

            return hashResult;
        }

        /// <summary>
        /// Gets the greatest common divisor.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>GCD</returns>
        private long GetGreatestCommonDivisor(long a, long b)
        {
            return b == 0 ? a : GetGreatestCommonDivisor(b, a % b) ;
        }

        #endregion
    }
}
