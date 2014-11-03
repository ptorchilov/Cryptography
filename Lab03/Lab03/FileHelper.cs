namespace Lab03
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Class for work with text files.
    /// </summary>
    public class FileHelper
    {
        public String ReadFile(String path)
        {
            var stringBuilder = new StringBuilder();

            using (var streamReader = new StreamReader(path, Encoding.Default))
            {
                var rawText = streamReader.ReadToEnd();

                foreach (var symbol in rawText)
                {
                    if ((symbol >= 'А' && symbol <= 'Я') || 
                        (symbol >= 'а' && symbol <= 'я'))
                    {
                        stringBuilder.Append(CorrectSymbol(symbol));
                    }
                }
            }

            return stringBuilder.ToString();
        }

        private char CorrectSymbol(char symbol)
        {
            switch (Char.ToLower(symbol))
            {
                case 'ё':
                {
                    return 'е';
                }
                case 'й':
                {
                    return 'и';
                }
                case 'ъ':
                {
                    return 'ь';
                }
                default :
                {
                    return symbol;
                }
            }
        }
    }
}
