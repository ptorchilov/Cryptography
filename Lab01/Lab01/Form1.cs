using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab01
{
    using System.Diagnostics;

    public partial class ApplicationForm : Form
    {
        #region Constants

        /// <summary>
        /// The letters
        /// </summary>
        private List<String> letters = new List<String> { "М", "И", "Ц", "А", "Р", "Я", "Т", "У" };

        /// <summary>
        /// The words
        /// </summary>
        private List<String> words = new List<String>
                                         {
                                             "АРМИЯ",
                                             "МИЦАР",
                                             "МАРИЯ",
                                             "ТАРТУ",
                                             "РАЦИЯ",
                                             "МАРТА",
                                             "МАРАТ",
                                             "ТИАРА",
                                             "МИРТА",
                                             "УТЯТА",
                                             "ЦИТРА",
                                             "МУМИЯ",
                                             "ТРАТА",
                                             "ТАТРА",
                                             "АРТУР",
                                             "АРАМА",
                                             "ТИМУР"
                                         }; 

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationForm"/> class.
        /// </summary>
        public ApplicationForm()
        {
            InitializeComponent();
        } 

        #endregion

        #region Private Methods

        /// <summary>
        /// Buttons the encode click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonEncodeClick(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var message = new List<String>
                              {
                                  RevertString(textBox1.Text),
                                  RevertString(textBox2.Text),
                                  RevertString(textBox3.Text)
                              };

            var watch = new Stopwatch();
            watch.Start();

            var answers = Encoder.Encode(message, letters, words);

            if (answers.Count > 0)
            {
                foreach (var result in answers)
                {
                    var items = new List<String>();
                    var builder = new StringBuilder();

                    foreach (var word in result.Words)
                    {
                        builder.Append(word + "  ");
                    }

                    items.Add(result.Noise);
                    items.Add(builder.ToString());
                    items.Add(result.Alphabet.ToString());

                    listView1.Items.Add(new ListViewItem(items.ToArray()));
                }

                watch.Stop();
                label3.Text = @"Время работы: " + watch.Elapsed + @" секунд";
            }
            else
            {
                watch.Stop();
                MessageBox.Show(@"Соответствия не найдены");
            }
        }

        /// <summary>
        /// Reverts the string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Reverted word</returns>
        private String RevertString(String input)
        {
            var reverterChars = input.ToCharArray();

            Array.Reverse(reverterChars);

            return new string(reverterChars);
        } 

        #endregion
    }
}