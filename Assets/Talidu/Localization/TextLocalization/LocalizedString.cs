#region

using System;

#endregion

namespace Localization.TextLocalization
{
    /// <summary>
    /// Contains a translation of a key and defines it's language
    /// </summary>
    [Serializable]
    public class LocalizedString
    {
        /// <summary>
        /// 
        /// </summary>
        public string LocalizationLanguage;

        /// <summary>
        /// 
        /// </summary>
        public string Value;
    }
}