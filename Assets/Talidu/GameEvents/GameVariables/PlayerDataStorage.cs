#region

using Player;
using UnityEngine;

#endregion

namespace GameEvents.GameVariables
{
    /// <summary>
    /// A <see cref="VariableStorage{T}"/> that stores the current user's <see cref="PlayerData"/>
    /// </summary>
    [CreateAssetMenu(fileName = "VariableStorage", menuName = "Variable Storages/PlayerData Storage")]
    public class PlayerDataStorage : VariableStorage<PlayerData>
    {
        /// <summary>
        /// Getter for the current key board the student should use.
        /// </summary>
        /// <returns>The name of the key board</returns>
        public string GetLanguage()
        {
            return Value.Language;
        }
    }
}