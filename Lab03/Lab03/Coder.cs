namespace Lab03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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

        public String Encode(String text, FrequencyTable table)
        {
            var codes = GenerateCodes(table);
            var symbolsFrequency = table.SortedSymbols;

            FillTables(symbolsFrequency, codes);

            var stringBuiler = new StringBuilder();

            foreach (var symbol in text)
            {
                stringBuiler.Append(CodesTable[symbol]);
                stringBuiler.Append(Separator);
            }

            stringBuiler.Remove(stringBuiler.Length - Separator.Length, Separator.Length);

            return stringBuiler.ToString();
        }

        public String Decode(String encodedText)
        {
            var stringBuilder = new StringBuilder();

            var symbols = encodedText.Split(new[] { Separator }, StringSplitOptions.None);

            foreach (var symbol in symbols)
            {
                if (SymbolsTable.ContainsKey(symbol))
                {
                    stringBuilder.Append(SymbolsTable[symbol]);
                }
            }

            return stringBuilder.ToString();
        }

        private void FillTables(IList<char> symbolsFrequency, IList<String> codes)
        {
            for (var i = 0; i < codes.Count; i++)
            {
                CodesTable.Add(symbolsFrequency[i], codes[i]);
                SymbolsTable.Add(codes[i], symbolsFrequency[i]);
            }
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
