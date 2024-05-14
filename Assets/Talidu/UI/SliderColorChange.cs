#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace UI
{
    public class SliderColorChange : MonoBehaviour
    {
        [SerializeField] private Image FillImage;
        [SerializeField] private Gradient ColorGradient;

        private Slider slider;

        void OnEnable()
        {
            slider = GetComponent<Slider>();
            slider.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(slider.value);
        }

        void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        /// <summary>
        /// Set color of fill image based on the value of the <see cref="ColorGradient"/>
        /// </summary>
        /// <param name="value">new slider value</param>
        void OnValueChanged(float value)
        {
            FillImage.color = ColorGradient.Evaluate(value);
        }
    }
}