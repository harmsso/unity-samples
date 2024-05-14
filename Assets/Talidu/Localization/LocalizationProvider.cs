#region

using Localization.Languages.Australian;
using Localization.Languages.German;
using UnityEngine;

#endregion

namespace Localization
{
    /// <summary>
    /// Singleton used for accessing the current <see cref="LocalizationConfig"/>.
    /// </summary>
    public class LocalizationProvider : MonoBehaviour
    {
        /// <summary>
        /// Returns an instance of <see cref="LocalizationConfig"/>
        /// </summary>
        public static LocalizationConfiguration LocalizationConfig
        {
            get
            {
                if (_languageConfiguration == null)
                    LoadLanguageConfig("de");
                return _languageConfiguration;
            }
        }

        private static LocalizationConfiguration _languageConfiguration;

        /// <summary>
        /// Load the needed LanguageConfig for the specified <paramref name="languageType"/>
        /// </summary>
        /// <param name="languageType"></param>
        public static void LoadLanguageConfig(string languageType)
        {
            if (languageType == "de")
                _languageConfiguration = new GermanLocalizationConfig();
            if (languageType == "aust")
                _languageConfiguration = new AustralianLocalizationConfig();
        }
    }
}