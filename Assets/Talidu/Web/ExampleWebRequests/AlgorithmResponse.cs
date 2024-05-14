#region

using System;
using Newtonsoft.Json;

#endregion

namespace Web.ExampleWebRequests
{
    /// <summary>
    /// Container class for the parsed response.
    /// The naming of the variables must correspond to the received json.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(AlgorithmResponseConverter))]
    public class AlgorithmResponse
    {
        public string status { get; set; }
        public string version { get; set; }
        public string hash { get; set; }
    }
}