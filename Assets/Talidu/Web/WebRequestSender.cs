#region

using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

#endregion

namespace Web
{
    /// <summary>
    /// Static helper class for sending WebRequests.
    /// </summary>
    public static class WebRequestSender
    {
        /// <summary>
        /// Sends a <see cref="UnityWebRequest"/> and uses a converter function that parses the request's answer.
        /// </summary>
        /// <param name="webRequest"></param>
        /// <param name="converterFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="UniTask{T}"/></returns>
        public static async UniTask<T> Send<T>(UnityWebRequest webRequest,
            Func<UnityWebRequest, T> converterFunc)
        {
            await webRequest.SendWebRequest();

            return converterFunc.Invoke(webRequest);
        }
    }
}