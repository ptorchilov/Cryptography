namespace Lab02
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for store and find keys.
    /// </summary>
    public class KeyTool
    {
        #region Properties

        /// <summary>
        /// Gets or sets the P param.
        /// </summary>
        /// <value>
        /// P param.
        /// </value>
        public static long P { get; set; }

        /// <summary>
        /// Gets or sets the A.
        /// </summary>
        /// <value>
        /// The A.
        /// </value>
        public int A { get; set; }

        /// <summary>
        /// Gets or sets the B.
        /// </summary>
        /// <value>
        /// The B.
        /// </value>
        public int B { get; set; }

        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public int Alpha { get; set; }

        /// <summary>
        /// Gets or sets the beta.
        /// </summary>
        /// <value>
        /// The beta.
        /// </value>
        public int Beta { get; set; }

        /// <summary>
        /// Gets or sets the m1.
        /// </summary>
        /// <value>
        /// The m1.
        /// </value>
        public int M1 { get; set; }

        /// <summary>
        /// Gets or sets the m2.
        /// </summary>
        /// <value>
        /// The m2.
        /// </value>
        public int M2 { get; set; }

        /// <summary>
        /// Gets or sets the m3.
        /// </summary>
        /// <value>
        /// The m3.
        /// </value>
        public int M3 { get; set; }

        /// <summary>
        /// Gets or sets the m4.
        /// </summary>
        /// <value>
        /// The m4.
        /// </value>
        public int M4 { get; set; } 

        #endregion

        #region Lists of params.

        /// <summary>
        /// The alpha, beta, A and B lists.
        /// </summary>
        public List<int> AlphaList, BetaList, AList, BList; 

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the lists.
        /// </summary>
        private void InitLists()
        {
            if (AlphaList == null)
            {
                AlphaList = new List<int>();
            }
            else
            {
                AlphaList.Clear();
            }

            if (BetaList == null)
            {
                BetaList = new List<int>();
            }
            else
            {
                BetaList.Clear();
            }

            if (AList == null)
            {
                AList = new List<int>();
            }
            else
            {
                AList.Clear();
            }

            if (BList == null)
            {
                BList = new List<int>();
            }
            else
            {
                BList.Clear();
            }
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds all keys.
        /// </summary>
        public void FindAllKeys()
        {
            InitLists();

            for (var alpha = 1; alpha < P - 1; alpha++)
            {
                for (var a = 1; a < P - 1; a++)
                {
                    if ((alpha * a) % (P - 1) == 1)
                    {
                        for (var beta = 1; beta < P - 1; beta++)
                        {
                            for (var b = 1; b < P - 1; b++)
                            {
                                if ((beta * b) % (P - 1) == 1 &&
                                    (alpha * a * beta * b) % (P - 1) == 1)
                                {
                                    AlphaList.Add(alpha);
                                    BetaList.Add(beta);
                                    AList.Add(a);
                                    BList.Add(b);
                                }
                            }
                        }
                    }
                }
            }
        } 

        #endregion
    }
}
