#region

using System;
using EventSystem;
using GameEvents;
using UnityEngine;

#endregion

namespace UI.Displays
{
    /// <summary>
    /// Base class. Listens to an <see cref="GameEvent"/> of type <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">type of the <see cref="GameEvent"/> that is listened to</typeparam>
    [Serializable]
    public abstract class VariableDisplay<T> : MonoBehaviour, IGameEventListener<T> where T : EventInfo
    {
        [SerializeField] protected GameEvent<T> GameEvent;

        private void Awake()
        {
            GameEvent.RegisterListener(this);
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnStart()
        {
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        /// <summary>
        /// Is called, when the <see cref="GameEvent"/> of type <see cref="T"/> is raised.
        /// </summary>
        /// <param name="value">Event Info of type <see cref="T"/></param>
        public abstract void OnEventRaised(T value);
    }
}