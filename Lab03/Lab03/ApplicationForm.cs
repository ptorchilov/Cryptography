namespace Lab03
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class ApplicationForm : Form
    {
        private List<Coder> coders;

        private List<FrequencyTable> frequencies;

        private List<Compressor> compressors;

        private int i = 1;

        public ApplicationForm()
        {
            InitializeComponent();

            coders = new List<Coder>();
            frequencies = new List<FrequencyTable>();
            compressors = new List<Compressor>();
        }

        private void ButtonEncodeClick(object sender, EventArgs e)
        {
            var filePath = TestFiles.TestFile3;

            var fileString = ReadFile(filePath);

            textBoxSource.Text = fileString;

            var encodedText = fileString;
            
            while (true)
            {
                var frecuencyTable = CreateFrequencyTable(encodedText);
                frequencies.Add(frecuencyTable);

                var coder = new Coder();
                encodedText = Encode(coder, encodedText, frecuencyTable);
                coders.Add(coder);

                var newText = CompressText(encodedText);
                var newFrequencyTable = CreateFrequencyTable(newText);
                var newCoder = new Coder();
                var newEncodedText = Encode(newCoder, newText, newFrequencyTable);

                if (!IsTextCompressed(newEncodedText, encodedText))
                {
                    if (compressors.Count > 1)
                    {
                        compressors.RemoveAt(compressors.Count - 1);
                    }
                    break;
                }
                i++;
                encodedText = newText;
            }

            textBoxEncoded.Text = encodedText;

            ShowFrequencyTable(frequencies[0]);
        }

        private bool IsTextCompressed(String newText, String previousText)
        {
            if (newText.Length < previousText.Length)
            {
                return true;
            }

            return false;
        }

        private String CompressText(String encodedText)
        {
            var compressor = new Compressor();
            compressors.Add(compressor);
            
            return compressor.GetNewText(encodedText);
        }

        private void ButtonSendClick(object sender, EventArgs e)
        {
            if (coders != null)
            {
                textBoxDecoded.Text = Decode(textBoxEncoded.Text);
            }

            label2.Text = @"Байт до сжатия: " + textBoxDecoded.Text.Length * 8;
            label3.Text = @"Байт после сжатия: " + textBoxEncoded.Text.Length;
            label4.Text = @"Коэффициент сжатия: " + String.Format("{0:##0.00}", 
                100 - ((textBoxEncoded.Text.Length /
                ((double)textBoxDecoded.Text.Length * 8))) * 100) + @"%";
            label5.Text = @"Количество повторных сжатий: " + i;
        }

        private void ShowFrequencyTable(FrequencyTable table)
        {
            foreach (var symbol in table.SortedSymbols)
            {
                textBoxFrequency.Text += String.Concat("'", symbol, "' - ", 
                    table.SybmolsFrequency[symbol]);

                textBoxFrequency.Text += String.Concat(" - ", coders[0].CodesTable[symbol],
                    Environment.NewLine);
            }
        }

        private String Decode(String encodedText)
        {
            var result = encodedText;

            for (var i = coders.Count - 1; i >= 0; i--)
            {
                result = coders[i].Decode(result);

                if (i != 0)
                {
                    result = compressors[i - 1].DecompressText(result);
                }
            }

            return result;
        }

        private String Encode(Coder coder, String text, FrequencyTable table)
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
