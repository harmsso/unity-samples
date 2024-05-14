#region

using System.Collections.Generic;
using EventSystem;
using UnityEngine;

#endregion

namespace GameEvents
{
    /// <summary>
    /// A Scriptable Object for simple game events. Listeners must implement the <see cref="IGameEventListener"/>-Interface.
    /// All game events a designer should know about should be a Game Event. <seealso cref="ScriptableObject"/>.
    /// It is used to separate internal logic and UI.
    /// </summary>
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> listeners =
            new List<IGameEventListener>();

        /// <summary>
        /// Notify all listeners, that the event was raised.
        /// </summary>
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }

        /// <summary>
        /// Add a <see cref="IGameEventListener{T}"/> to the list of listeners.
        /// </summary>
        /// <param name="listener"></param>
        public void RegisterListener(IGameEventListener listener)
        {
            listeners.Add(listener);
        }

        /// <summary>
        /// Remove a <see cref="IGameEventListener{T}"/> from the list of listeners.
        /// </summary>
        /// <param name="listener"></param>
        public void UnregisterListener(IGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }

    /// <summary>
    /// Generic version of <see cref="GameEvent"/>. Inherits from <see cref="MonoBehaviour"/>,
    /// This type of Game Events have a specific use case, e.g. notifying about student related data and must not necessarily be known by a designer.
    /// It is used to communicate between the internal logic and the UI and separates them completely.
    /// Can contain game logic related to the data, e.g. saving the data temporarily, in a VariableStorage or send a WebRequest to the Backend.
    /// </summary>
    /// <typeparam name="T">Must derive from <see cref="EventInfo"/></typeparam>
    public abstract class GameEvent<T> : MonoBehaviour where T : EventInfo
    {
        private readonly List<IGameEventListener<T>> listeners =
            new List<IGameEventListener<T>>();

        /// <summary>
        /// Register a <see cref="IGameEventListener{T}"/> where T is of type <see cref="EventInfo"/>
        /// </summary>
        /// <param name="listener"><see cref="IGameEventListener{T}"/>that gets added to the list of listeners</param>
        public void RegisterListener(IGameEventListener<T> listener)
        {
            listeners.Add(listener);
        }

        /// <summary>
        /// Unregister a <see cref="IGameEventListener{T}"/> where T is of type <see cref="EventInfo"/>
        /// </summary>
        /// <param name="listener"><see cref="IGameEventListener{T}"/>that gets removed from the list of listeners</param>
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }

        /// <summary>
        /// Defines what happens before the listeners get notified, e.g. storing the event info. Must call <see cref="GameEvent{T}.Raise"/>.
        /// </summary>
        /// <param name="obj">Is type of <see cref="EventInfo"/></param>
        protected abstract void OnEventFired(T obj);

        protected void Raise(T value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(value);
        }

        private void OnEnable()
        {
            EventSystem.EventSystem.Current.RegisterListener<T>(OnEventFired);
        }

        private void OnDisable()
        {
            EventSystem.EventSystem.Current.UnregisterListener<T>(OnEventFired);
        }
    }
}