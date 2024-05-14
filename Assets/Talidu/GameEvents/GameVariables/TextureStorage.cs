#region

using UnityEngine;

#endregion

namespace GameEvents.GameVariables
{
    /// <summary>
    /// Stores a texture.
    /// </summary>
    [CreateAssetMenu(fileName = "VariableStorage", menuName = "Variable Storages/TextureStorage")]
    public class TextureStorage : VariableStorage<Texture>
    {
    }
}