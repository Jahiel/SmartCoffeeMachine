using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartCoffeeMachine.Core.CoffeeMachine.Class;
using SmartCoffeeMachine.Core.CoffeeMachine.Enum;
using SmartCoffeeMachine.V1.Models.Get;
using SmartCoffeMachine.Core.CoffeeMachine.Class;
using SmartCoffeMachine.Core.CoffeeMachine.Struct;
using Swashbuckle.AspNetCore.Annotations;
namespace SmartCoffeMachine.V1.Controllers
{
    /// <summary>
    /// API controller, every actions is logged in the database
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Tags("CoffeeMachine")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly CoffeeMachineStub _coffeeMachine;
        private readonly CoffeeMachineDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coffeeMachine"></param>
        /// <param name="dbContext"></param>
        public CoffeeMachineController(CoffeeMachineStub coffeeMachine, CoffeeMachineDbContext dbContext)
        {
            _coffeeMachine = coffeeMachine;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Just a simple test route to check if api is correctly working or not, no need for logging
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is working");
        }


        /// <summary>
        /// Get the current state of the coffee machine
        /// </summary>
        /// <returns>Machine state</returns>
        [HttpGet("state")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine state retrieved successfully", typeof(Status))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Failed to retrieve state")]
        public IActionResult GetMachineState()
        {
            Status status = new(_coffeeMachine);
            //logging
            _ = LogActions(EnumLog.State, "Retrieved machine state", status);
            return Ok(status);
        }

        /// <summary>
        /// Get the current alerts of the coffee machine
        /// </summary>
        /// <returns>Machine alerts</returns>
        [HttpGet("alerts")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine alerts retrieved successfully", typeof(Alert))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Failed to retrieve alerts")]
        public IActionResult GetMachineAlerts()
        {
            Alert alert = new(_coffeeMachine);
            _ = LogActions(EnumLog.GetAlert, "Retrieved machine alerts", alert);
            return Ok(alert);
        }


        /// <summary>
        /// Turn on coffee machine
        /// </summary>
        /// <returns></returns>
        [HttpPost("turn-on")]
        //TODO add status return
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine is on")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Internal error")]
        public async Task<IActionResult> TurnOn()
        {
            if (_coffeeMachine.IsOn)
            {
                return Ok("Machine is already on");
            }

            try
            {
                await _coffeeMachine.TurnOnAsync();
                await LogActions(EnumLog.TurnOn, "Machine turned on");
                return Ok("Machine is on");
            }
            catch (Exception ex)
            {
                Alert alert = new(_coffeeMachine);
                await LogActions(EnumLog.Alert, "Machine failed turned on", alert, null, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Turn off coffee machine
        /// </summary>
        /// <returns></returns>
        [HttpPost("turn-off")]
        //TODO add status return
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine is off")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Internal error")]
        public async Task<IActionResult> TurnOff()
        {
            if (!_coffeeMachine.IsOn)
            {
                return Ok("Machine is already off");
            }

            try
            {
                await _coffeeMachine.TurnOffAsync();
                await LogActions(EnumLog.TurnOff, "Machine turned off");
                return Ok("Machine is off");
            }
            catch (Exception ex)
            {
                Alert alert = new(_coffeeMachine);
                await LogActions(EnumLog.Alert, "Machine failed turned off", alert, null, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Make coffee
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpPost("coffee")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine is making coffee", typeof(Status))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Internal error")]
        public async Task<IActionResult> MakeCoffee([FromBody] CoffeeCreationOptions options)
        {
            //Controling values
            if (options.NumExpressoShots <= 0)
            {
                return BadRequest(new { error = "Number of expresso shots must be greater than zero." });
            }

            if (!_coffeeMachine.IsOn)
            {
                return BadRequest("Machine is off, please turn it on first.");
            }

            try
            {
                if (!_coffeeMachine.IsMakingCoffee)
                    await _coffeeMachine.MakeCoffeeAsync(options);
                else
                    return BadRequest("Coffee is already being made");
                await LogActions(EnumLog.Coffee, "Making coffee", null, options);
                return Ok(new Status(_coffeeMachine));
            }
            catch (InvalidOperationException ex)
            {
                _ = LogActions(EnumLog.Alert, "Failed to make coffee", null, options, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                _ = LogActions(EnumLog.Alert, "Failed to make coffee", null, options, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get the number of coffees made daily
        /// </summary>
        /// <returns>List of coffees made per day</returns>
        [HttpGet("coffees/daily")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Coffees retrieved successfully", typeof(IEnumerable<DailyCoffeeStats>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Failed to retrieve coffees")]
        public IActionResult GetDailyCoffees()
        {

            List<DailyCoffeeStats> weeklyStats = [.. _dbContext.Logs
                    .Where(log => log.Action == EnumLog.Coffee)
                    .GroupBy(log => new { log.DayOfWeekNumber, log.LogDate })
                    .Select(group => new DailyCoffeeStats
                    {
                        DayOfWeekNumber = group.Key.DayOfWeekNumber,
                        FirstCupTime = group.Min(log => log.TimeStamp).TimeOfDay,
                        LastCupTime = group.Max(log => log.TimeStamp).TimeOfDay,
                        CoffeesMade = group.Average(log => 1)
                    })
                    .OrderBy(stats => stats.DayOfWeekNumber)];

            return Ok(weeklyStats);
        }

        /// <summary>
        /// Get the number of coffees made Hourly
        /// </summary>
        /// <returns>List of coffees made per week</returns>
        [HttpGet("coffees/Hourly")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Coffees retrieved successfully", typeof(IEnumerable<HourlyCoffeeStats>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Failed to retrieve coffees")]
        public IActionResult GetWeeklyCoffees()
        {
            List<CoffeeMachineLogs> logs = [.. _dbContext.Logs.Where(log => log.Action == EnumLog.Coffee)];

            List<HourlyCoffeeStats> hourlyStats = [.. logs
                .GroupBy(log => log.TimeStamp.Hour)
                .Select(group => new HourlyCoffeeStats
                {
                    Hour = group.Key,
                    CoffeesMade = group.Count()
                })
                .OrderBy(stats => stats.Hour)];

            return Ok(hourlyStats);
        }



        /// <summary>
        /// Function to log every action made on the coffeeMachine
        /// </summary>
        /// <param name="LogType"></param>
        /// <param name="status"></param>
        private async Task LogActions(EnumLog LogType, String status, object? model = null, object? parameters = null, string? errorMessage = null)
        {
            try
            {
                DateTime now = DateTime.Now;
                CoffeeMachineLogs logEntry = new()
                {
                    Action = LogType,
                    Status = status,
                    TimeStamp = now,
                    ResultsJson = model != null ? JsonConvert.SerializeObject(model) : null,
                    ParametersJson = parameters != null ? JsonConvert.SerializeObject(parameters) : null,
                    ErrorMessage = errorMessage,
                    //Specificities locale convention (sunday to 7 and not 0)
                    DayOfWeekNumber = now.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)now.DayOfWeek,
                    HourSlot = now.Hour,
                    LogDate = DateOnly.FromDateTime(now)
                };

                await _dbContext.Logs.AddAsync(logEntry);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging action: {ex.Message}");
                throw;
            }
        }
    }
}
