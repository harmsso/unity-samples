#region

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

#endregion

namespace UI
{
    /// <summary>
    /// Load a scene by name. Is used for listening to actions e.g. <see cref="Button.onClick"/>.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        /// <summary>
        /// Loads the specified scene.
        /// </summary>
        /// <param name="sceneName">Literal name of the scene.</param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}