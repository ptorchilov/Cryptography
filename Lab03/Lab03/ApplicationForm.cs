using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab03
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void ButtonEncodeClick(object sender, EventArgs e)
        {
            var filePath = TestFiles.TestFile1;

            var fileString = this.ReadFile(filePath);

            var frecuencyTable = this.CreateFrequencyTable(fileString);
        }

        private String ReadFile(String filePath)
        {
            var helper = new FileHelper();

            return helper.ReadFile(filePath);
        }

        private IDictionary<char, int> CreateFrequencyTable(String fileString)
        {
            var table = new FrequencyTable();

            table.CreateFrequencyTable(fileString);

            return table.SybmolsFrequency;
        }
    }
}
