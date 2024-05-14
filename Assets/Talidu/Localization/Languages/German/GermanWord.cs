#region

using System;

#endregion

namespace Localization.Languages.German
{
    /// <summary>Data container for words from csvFile. Member variable names must be equal to the column names in the csv file.</summary>
    [Serializable]
    public struct GermanWord
    {
        public string Jahrgangsstufe;
        public string Wort;
        public string Artikel;
        public string Grapheme;
        public string Satz;
        public string errors;
    }
}