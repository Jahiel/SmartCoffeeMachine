using SmartCoffeMachine.Core.CoffeeMachine.Class;
using SmartCoffeMachine.Core.CoffeeMachine.Enum;

namespace SmartCoffeeMachine.V1.Models.Get
{
    public class Alert : CoffeeMachine
    {
        public Alert(CoffeeMachineStub stub) : base(stub) { }

        //Say if the coffee machine is currently in alert or not
        public bool IsInAlertState => _coffeeMachine.WaterLevelState == EnumState.Alert
                                       || _coffeeMachine.BeanFeedState == EnumState.Alert
                                       || _coffeeMachine.WasteCoffeeState == EnumState.Alert
                                       || _coffeeMachine.WaterTrayState == EnumState.Alert;
    }
}
