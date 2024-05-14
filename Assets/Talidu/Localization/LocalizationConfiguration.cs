#region

using Localization.AssetLocalization;
using Localization.TextLocalization;
using UnityEngine.Networking;

#endregion

namespace Localization
{
    /// <summary>
    /// Facade interface for different languages and their configurations
    /// </summary>
    public abstract class LocalizationConfiguration
    {
        /// <summary>
        /// ID for the current Language, e.g. "de" for german.
        /// </summary>
        public string LanguageID { get; }

        protected static IWordDatabase WordDatabase;
        protected static AssetPathBuilder AssetPathBuilder;
        protected static WebRequestCreator WebRequestCreator;
        protected static LocalizationTable LocalizationTable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string CreateWordAudioPath(string fileName)
        {
            return AssetPathBuilder.CreateWordAudioPath(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string CreateSentenceAudioPath(string fileName)
        {
            return AssetPathBuilder.CreateSentenceAudioPath(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string CreateImagePath(string fileName)
        {
            return AssetPathBuilder.CreateImagePath(fileName);
        }

        /// <summary>
        /// Returns <see cref="WordData"/> for the <paramref name="word"/>
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public WordData GetOfflineWordData(string word)
        {
            return WordDatabase.GetWord(word);
        }

        /// <summary>
        /// Returns the localized string with the specified <paramref name="id"/>
        /// </summary>
        /// <param name="id">ID of the string</param>
        /// <returns>Localized string</returns>
        public string GetLocalizedText(string id)
        {
            return LocalizationTable.GetLocalizedLine(id, LanguageID);
        }

        /// <summary>
        /// Requests and returns an <see cref="UnityWebRequest"/> for a localized audio path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public UnityWebRequest CreateAudioWebRequest(string path)
        {
            return WebRequestCreator.CreateAudioWebRequest(path);
        }

        /// <summary>
        /// Requests and returns an <see cref="UnityWebRequest"/> for a localized image path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public UnityWebRequest CreateImageWebRequest(string path)
        {
            return WebRequestCreator.CreateImageWebRequest(path);
        }
    }
}