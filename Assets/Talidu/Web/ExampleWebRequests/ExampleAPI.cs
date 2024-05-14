#region

using System;
using Cysharp.Threading.Tasks;
using EventSystem;
using Localization.AssetLocalization;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

#endregion

namespace Web.ExampleWebRequests
{
    /// <summary>
    /// Sends event info to an web api and processes the result.
    /// </summary>
    public class ExampleAPI : MonoBehaviour
    {
        [SerializeField] private WebRequestCreator Creator;

        /// <summary>
        /// Sends the results stored in the <see cref="AttemptInfo"/> to the ML-Algorithm.
        /// </summary>
        /// <param name="attemptInfo">The information that should be sent.</param>
        public void SendResult(EventInfo attemptInfo)
        {
            var request = CreateRequest(attemptInfo, Creator.CreateMlAlgorithmWebRequest);
            SendRequest(request).Forget();
        }

        /// <summary>
        /// Sends a WebRequest. If it was successful, a <see cref="NextWordsEventInfo"/>-Event is fired.
        /// </summary>
        /// <param name="request">The request that is being sent.</param>
        /// <returns>Returns, if <paramref name="request"/> was successful.</returns>
        public async UniTask<bool> SendRequest(UnityWebRequest request)
        {
            await WebRequestSender.Send(request, ConvertTextToResponse);

            SendNotification();
            return true;
        }

        #region private

        private void SendNotification()
        {
            ServerEventInfo attemptInfo = new ServerEventInfo();
            EventSystem.EventSystem.Current.FireEvent(attemptInfo);
        }

        private static UnityWebRequest CreateRequest(EventInfo info,
            Func<string, UnityWebRequest> creator)
        {
            var json = GetJson(info);
            var request = creator.Invoke(json);
            return request;
        }

        private static AlgorithmResponse ConvertTextToResponse(UnityWebRequest request)
        {
            if (request.result != UnityWebRequest.Result.Success)
                return new AlgorithmResponse { status = "error" };
            return JsonConvert.DeserializeObject<AlgorithmResponse>(request.downloadHandler.text,
                new AlgorithmResponseConverter());
        }

        private static string GetJson(EventInfo info)
        {
            // the event info could contain the necessary info for the backend
            AlgorithmPayload payload = new AlgorithmPayload();
            return JsonConvert.SerializeObject(payload);
        }

        #endregion
    }
}