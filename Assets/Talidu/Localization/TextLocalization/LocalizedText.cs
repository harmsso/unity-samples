#region

using TMPro;
using UnityEngine;

#endregion

namespace Localization.TextLocalization
{
    /// <summary>
    /// Updates <see cref="TextMeshProUGUI"/> based on id to the correct localized text
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedText : MonoBehaviour
    {
        /// <summary>
        /// ID of the localized text in the <see cref="LocalizationProvider"/>
        /// </summary>
        [SerializeField] private string ID;

        private void Start()
        {
            var localizedLine = LocalizationProvider.LocalizationConfig.GetLocalizedText(ID);
            GetComponent<TextMeshProUGUI>().text = localizedLine;
        }
    }
}