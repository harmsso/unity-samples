#region

using UnityEditor;

#endregion

namespace Web.ExampleWebRequests
{
    /// <summary>
    /// This is an empty example class for an API-specific payload
    /// </summary>
    public class AlgorithmPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public string uid = new GUID().ToString();

        /// <summary>
        /// Constructor initializing all the class members needed.
        /// </summary>
        public AlgorithmPayload()
        {
        }
    }
}