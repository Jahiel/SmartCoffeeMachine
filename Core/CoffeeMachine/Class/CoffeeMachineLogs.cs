using SmartCoffeeMachine.Core.CoffeeMachine.Enum;

namespace SmartCoffeeMachine.Core.CoffeeMachine.Class
{
    /// <summary>
    /// Class for logging every call made on the API
    /// </summary>
    public class CoffeeMachineLogs
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public EnumLog Action { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? ParametersJson { get; set; }

        public string? ResultsJson { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
