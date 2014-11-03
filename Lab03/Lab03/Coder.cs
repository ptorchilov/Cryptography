namespace Lab03
{
    using System;
    using System.Collections.Generic;

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
    }
}
