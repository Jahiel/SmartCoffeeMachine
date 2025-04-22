using SmartCoffeMachine.Core.CoffeeMachine.Enum;
using SmartCoffeMachine.Core.CoffeeMachine.Interface;
using SmartCoffeMachine.Core.CoffeeMachine.Struct;

namespace SmartCoffeMachine.Core.CoffeeMachine.Class
{
    public class CoffeeMachineStub : ICoffeeMachine
    {
        //The machine is on or Off
        public bool IsOn { get; private set; }
        //The coffee machine is currently making coffee or not
        public bool IsMakingCoffee { get; private set; }
        //State of water level 
        public EnumState WaterLevelState { get; private set; }
        //State of bean feed
        public EnumState BeanFeedState { get; private set; }
        //State of waste
        public EnumState WasteCoffeeState { get; private set; }
        //State of Water Tray
        public EnumState WaterTrayState { get; private set; }

        //Say if the coffee machine is currently in alert or not
        private bool IsInAlertState => WaterLevelState == EnumState.Alert
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

            //Simulating delay 
            await Task.Delay(100);
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

            //Simulating delay
            await Task.Delay(100);
            // [Machine turned off]
            IsOn = false;
        }
        public async Task MakeCoffeeAsync(CoffeeCreationOptions options)
        {
            if (!IsOn || IsMakingCoffee || IsInAlertState)
                throw new InvalidOperationException("Invalid state");

            //Simulating delay
            await Task.Delay(100);
            IsMakingCoffee = true;
            // [Make the coffee]
            Thread.Sleep(10000);
            IsMakingCoffee = false;
        }
        // Randomly create a state for testing. This can be replaced as required.
        private EnumState GetRandomState() => _randomStateGenerator.Next(1, 10) == 10 ? EnumState.Alert : EnumState.Okay;
    }
}
