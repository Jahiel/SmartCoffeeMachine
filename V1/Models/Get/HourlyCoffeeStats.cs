namespace SmartCoffeeMachine.V1.Models.Get
{
    /// <summary>
    /// Weekly stats model sent by API
    /// </summary>
    public class HourlyCoffeeStats
    {
        /// <summary>
        /// Hour of the day (0 = 00:00-00:59, 1 = 01:00-01:59, ..., 23 = 23:00-23:59)
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        /// Number of coffees made in that hour
        /// </summary>
        public int CoffeesMade { get; set; }
    }
}
