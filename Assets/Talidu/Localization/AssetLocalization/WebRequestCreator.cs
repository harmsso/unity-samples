#region

using UnityEngine;
using UnityEngine.Networking;

#endregion

namespace Localization.AssetLocalization
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class WebRequestCreator : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract UnityWebRequest CreateAudioWebRequest(string path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract UnityWebRequest CreateImageWebRequest(string path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public abstract UnityWebRequest CreateMlAlgorithmWebRequest(string json);
    }
}