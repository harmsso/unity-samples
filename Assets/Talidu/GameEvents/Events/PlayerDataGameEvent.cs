#region

using System;
using EventSystem;
using GameEvents.GameVariables;
using Localization;
using UnityEngine;

#endregion

namespace GameEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PlayerDataGameEvent : GameEvent<PlayerDataEventInfo>
    {
        [SerializeField] private PlayerDataStorage Storage;

        private PlayerDataEventInfo displayInfo = new();

        private void Awake()
        {
            EventSystem.EventSystem.InitializeNewWord.AddListener(CompletedWord);
            UpdateEventInfo();
        }

        private void Start()
        {
            LocalizationProvider.LoadLanguageConfig(Storage.Value.Language);
            Raise(displayInfo);
            Invoke(nameof(UpdateDisplay), 0.1f);
        }

        private void UpdateDisplay()
        {
            Raise(displayInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="experienceAmount"></param>
        public void AddXP(int experienceAmount)
        {
            Storage.Value.XP += experienceAmount;
            Raise(displayInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetXP()
        {
            return Storage.Value.XP;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCurrency()
        {
            return Storage.Value.Currency;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetLanguage()
        {
            return Storage.Value.Language;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearData()
        {
            Storage.Value.Currency = 0;
            Storage.Value.XP = 0;
            Raise(displayInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CompletedWord()
        {
            UpdateEventInfo();
            Raise(displayInfo);
        }

        private void UpdateEventInfo()
        {
            displayInfo.Currency = Storage.Value.Currency;
            displayInfo.XP = Storage.Value.XP;
        }

        protected override void OnEventFired(PlayerDataEventInfo obj)
        {
            Raise(obj);
        }
    }
}