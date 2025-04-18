using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCoffeMachine.Core.CoffeeMachine.Enum;
using SmartCoffeMachine.Core.CoffeeMachine.Struct;

namespace SmartCoffeMachine.Core.CoffeeMachine.Class
{
    public class CoffeeMachineStub
    {
        public bool IsOn { get; private set; }
        public bool IsMakingCoffee { get; private set; }
        public EnumState WaterLevelState { get; private set; }
        public EnumState BeanFeedState { get; private set; }
        public EnumState WasteCoffeeState { get; private set; }
        public EnumState WaterTrayState { get; private set; }

        private bool IsInAlertState =>  WaterLevelState == EnumState.Alert
                                       || BeanFeedState == EnumState.Alert
                                       || WasteCoffeeState == EnumState.Alert
                                       || WaterTrayState == EnumState.Alert;

        private readonly Random _randomStateGenerator;
        public CoffeeMachineStub()
        {
            _randomStateGenerator = new Random();
        }
        public async Task TurnOnAsync()
        {
            if (IsOn)
                throw new InvalidOperationException("Invalid state");
            // Generate sample state for testing
            WaterLevelState = GetRandomState();
            BeanFeedState = GetRandomState();
            WasteCoffeeState = GetRandomState();
            WaterTrayState = GetRandomState();
            // [Machine turned on]
            IsOn = true;
        }
        public async Task TurnOffAsync()
        {
            if (!IsOn || IsMakingCoffee)
                throw new InvalidOperationException("Invalid state");
            // [Machine turned off]
            IsOn = false;
        }
        public async Task MakeCoffeeAsync(CoffeeCreationOptions options)
        {
            if (!IsOn || IsMakingCoffee || IsInAlertState)
                throw new InvalidOperationException("Invalid state");
            IsMakingCoffee = true;
            // [Make the coffee]
            Thread.Sleep(10000);
            IsMakingCoffee = false;
        }
        // Randomly create a state for testing. This can be replaced as required.
        private EnumState GetRandomState() => _randomStateGenerator.Next(1, 10)  == 10 ? EnumState.Alert : EnumState.Okay;
    }
}
