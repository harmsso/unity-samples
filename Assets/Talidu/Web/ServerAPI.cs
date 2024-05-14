#region

using System.Text;
using Localization.AssetLocalization;
using UnityEngine;
using UnityEngine.Networking;

#endregion

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "taliduServeAPI", menuName = "Web Request Creator/TaliduServer")]
    public class ServerAPI : WebRequestCreator
    {
        private const string ServerURL = "https://example.de";
        private const string FooAPI = "/foo";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override UnityWebRequest CreateAudioWebRequest(string path)
        {
            return UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override UnityWebRequest CreateImageWebRequest(string path)
        {
            return UnityWebRequestTexture.GetTexture(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override UnityWebRequest CreateMlAlgorithmWebRequest(string json)
        {
            return CreateJsonRequest(json, ServerURL + FooAPI);
        }

        private UnityWebRequest CreateJsonRequest(string json, string url)
        {
            var req = new UnityWebRequest(url, "POST");
            var jsonToSend = new UTF8Encoding().GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(jsonToSend);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            return req;
        }
    }
}