#region

using Localization.AssetLocalization;
using Localization.TextLocalization;
using UnityEngine;

#endregion

namespace Localization.Languages.Australian
{
    public class AustralianLocalizationConfig : LocalizationConfiguration
    {
        public string LanguageID => "aust";

        /// <summary>
        /// Loads all necessary Scriptable Objects.
        /// </summary>
        public AustralianLocalizationConfig()
        {
            AssetPathBuilder = Resources.Load<AssetPathBuilder>("AssetPathBuilder");
            AssetPathBuilder.SetLanguage(LanguageID, "_word", "_sentence");
            LocalizationTable = Resources.Load<LocalizationTable>("LocalizationTable");
            WebRequestCreator = Resources.Load<WebRequestCreator>("WebRequestCreator/ServerAPI");
            WordDatabase = Resources.Load("AUST/WordDatabase_AUST") as IWordDatabase;
        }
    }
}