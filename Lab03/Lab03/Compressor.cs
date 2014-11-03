namespace Lab03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for complress encoded text.
    /// </summary>
    public class Compressor
    {
        public Dictionary<char, String> SymbolsTable { get; private set; }

        public Dictionary<String, char> CodesTable { get; private set; }

        public int ExtraSymbols = 0;
    
        public Compressor()
        {
            SymbolsTable = new Dictionary<char, String>();
            CodesTable = new Dictionary<String, char>();
            CreateCodesTabel();
        }

        public String GetNewText(String encodedText)
        {
            var stringBuilder = new StringBuilder();

            encodedText = AlingText(encodedText);

            for (var i = 0; i < encodedText.Length; i += 5)
            {
                var code = encodedText.Substring(i, 5);
                var symbol = CodesTable[code];

                stringBuilder.Append(symbol);
            }

            return stringBuilder.ToString();
        }

        public String DecompressText(String text)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < text.Length; i++)
            {
                var code = SymbolsTable[text[i]];

                stringBuilder.Append(code);
            }

            stringBuilder.Remove(stringBuilder.Length - ExtraSymbols, ExtraSymbols);

            return stringBuilder.ToString();
        }

        private String AlingText(String encodedText)
        {
            var result = encodedText;
            var residue = encodedText.Length % 5;

            if (residue != 0)
            {
                for (var i = 0; i < 5 - residue; i++)
                {
                    result += "0";
                }
            }

            ExtraSymbols = 5 - residue;

            return result;
        }

        private void CreateCodesTabel()
        {
            var unicode = 'а';

            for (var i = 0; i < 32; i++)
            {
                var code = Convert.ToString(i, 2);

                var codeLength = code.Length;

                if (codeLength < 5)
                {
                    for (var j = 0; j < 5 - codeLength; j++)
                    {
                        code = "0" + code;
                    }
                }

                SymbolsTable.Add((char) (unicode + i), code);
                CodesTable.Add(code, (char) (unicode + i));
            }
        }
    }
}
