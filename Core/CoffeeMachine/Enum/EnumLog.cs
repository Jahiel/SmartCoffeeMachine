namespace SmartCoffeeMachine.Core.CoffeeMachine.Enum
{
    /// <summary>
    /// Enum in order to identify which action is done in log base
    /// </summary>
    public enum EnumLog
    {
        /// <summary>
        /// Alert is generated
        /// </summary>
        Alert = 0,
        /// <summary>
        /// Coffee is made
        /// </summary>
        Coffee = 1,
        /// <summary>
        /// State is asked
        /// </summary>
        State = 2,
        /// <summary>
        /// Alert(s) are asked
        /// </summary>
        GetAlert = 3,
        /// <summary>
        /// Machine is turned on
        /// </summary>
        TurnOn = 4,
        /// <summary>
        /// Machine is turned off
        /// </summary>
        TurnOff = 5,
        /// <summary>
        /// Stats is required
        /// </summary>
        Stats = 6
    }
}
