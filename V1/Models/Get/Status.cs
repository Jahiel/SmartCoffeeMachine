﻿using SmartCoffeMachine.Core.CoffeeMachine.Class;

namespace SmartCoffeeMachine.V1.Models.Get
{
    /// <summary>
    /// Status modal sent by API
    /// </summary>
    public class Status : CoffeeMachine
    {
        public Status(CoffeeMachineStub stub) : base(stub) { }

        //The machine is on or Off
        public bool IsOn => _coffeeMachine.IsOn;

        //The coffee machine is currently making coffee or not
        public bool IsMakingCoffee => _coffeeMachine.IsMakingCoffee;

        public bool IsInAlert => _coffeeMachine.IsInAlertState;
    }
}
