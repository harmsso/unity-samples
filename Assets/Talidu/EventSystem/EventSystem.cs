#region

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#endregion

namespace EventSystem
{
    /// <summary>
    /// Flexible event system. Listeners of events need to register as a listener of a specific <see cref="EventInfo"/>-Event
    /// In every scene must be an instance of this singleton.
    /// </summary>
    public class EventSystem : MonoBehaviour
    {
        /// <summary>
        /// Event that is fired when shift button is pressed
        /// </summary>
        public static readonly UnityEvent SwitchedCase = new();

        /// <summary>
        /// Event that is fired when a new word was initialized and can be used for mini games or the base exercise
        /// </summary>
        public static readonly UnityEvent InitializeNewWord = new();

        void OnEnable()
        {
            __Current = this;
        }

        private void OnDisable()
        {
            SwitchedCase.RemoveAllListeners();
            InitializeNewWord.RemoveAllListeners();
        }

        private static EventSystem __Current;

        /// <summary>
        /// Getter for singleton instance
        /// </summary>
        public static EventSystem Current
        {
            get
            {
                if (__Current == null)
                {
                    __Current = FindObjectOfType<EventSystem>();
                }

                return __Current;
            }
        }

        private delegate void EventListener(EventInfo ei);

        private readonly Dictionary<Type, List<EventListener>> EventListeners =
            new Dictionary<Type, List<EventListener>>();

        /// <summary>
        /// Register a listener for a <see cref="EventInfo"/>-Event
        /// </summary>
        /// <param name="listener"> Generic Action where T is a <see cref="EventInfo"/> and is called when the event is fired</param>
        /// <typeparam name="T">Must derive from <see cref="EventInfo"/></typeparam>
        public void RegisterListener<T>(Action<T> listener) where T : EventInfo
        {
            Type eventType = typeof(T);
            if (!EventListeners.ContainsKey(eventType) || EventListeners[eventType] == null)
            {
                EventListeners[eventType] = new List<EventListener>();
            }

            EventListener wrapper = (ei) => { listener((T)ei); };
            EventListeners[eventType].Add(wrapper);
        }

        /// <summary>
        /// Unregister a listener for a <see cref="EventInfo"/>-Event
        /// </summary>
        /// <param name="listener"> Generic Action where T is a <see cref="EventInfo"/></param>
        /// <typeparam name="T">Must derive from <see cref="EventInfo"/></typeparam>
        public void UnregisterListener<T>(Action<T> listener) where T : EventInfo
        {
            Type eventType = typeof(T);
            if (!EventListeners.ContainsKey(eventType) || EventListeners[eventType] == null) return;

            EventListener wrapper = (ei) => { listener((T)ei); };

            EventListeners[eventType].Remove(wrapper);
        }

        /// <summary>
        /// Fire the Event of type <see cref="EventInfo"/>
        /// </summary>
        /// <param name="eventInfo">The specific <see cref="EventInfo"/>-Child</param>
        public void FireEvent(EventInfo eventInfo)
        {
            Type trueEventInfoClass = eventInfo.GetType();
            if (EventListeners == null || !EventListeners.ContainsKey(trueEventInfoClass)) return;

            foreach (var el in EventListeners[trueEventInfoClass])
            {
                el(eventInfo);
            }
        }
    }
}