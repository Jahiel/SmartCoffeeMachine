namespace SmartCoffeeMachine.V1.Models.Get
{
    /// <summary>
    /// Weekly stats model sent by API
    /// </summary>
    public class WeeklyCoffeeStats
    {
        public int Week { get; set; }
        public int CoffeesMade { get; set; }
    }
}
