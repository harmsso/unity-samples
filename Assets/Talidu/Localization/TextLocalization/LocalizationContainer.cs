#region

using System;
using System.Collections.Generic;

#endregion

namespace Localization.TextLocalization
{
    /// <summary>
    /// Contains a never changing key in the base language and localizations for this key
    /// </summary>
    [Serializable]
    public class LocalizationContainer
    {
        /// <summary>
        /// Is in the base language and never changed, so the ILocalizable can be identified even, if the current language changed
        /// </summary>
        public string Key;

        /// <summary>
        /// Contains translations for the key
        /// </summary>
        public List<LocalizedString> Localizations = new List<LocalizedString>();
    }
}