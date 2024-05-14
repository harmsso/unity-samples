#region

using System;

#endregion

namespace Player
{
    /// <summary>
    /// Data container for everything student-specific
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        /// <summary>
        /// 
        /// </summary>
        public int Currency;

        /// <summary>
        /// 
        /// </summary>
        public int XP;

        /// <summary>
        /// 
        /// </summary>
        public string Language = "de";
    }
}