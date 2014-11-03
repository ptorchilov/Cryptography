namespace Lab03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for store letters frequency in text.
    /// </summary>
    public class FrequencyTable
    {
        public SortedDictionary<char, int> SybmolsFrequency { get; private set; }
        
        public FrequencyTable()
        {
            SybmolsFrequency = new SortedDictionary<char, int>();
        }

        public void CreateFrequencyTable(String source)
        {
            foreach (var sybmol in source)
            {
                if (SybmolsFrequency.Keys.Contains(sybmol))
                {
                    SybmolsFrequency[sybmol]++;
                }
                else
                {
                    SybmolsFrequency[sybmol] = 1;
                }
            }
        }
    }
}
