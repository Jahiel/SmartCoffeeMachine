namespace SmartCoffeMachine.Core.CoffeeMachine.Enum
{
    /// <summary>
    /// Enumeration for coffee machine state with detailed levels
    /// </summary>
    public enum EnumState
    {
        /// <summary>
        /// Fully operational
        /// </summary>
        Optimal = 4,

        /// <summary>
        /// Small degradation, no action required
        /// </summary>
        Okay = 3,

        /// <summary>
        /// Noticeable degradation, monitoring advised
        /// </summary>
        Medium = 2,

        /// <summary>
        /// Degraded performance, action recommended
        /// </summary>
        Warning = 1,

        /// <summary>
        /// Critical condition, immediate action required
        /// </summary>
        Alert = 0
    }
}
