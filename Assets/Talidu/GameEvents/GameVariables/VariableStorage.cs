#region

using UnityEngine;

#endregion

namespace GameEvents.GameVariables
{
    /// <summary>
    /// <see cref="ScriptableObject"/> for storing data universally.
    /// This data storages are used, when data must be saved permanently.
    /// </summary>
    public abstract class VariableStorage : ScriptableObject
    {
    }

    /// <summary>
    /// Generic <see cref="ScriptableObject"/> for storing data of type T permanently.
    /// </summary>
    /// <typeparam name="T">Can be any type of class.</typeparam>
    public abstract class VariableStorage<T> : VariableStorage
    {
        /// <summary>
        /// Instance of a object of type T.
        /// </summary>
        public T Value;
    }
}