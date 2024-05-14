#region

using UnityEngine;
using UnityEngine.Events;

#endregion

namespace GameEvents
{
    /// <summary>
    /// <see cref="MonoBehaviour"/> for designers to subscribe to a <see cref="GameEvent"/> in the editor.
    /// </summary>
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        /// <summary>
        /// Reference to a <see cref="GameEvent"/> that will be listened to.
        /// </summary>
        public GameEvent GameEvent;

        /// <summary>
        /// UnityEvent, that is called when the Game Event was raised.
        /// </summary>
        public UnityEvent Response;

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}