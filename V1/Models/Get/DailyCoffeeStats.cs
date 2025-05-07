namespace SmartCoffeeMachine.V1.Models.Get
{
    /// <summary>
    /// Daily model stats sent by API
    /// </summary>
    public class DailyCoffeeStats
    {
        /// <summary>
        /// Day of the week (1 = Monday, ...)
        /// </summary>
        public int DayOfWeekNumber { get; set; }

        public TimeSpan FirstCupTime { get; set; }

        public TimeSpan LastCupTime { get; set; }

        /// <summary>
        /// Switched to double
        /// </summary>
        public double CoffeesMade { get; set; }
    }
}
