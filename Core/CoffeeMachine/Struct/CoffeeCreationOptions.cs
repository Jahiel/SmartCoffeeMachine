namespace SmartCoffeMachine.Core.CoffeeMachine.Struct
{
    /// <summary>
    /// Option for coffee creation
    /// </summary>
    public struct CoffeeCreationOptions
    {
        /// <summary>
        /// Number of expresso shots wanted in the coffee
        /// </summary>
        public int NumExpressoShots { get; set; }

        /// <summary>
        /// Coffee have milk or not
        /// </summary>
        public bool AddMilk { get; set; }
    }
}
