namespace SmartCoffeeMachine.V1.Models.Get
{
    /// <summary>
    /// Daily model stats sent by API
    /// </summary>
    public class DailyCoffeeStats
    {
        public DateTime Date { get; set; }
        public int CoffeesMade { get; set; }
    }
}
