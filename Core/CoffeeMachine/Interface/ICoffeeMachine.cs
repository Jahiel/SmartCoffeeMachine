using SmartCoffeMachine.Core.CoffeeMachine.Enum;
using SmartCoffeMachine.Core.CoffeeMachine.Struct;

namespace SmartCoffeMachine.Core.CoffeeMachine.Interface
{
    /// <summary>
    /// Interface for the coffee machine
    /// </summary>
    public interface ICoffeeMachine
    {
        /// <summary>
        /// Tell if the machine is on or not
        /// </summary>
        bool IsOn { get; }
        /// <summary>
        /// Tell if the machine is currently doing coffee or not
        /// </summary>
        bool IsMakingCoffee { get; }

        EnumState WaterLevelState { get; }
        EnumState BeanFeedState { get; }
        EnumState WasteCoffeeState { get; }
        EnumState WaterTrayState { get; }
        Task TurnOnAsync();
        Task TurnOffAsync();
        Task MakeCoffeeAsync(CoffeeCreationOptions options);
    }
}
