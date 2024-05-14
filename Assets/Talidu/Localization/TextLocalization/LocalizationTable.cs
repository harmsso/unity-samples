#region

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace Localization.TextLocalization
{
    /// <summary>
    /// Looks up translations
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/LocalizationTable", fileName = "LocalizationTable")]
    public class LocalizationTable : ScriptableObject
    {
        [SerializeField] private TextAsset CsvFile;

        /// <summary>
        /// Contains Localizations
        /// </summary>
        [SerializeField] private List<LocalizationContainer> _localizationTable = new List<LocalizationContainer>();

        /// <summary>
        /// Parses csv file and fills the table
        /// </summary>
        public void UpdateTable()
        {
            _localizationTable.Clear();
            var content = CsvFile.text;
            var splitByNewLine = SplitByNewLine(content);

            FillLocalizationTable(splitByNewLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="localizationLanguage"></param>
        /// <returns></returns>
        public string GetLocalizedLine(string line, string localizationLanguage)
        {
            var entry = _localizationTable.FirstOrDefault(e => e.Key == line);

            if (entry != null)
            {
                return entry.Localizations.First(language => language.LocalizationLanguage == localizationLanguage)
                    .Value;
            }

            Debug.LogWarning($"No translation found for {line} Language: {localizationLanguage.ToString()}");
            return line;
        }

        #region private

        private void FillLocalizationTable(string[] splitByNewLine)
        {
            for (int i = 1; i <= splitByNewLine.Length - 1; i++)
            {
                var localizationContainer = CreateLocalizationTableEntry(splitByNewLine[i]);
                if (localizationContainer != null)
                    _localizationTable.Add(localizationContainer);
            }
        }

        private static string[] SplitByNewLine(string line)
        {
            return line.Split(new[] { "\n" }, StringSplitOptions.None);
        }

        private LocalizationContainer CreateLocalizationTableEntry(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            LocalizationContainer localizationContainer = new LocalizationContainer();

            var splitBySemicolon = SplitByTabulator(line);

            ExtractTranslations(splitBySemicolon, localizationContainer);

            return localizationContainer;
        }

        private static string[] SplitByTabulator(string line)
        {
            return line.Split(new string[] { "\t" }, StringSplitOptions.None);
        }

        private static void ExtractTranslations(string[] splitBySemicolon,
            LocalizationContainer localizationContainer)
        {
            for (int i = 0; i <= splitBySemicolon.Length - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(splitBySemicolon[i])) continue;
                if (i == 0) localizationContainer.Key = splitBySemicolon[0];
                localizationContainer.Localizations.Add(new LocalizedString
                {
                    Value = splitBySemicolon[i],
                    LocalizationLanguage = i.ToString()
                });
            }
        }

        #endregion
    }
}