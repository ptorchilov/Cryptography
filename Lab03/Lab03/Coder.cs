namespace Lab03
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;

    /// <summary>
    /// Class for encode and decode text.
    /// </summary>
    public class Coder
    {
        private const String Separator = "10";

        public Dictionary<char, String> CodesTable { get; private set; }

        public Dictionary<String, char> SymbolsTable { get; private set; }

        public Coder()
        {
            CodesTable = new Dictionary<char, String>();
            SymbolsTable = new Dictionary<String, char>();
        }

        public void Encode(String text, FrequencyTable table)
        {
            var codes = this.GenerateCodes(table);


        }

        private IList<String> GenerateCodes(FrequencyTable table)
        {
            var codes = new List<String>();
            var number = 1;

            while (true)
            {
                for (var i = 0; i < Math.Pow(2, number); i++)
                {
                    var code = this.GetBinary(i, number);

                    if (IsValid(code))
                    {
                        codes.Add(code);
                    }

                    if (codes.Count >= table.SybmolsFrequency.Count)
                    {
                        break;
                    }
                }

                if (codes.Count >= table.SybmolsFrequency.Count)
                {
                    break;
                }

                number++;
            }

            return codes;
        }

        private bool IsValid(String code)
        {
            if (!code.Contains(Separator))
            {
                return true;
            }

            return false;
        }

        private String GetBinary(int value, int length)
        {
            var binary = Convert.ToString(value, 2);

            if (length > binary.Length)
            {
                return new String('0', length - binary.Length) + binary;
            }

            return binary;
        }
    }
}
