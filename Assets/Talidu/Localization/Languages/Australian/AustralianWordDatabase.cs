#region

using System.Collections.Generic;
using Localization.AssetLocalization;
using UnityEngine;

#endregion

namespace Localization.Languages.Australian
{
    /// <summary>ScriptableObject for parsing Words from CSV File</summary>
    [CreateAssetMenu(fileName = "AustralianWordDatabase",
        menuName = "ScriptableObjects/CsvFileParser/AustralianWordDatabase")]
    public class AustralianWordDatabase : WordDatabase<WordData, AustralianWord>
    {
        protected override List<WordData> ConvertWords(List<AustralianWord> words)
        {
            List<WordData> convertedWords = new List<WordData>();
            foreach (var word in words)
            {
                var w = new WordData();
                w.Word = word.word;
                w.Grapheme = word.graphemes.Replace(" ", "").Split(",");
                w.Levels = ConvertDifficulty(word.difficulty);
                convertedWords.Add(w);
            }

            return convertedWords;
        }

        protected override void LoadAllResources(List<WordData> words)
        {
            throw new System.NotImplementedException();
        }

        private string ConvertDifficulty(int wordDifficulty)
        {
            if (wordDifficulty <= 2) return "1";
            if (wordDifficulty < 4) return "12";
            if (wordDifficulty == 4) return "123";
            if (wordDifficulty == 5) return "234";
            if (wordDifficulty <= 7) return "34";
            return "4";
        }
    }
}