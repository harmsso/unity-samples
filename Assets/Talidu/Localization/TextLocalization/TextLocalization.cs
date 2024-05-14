#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace Localization.TextLocalization
{
    /// <summary>
    /// API for getting the localization of an <see cref="ILocalizable"/> from a <see cref="LocalizationTable"/>. By <see cref="AddLocalizable"/> or <see cref="RemoveLocalizable"/> the <see cref="ILocalizable"/> signs in to the service.
    /// Sets the current language.
    /// </summary>
    public class TextLocalization : MonoBehaviour
    {
        [SerializeField] private string Language;

        /// <summary>
        /// 
        /// </summary>
        private static string CurrentLanguage = "de";

        /// <summary>
        /// 
        /// </summary>
        public static LocalizationLanguageEvent ChangeLanguageEvent = new LocalizationLanguageEvent();

        /// <summary>
        /// 
        /// </summary>
        public static LocalizationUnityEvent ChangeLanguageOfLocalizable =
            new LocalizationUnityEvent();

        private static LocalizationTable _localizationTable;

        private static readonly List<ILocalizable> _localizables = new List<ILocalizable>();

        /// <summary>
        /// 
        /// </summary>
        public void Awake()
        {
            ChangeLanguageEvent.AddListener(OnLanguageChanged);
            ChangeLanguageOfLocalizable.AddListener(LocalizeLocalizable);
            CurrentLanguage = Language;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            UpdateTexts();
        }

        /// <summary>
        /// Sets the LocalizationTable that is used for providing localizations
        /// </summary>
        public static void InitializeLocalizationTable(LocalizationTable localizationTable)
        {
            _localizationTable = localizationTable;
        }

        /// <summary>
        /// Adds ILocalizable to the List of ILocalizables
        /// </summary>
        public static void AddLocalizable(ILocalizable localizable)
        {
            _localizables.Add(localizable);
        }

        /// <summary>
        /// Removes ILocalizable to the List of ILocalizables
        /// </summary>
        public static void RemoveLocalizable(ILocalizable localizable)
        {
            _localizables.Remove(localizable);
        }

        private static void UpdateTexts()
        {
            foreach (var localizable in _localizables)
            {
                LocalizeLocalizable(localizable);
            }
        }

        private void OnLanguageChanged(string localizationLanguage)
        {
            if (CurrentLanguage == localizationLanguage) return;
            CurrentLanguage = localizationLanguage;
            UpdateTexts();
        }

        private static void LocalizeLocalizable(ILocalizable localizable)
        {
            var localized = GetLocalizedLineFromTable(localizable);
            localizable.Localize(localized);
        }

        private static string GetLocalizedLineFromTable(ILocalizable localizable)
        {
            var line = localizable.GetLineToLocalize();
            string localized = _localizationTable.GetLocalizedLine(line, CurrentLanguage);
            return localized;
        }
    }
}