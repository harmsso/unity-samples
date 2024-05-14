#region

using UnityEngine;

#endregion

namespace Localization.AssetLocalization
{
    /// <summary>
    /// Saves path names and builds asset path strings.
    /// These assets are stored on the file server.
    /// </summary>
    [CreateAssetMenu(fileName = "AssetPathBuilder", menuName = "PathBuilders/AssetPathBuilder")]
    public class AssetPathBuilder : ScriptableObject
    {
        private const string FileServerURL = "https://files.foobar.net";
        private const string Images = "/images";
        private const string WordAudio = "/words";
        private const string SentenceAudio = "/sentences";
        private string wordSuffix = "";
        private string sentenceSuffix = "";
        private string imageSuffix = "";

        private string language;

        public void SetLanguage(string languageAbbreviation, string wordSuffix = "", string sentenceSuffix = "",
            string imageSuffix = "")
        {
            language = $"/{languageAbbreviation}";
            this.wordSuffix = wordSuffix;
            this.sentenceSuffix = sentenceSuffix;
            this.imageSuffix = imageSuffix;
        }

        /// <summary>
        /// Creates the localized word audio path for
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns></returns>
        public string CreateWordAudioPath(string fileName)
        {
            return $"{FileServerURL}{WordAudio}{language}/{fileName}{wordSuffix}.mp3";
        }

        /// <summary>
        /// Creates the localized word audio path for the example sentence
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns></returns>
        public string CreateSentenceAudioPath(string fileName)
        {
            return $"{FileServerURL}{SentenceAudio}{language}/{fileName}{sentenceSuffix}.mp3";
        }

        /// <summary>
        /// Creates the localized image path
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns></returns>
        public string CreateImagePath(string fileName)
        {
            return $"{FileServerURL}{Images}{language}/{fileName}{imageSuffix}.png";
        }
    }
}