namespace Lab03
{
    using System;
    using System.Windows.Forms;

    public partial class ApplicationForm : Form
    {
        private Coder coder;

        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void ButtonEncodeClick(object sender, EventArgs e)
        {
            var filePath = TestFiles.TestFile1;

            var fileString = this.ReadFile(filePath);

            textBoxSource.Text = fileString;

            var frecuencyTable = CreateFrequencyTable(fileString);

            coder = new Coder();

            textBoxEncoded.Text = Encode(fileString, frecuencyTable);

            ShowFrequencyTable(frecuencyTable);
        }

        private void ButtonSendClick(object sender, EventArgs e)
        {
            if (coder != null)
            {
                textBoxDecoded.Text = Decode(textBoxEncoded.Text);
            }
        }

        private void ShowFrequencyTable(FrequencyTable table)
        {
            foreach (var symbol in table.SortedSymbols)
            {
                textBoxFrequency.Text += String.Concat("'", symbol, "' - ", 
                    table.SybmolsFrequency[symbol]);

                textBoxFrequency.Text += String.Concat(" - ", coder.CodesTable[symbol],
                    Environment.NewLine);
            }
        }

        private String Decode(String encodedText)
        {
            return coder.Decode(encodedText);
        }

        private String Encode(String text, FrequencyTable table)
        {
            return coder.Encode(text, table);
        }

        private FrequencyTable CreateFrequencyTable(String fileString)
        {
            var table = new FrequencyTable();

            table.CreateFrequencyTable(fileString);

            return table;
        }

        private String ReadFile(String filePath)
        {
            var helper = new FileHelper();

            return helper.ReadFile(filePath);
        }
    }
}
