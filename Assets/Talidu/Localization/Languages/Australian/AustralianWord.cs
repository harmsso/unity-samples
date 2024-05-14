#region

using System;

#endregion

namespace Localization.Languages.Australian
{
    /// <summary>
    /// Data container for words from english csvFile. Member variable names must be equal to the column names.
    /// </summary>
    [Serializable]
    public struct AustralianWord
    {
        public string word;
        public string graphemes;
        public int difficulty;
    }
}