#region

using System.Collections.Generic;
using Localization.AssetLocalization;
using UnityEngine;

#endregion

namespace Localization.Languages.German
{
    /// <summary>ScriptableObject for parsing Words from CSV File</summary>
    [CreateAssetMenu(fileName = "GermanWordDatabase", menuName = "ScriptableObjects/CsvFileParser/GermanWordDatabase")]
    public class GermanWordDatabase : WordDatabase<GermanWordData, GermanWord>
    {
        protected override List<GermanWordData> ConvertWords(List<GermanWord> words)
        {
            List<GermanWordData> convertedWords = new List<GermanWordData>();
            foreach (var word in words)
            {
                GermanWordData newWord = new GermanWordData
                {
                    Word = word.Wort,
                    Artikel = word.Artikel,
                    Sentence = word.Satz,
                    Grapheme = word.Grapheme.Split(","),
                    Errors = word.errors,
                    Levels = word.Jahrgangsstufe
                };
                convertedWords.Add(newWord);
            }

            return convertedWords;
        }

        protected override void LoadAllResources(List<GermanWordData> words)
        {
            foreach (var wordData in words)
            {
                var convertedWord = wordData.Word.Replace("ü", "ue").Replace("ö", "oe").Replace("ä", "ae")
                    .Replace("ß", "ss");
                wordData.WordAudio = Resources.Load<AudioClip>($"Audios/{convertedWord}_Wort");
                wordData.SentenceAudio = Resources.Load<AudioClip>($"Audios/{convertedWord}_Satz");
                wordData.Texture = Resources.Load<Texture>($"Images/Words/{convertedWord}");
            }
        }
    }
}