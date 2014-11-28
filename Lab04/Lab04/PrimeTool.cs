namespace Lab04
{
    /// <summary>
    /// Class for check prome of number.
    /// </summary>
    public static class PrimeTool
    {
        #region Public Methods

        /// <summary>
        /// Determines whether the specified candidate is prime.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns></returns>
        public static bool IsPrime(long candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (long i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        } 

        #endregion
    }
}