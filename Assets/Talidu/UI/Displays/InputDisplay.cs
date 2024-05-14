#region

using EventSystem;
using TMPro;
using UnityEngine;

#endregion

namespace UI.Displays
{
    /// <summary>
    /// Updates the image for the current word. Listens to the <see cref="InputDisplayInfo"/>-Event.
    /// </summary>
    public class InputDisplay : VariableDisplay<InputDisplayInfo>
    {
        [SerializeField] private TextMeshProUGUI InputText;

        public override void OnEventRaised(InputDisplayInfo value)
        {
            InputText.SetText(string.Join("", value.Inputs));
        }
    }
}