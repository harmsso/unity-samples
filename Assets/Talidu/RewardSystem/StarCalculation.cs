namespace RewardSystem
{
    /// <summary>
    /// Calculates the rewarded stars based on attempts.
    /// Min: 1 Star, Max: 5 Currency.
    /// </summary>
    public class StarCalculation : CalculationStrategy
    {
        public float Percentage;

        /// <summary>
        /// Calculates the earned stars.
        /// </summary>
        /// <returns>Amount of stars</returns>
        public override Reward CalculateRewards()
        {
            var score = 0;
            if (Percentage >= 0.95f)
                score = 5;
            else if (Percentage >= 0.75f)
                score = 3;
            else if (Percentage >= 0.5f)
                score = 2;
            else if (Percentage >= 0.25f)
                score = 1;

            return new Reward { Currency = score };
        }
    }
}