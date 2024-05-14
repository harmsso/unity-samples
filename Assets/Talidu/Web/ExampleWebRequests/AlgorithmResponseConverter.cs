#region

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

#endregion

namespace Web.ExampleWebRequests
{
    /// <summary>
    /// Converts the received json to a <see cref="AlgorithmResponse"/>
    /// </summary>
    public class AlgorithmResponseConverter : JsonConverter<AlgorithmResponse>
    {
        /// <summary>
        /// Throws <exception cref="NotImplementedException"></exception>.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, AlgorithmResponse value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the received JSON to an <see cref="AlgorithmResponse"/>.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="hasExistingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override AlgorithmResponse ReadJson(JsonReader reader, Type objectType, AlgorithmResponse existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var data = JObject.Load(reader);
            Debug.Log(data);
            AlgorithmResponse response = new AlgorithmResponse();
            response.status = data["status"]?.ToString();
            response.version = data["version"]?.ToString();
            response.hash = data["hash"].ToString();

            return response;
        }
    }
}