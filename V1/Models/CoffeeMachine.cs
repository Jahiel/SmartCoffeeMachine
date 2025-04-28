using SmartCoffeMachine.Core.CoffeeMachine.Class;
using SmartCoffeMachine.Core.CoffeeMachine.Enum;

namespace SmartCoffeeMachine.V1.Models
{
    public class CoffeeMachine
    {

        protected readonly CoffeeMachineStub _coffeeMachine;

        public CoffeeMachine(CoffeeMachineStub coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        //State of water level 
        public EnumState WaterLevelState => _coffeeMachine.WaterLevelState;

        //State of bean feed
        public EnumState BeanFeedState => _coffeeMachine.BeanFeedState;

        //State of waste
        public EnumState WasteCoffeeState => _coffeeMachine.WasteCoffeeState;

        //State of Water Tray
        public EnumState WaterTrayState => _coffeeMachine.WaterTrayState;


    }
}
