namespace SmartCoffeeMachine.Core.CoffeeMachine.Class
{
    /// <summary>
    /// Class for logging every call made on the API
    /// </summary>
    public class CoffeeMachineLogs
    {
        public Guid Id { get; set; }

        private DateTime? _timeStamp;
        public DateTime? TimeStamp
        {
            get => _timeStamp ??= DateTime.Now;
            set => _timeStamp = value ?? DateTime.Now;
        }

        public string Action { get; set; }

        public string Status { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
