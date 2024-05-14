#region

using System;
using EventSystem;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace UI.Displays
{
    /// <summary>
    /// Updates the image for the current word. Listens to the <see cref="ImageEventInfo"/>-Event.
    /// </summary>
    [Serializable]
    [RequireComponent(typeof(RawImage))]
    public class ImageDisplay : VariableDisplay<ImageEventInfo>
    {
        private RawImage image;
        private Texture texture;

        protected override void OnAwake()
        {
            image = GetComponent<RawImage>();
            if (texture != null) image.texture = texture;
        }

        public override void OnEventRaised(ImageEventInfo value)
        {
            texture = value.Texture;
            image.texture = value.Texture;
        }

        private void OnEnable()
        {
            if (texture != null) image.texture = texture;
        }
    }
}