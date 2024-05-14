#region

using Localization.AssetLocalization;
using Localization.TextLocalization;
using UnityEngine;

#endregion

namespace Localization.Languages.German
{
    /// <summary>
    /// This config is used as a facade for all the underlying objects needed.
    /// </summary>
    public class GermanLocalizationConfig : LocalizationConfiguration
    {
        /// <summary>
        /// Determines the language.
        /// </summary>
        public string LanguageID => "de";

        /// <summary>
        /// Loads all necessary Scriptable Objects.
        /// </summary>
        public GermanLocalizationConfig()
        {
            AssetPathBuilder = Resources.Load<AssetPathBuilder>("AssetPathBuilder");
            AssetPathBuilder.SetLanguage(LanguageID, "_Wort", "_Satz");
            LocalizationTable = Resources.Load<LocalizationTable>("LocalizationTable");
            WebRequestCreator = Resources.Load<WebRequestCreator>("WebRequestCreator/ServerAPI");
            WordDatabase = Resources.Load("DE/WordDatabase_DE") as IWordDatabase;
        }
    }
}