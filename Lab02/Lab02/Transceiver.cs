namespace Lab02
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Class for send messages.
    /// </summary>
    public class Transceiver
    {
        #region Fields.

        /// <summary>
        /// The keys
        /// </summary>
        private readonly KeyTool keys; 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Transceiver"/> class.
        /// </summary>
        /// <param name="keys">The keys.</param>
        public Transceiver(KeyTool keys)
        {
            this.keys = keys;
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public KeyTool Send(String message)
        {
            int value;

            FindAlpha();
            FindBeta();

            if (Int32.TryParse(message, out value))
            {
                keys.M1 = Pow(value, keys.A, KeyTool.P);

                keys.M2 = Pow(keys.M1, keys.B, KeyTool.P);

                keys.M3 = Pow(keys.M2, keys.Alpha, KeyTool.P);

                keys.M4 = Pow(keys.M3, keys.Beta, KeyTool.P);

                return keys;
            }

            return null;
        }

        /// <summary>
        /// Pows the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="p">P.</param>
        /// <returns></returns>
        public static int Pow(long value, int param, long p)
        {
            var pow = BigInteger.Pow(value, param);

            var result = BigInteger.Divide(pow, new BigInteger(p));

            result = BigInteger.Multiply(result, new BigInteger(p));
            result = BigInteger.Subtract(pow, result);

            return Int32.Parse(result.ToString());
        } 

        #endregion

        #region Finds params.

        /// <summary>
        /// Finds the alpha.
        /// </summary>
        private void FindAlpha()
        {
            for (var i = 1; i < KeyTool.P; i++)
            {
                if ((keys.A * i) % (KeyTool.P - 1) == 1)
                {
                    keys.Alpha = i;

                    break;
                }
            }
        }

        /// <summary>
        /// Finds the beta.
        /// </summary>
        private void FindBeta()
        {
            for (var i = 1; i < KeyTool.P; i++)
            {
                if ((keys.B * i) % (KeyTool.P - 1) == 1)
                {
                    keys.Beta = i;

                    break;
                }
            }
        } 

        #endregion
    }
}