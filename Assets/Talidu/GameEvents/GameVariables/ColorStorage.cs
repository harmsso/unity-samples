#region

using UnityEngine;

#endregion

namespace GameEvents.GameVariables
{
    /// <summary>
    /// Stores a specific Color.
    /// </summary>
    [CreateAssetMenu(fileName = "VariableStorage", menuName = "Variable Storages/ColorStorage")]
    public class ColorStorage : VariableStorage<Color>
    {
    }
}