using System;
using System.Windows.Forms;

namespace Lab02
{
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// Main form class.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Public Methods.
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        } 
        #endregion

        #region Private Methods.

        #region Button click events.

        /// <summary>
        /// Button1s the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button1Click(object sender, EventArgs e)
        {
            if (this.ValidateP(textBox3.Text) && this.ValidateInput(textBox4.Text))
            {
                int a, b;

                if (Int32.TryParse(textBox1.Text, out a) &&
                    Int32.TryParse(textBox2.Text, out b))
                {
                    var keys = new KeyTool { A = a, B = b };
                    var transceiver = new Transceiver(keys);

                    var result = transceiver.Send(textBox4.Text);

                    if (result != null && this.ValidateParams(result))
                    {
                        label8.Text = @"Alpha = " + result.Alpha;
                        label9.Text = @"Beta = " + result.Beta;

                        textBox7.Text = result.M4.ToString(CultureInfo.InvariantCulture);

                        var watch = new Stopwatch();
                        watch.Start();

                        keys.FindAllKeys();

                        this.ShowAllKeys(keys);

                        watch.Stop();
                        label10.Text = @"Время работы: " + watch.Elapsed + @" секунд";

                        MessageBox.Show(@"Завершено.");
                    }
                }
            }
        }

        /// <summary>
        /// Button2s the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button2Click(object sender, EventArgs e)
        {
            if (this.ValidateP(textBox3.Text) && this.ValidateInput(textBox6.Text))
            {
                int a, b;

                if (Int32.TryParse(textBox1.Text, out a) &&
                    Int32.TryParse(textBox2.Text, out b))
                {
                    var keys = new KeyTool { A = a, B = b };
                    var transceiver = new Transceiver(keys);

                    var result = transceiver.Send(textBox6.Text);

                    if (result != null && this.ValidateParams(result))
                    {
                        label8.Text = @"Alpha = " + result.Alpha;
                        label9.Text = @"Beta = " + result.Beta;

                        textBox5.Text = result.M4.ToString(CultureInfo.InvariantCulture);

                        var watch = new Stopwatch();
                        watch.Start();

                        keys.FindAllKeys();

                        this.ShowAllKeys(keys);

                        watch.Stop();
                        label10.Text = @"Время работы:\n" + watch.Elapsed + @" секунд";

                        MessageBox.Show(@"Завершено.");
                    }
                }
            }
        }

        #endregion

        #region Output.

        /// <summary>
        /// Shows all keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        private void ShowAllKeys(KeyTool keys)
        {
            textBox8.Clear();
            textBox8.Text += @"№	Alpha	A	Beta	B	M1	M2	M3	M4" + Environment.NewLine;

            for (var i = 0; i < keys.AList.Count; i++)
            {
                int m1, m2, m3, m4;

                if (radioButton1.Checked)
                {
                    m3 = Transceiver.Pow(keys.M2, keys.AlphaList[i], KeyTool.P);
                    m4 = Transceiver.Pow(m3, keys.BetaList[i], KeyTool.P);
                    m1 = Transceiver.Pow(m4, keys.AList[i], KeyTool.P);
                    m2 = Transceiver.Pow(m1, keys.BList[i], KeyTool.P);
                }
                else
                {
                    m4 = Transceiver.Pow(keys.M3, keys.BetaList[i], KeyTool.P);
                    m1 = Transceiver.Pow(m4, keys.AList[i], KeyTool.P);
                    m2 = Transceiver.Pow(m1, keys.BList[i], KeyTool.P);
                    m3 = Transceiver.Pow(m2, keys.AlphaList[i], KeyTool.P);
                }

                textBox8.Text += String.Format(
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
                    i + 1,
                    keys.AlphaList[i],
                    keys.AList[i],
                    keys.BetaList[i],
                    keys.BList[i],
                    m1,
                    m2,
                    m3,
                    m4,
                    Environment.NewLine);
            }
        }

        #endregion

        #region Validators.

        /// <summary>
        /// Validates the parameters.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        private bool ValidateParams(KeyTool keys)
        {
            if (keys.Alpha == 0)
            {
                MessageBox.Show(@"Некорректный параметр Alpha.");

                return false;
            }

            if (keys.Beta == 0)
            {
                MessageBox.Show(@"Некорректный параметр Beta.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the application.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private bool ValidateP(String value)
        {
            long p;

            if (Int64.TryParse(value, out p))
            {
                if (p > 0 && PrimeTool.IsPrime(p))
                {
                    KeyTool.P = p;

                    return true;
                }
            }

            MessageBox.Show(@"Некорректный параметр P.");

            return false;
        }

        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private bool ValidateInput(String value)
        {
            int i;

            if (Int32.TryParse(value, out i))
            {
                if (i >= KeyTool.P)
                {


                    MessageBox.Show(@"Значение должно быть < " + KeyTool.P);

                    return false;
                }

                return true;
            }

            MessageBox.Show(@"Некорректный параметр ввода.");

            return false;
        }

        #endregion 

        #endregion
    }
}