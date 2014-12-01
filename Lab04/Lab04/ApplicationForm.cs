namespace Lab04
{
    using System;
    using System.Resources;
    using System.Windows.Forms;

    /// <summary>
    /// Class for application form.
    /// </summary>
    public partial class ApplicationForm : Form
    {
        private ResourceManager resourceManager;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationForm"/> class.
        /// </summary>
        public ApplicationForm()
        {
            InitializeComponent();
        } 

        #endregion

        #region Input Validators

        private bool ValidateKsiValue(String value)
        {
            int result;

            if (Int32.TryParse(value, out result))
            {
                
            }

            return ResourceManager.Get;
        }

        #endregion
    }
}
