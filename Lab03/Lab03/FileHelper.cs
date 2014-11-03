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

            using (var streamReader = new StreamReader(path))
            {
                var rawText = streamReader.ReadToEnd();

                foreach (var symbol in rawText)
                {
                    if ((symbol >= 'А' && symbol <= 'Я') || 
                        (symbol >= 'а' && symbol <= 'я'))
                    {
                        stringBuilder.Append(Char.ToLower(symbol));
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
