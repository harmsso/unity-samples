#region

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace EventSystem
{
    /// <summary>
    /// Abstract base class for any kind of event 
    /// </summary>
    public abstract class EventInfo
    {
    }

    public class PlayerDataEventInfo : EventInfo
    {
        public int Currency;
        public int XP;
    }

    public class ImageEventInfo : EventInfo
    {
        public Texture Texture;
    }

    /// <summary>
    /// <see cref="EventInfo"/> notifying about Server Errors
    /// </summary>
    public class ServerEventInfo : EventInfo
    {
        /// <summary>
        /// </summary>
        public string Status;

        /// <summary>
        /// </summary>
        public object Response;
    }

    /// <summary>
    /// <see cref="EventInfo"/> notifying about a reward and a action that returns the amount of earned rewards
    /// </summary>
    public class RewardEventInfo : EventInfo
    {
        public float Percentage;

        /// <summary>
        /// Callback for notifying about the result.
        /// </summary>
        public Action<int> Callback;
    }

    /// <summary>
    /// <see cref="EventInfo"/> used for updating input displays
    /// </summary>
    public class InputDisplayInfo : EventInfo
    {
        /// <summary>
        /// </summary>
        public List<string> Inputs;
    }
}