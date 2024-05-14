#region

using System;
using EventSystem;
using UnityEngine;

#endregion

namespace RewardSystem
{
    /// <summary>
    /// Calculate Reward based on <see cref="RewardEventInfo"/> and <see cref="CalculationStrategy"/>
    /// </summary>
    public class RewardCalculator : MonoBehaviour
    {
        protected CalculationStrategy Strategy = new StarCalculation();
        protected Type TypeOfStrategy = typeof(StarCalculation);

        /// <summary>
        /// Setting the <see cref="CalculationStrategy"/>, that should be used to calculate the rewards.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetStrategy<T>() where T : CalculationStrategy, new()
        {
            Strategy = new T();
            TypeOfStrategy = Strategy.GetType();
        }

        protected virtual void OnRewardEvent(RewardEventInfo rewardEventInfo)
        {
            SetFieldOfStrategy("Percentage", rewardEventInfo.Percentage);

            var reward = Strategy.CalculateRewards();
            rewardEventInfo.Callback.Invoke(reward.Currency);
        }

        protected void SetFieldOfStrategy(string fieldName, object value)
        {
            var field = TypeOfStrategy.GetField(fieldName);
            field?.SetValue(Strategy, value);
        }

        private void OnEnable()
        {
            EventSystem.EventSystem.Current.RegisterListener<RewardEventInfo>(OnRewardEvent);
        }

        private void OnDisable()
        {
            EventSystem.EventSystem.Current.UnregisterListener<RewardEventInfo>(OnRewardEvent);
        }
    }
}