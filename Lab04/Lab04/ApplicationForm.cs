namespace Lab04
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class for application form.
    /// </summary>
    public partial class ApplicationForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationForm"/> class.
        /// </summary>
        public ApplicationForm()
        {
            InitializeComponent();
        } 

        #endregion

        #region Test Params

        private String message = "Тестовое сообщение.";

        private int Ksi1 = 3;

        private int Ksi2 = 41;

        #endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            var fiatShamir = new FiatShamir(Ksi1, Ksi2);

            fiatShamir.GenerateSignature(message);


        }
    }
}
