#region

using System.Collections.Generic;
using System.Linq;
using CSVFileParser;
using UnityEngine;

#endregion

namespace Localization.AssetLocalization
{
    /// <summary>ScriptableObject for parsing Words from CSV File</summary>
    [CreateAssetMenu(fileName = "WordDatabase", menuName = "ScriptableObjects/WordDatabase")]
    public abstract class WordDatabase<TWordData, TCsvData> : ScriptableObject, IWordDatabase where TWordData : WordData
    {
        [SerializeField] private TextAsset CsvFile;
        [SerializeField] private List<TCsvData> Words = new List<TCsvData>();
        [SerializeField] private List<TWordData> WordsResult = new List<TWordData>();
        [SerializeField] private List<string> WordsEasy = new List<string>();
        [SerializeField] private List<string> WordsNormal = new List<string>();
        [SerializeField] private List<string> WordsAdvanced = new List<string>();
        [SerializeField] private List<string> WordsHard = new List<string>();

        private void OnValidate()
        {
            ReadCsvFile();
        }

        public void ReadCsvFile()
        {
            ClearAllLists();
            ParseCsvFile();
            LoadAllResources(WordsResult);
            FillDifficultyLists();
            Words.Clear();
        }

        /// <summary>
        /// Returns a random word with random difficulty.
        /// </summary>
        /// <returns></returns>
        public WordData GetRandomWord()
        {
            return GetRandomWord(Random.Range(0, 4));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public WordData GetWord(string word)
        {
            return WordsResult.FirstOrDefault(w => w.Word == word);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="difficultyLevel"></param>
        /// <returns></returns>
        public WordData GetRandomWord(int difficultyLevel)
        {
            var word = "";
            switch (difficultyLevel)
            {
                case 0:
                    word = WordsEasy[Random.Range(0, WordsEasy.Count - 1)];
                    break;
                case 1:
                    word = WordsNormal[Random.Range(0, WordsNormal.Count - 1)];
                    break;
                case 2:
                    word = WordsAdvanced[Random.Range(0, WordsAdvanced.Count - 1)];
                    break;
                case 3:
                    word = WordsHard[Random.Range(0, WordsHard.Count - 1)];
                    break;
                default:
                    Debug.LogError("Invalid difficulty: " + difficultyLevel);
                    word = WordsEasy[Random.Range(0, WordsEasy.Count - 1)];
                    break;
            }

            return WordsResult.FirstOrDefault(w => w.Word == word);
        }

        #region private

        private void ClearAllLists()
        {
            Words.Clear();
            WordsResult.Clear();
            WordsEasy.Clear();
            WordsNormal.Clear();
            WordsAdvanced.Clear();
            WordsHard.Clear();
        }

        private void ParseCsvFile()
        {
            Words = CSVSerializer.Deserialize<TCsvData>(CsvFile.text, ';').ToList();

            WordsResult = ConvertWords(Words);
        }

        protected abstract List<TWordData> ConvertWords(List<TCsvData> words);
        protected abstract void LoadAllResources(List<TWordData> words);

        private void FillDifficultyLists()
        {
            foreach (var word in WordsResult)
            {
                if (word.Levels.Contains("1")) WordsEasy.Add(word.Word);
                if (word.Levels.Contains("2")) WordsNormal.Add(word.Word);
                if (word.Levels.Contains("3")) WordsAdvanced.Add(word.Word);
                if (word.Levels.Contains("4")) WordsHard.Add(word.Word);
            }
        }

        #endregion
    }
}