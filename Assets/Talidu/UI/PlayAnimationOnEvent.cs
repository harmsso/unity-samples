#region

using System.Collections;
using UnityEngine;

#endregion

namespace UI
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Animation))]
    public class PlayAnimationOnEvent : MonoBehaviour
    {
        public bool SetInactiveAfterwards = true;
        private Animation animationComp;

        private void Awake()
        {
            animationComp = GetComponent<Animation>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartAnimation()
        {
            StartCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            animationComp.Play();
            while (animationComp.isPlaying)
            {
                yield return null;
            }

            if (SetInactiveAfterwards) gameObject.SetActive(false);
        }
    }
}