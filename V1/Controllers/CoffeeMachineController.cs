using System.Net;
using Microsoft.AspNetCore.Mvc;
using SmartCoffeMachine.Core.CoffeeMachine.Interface;
using Swashbuckle.AspNetCore.Annotations;
namespace SmartCoffeMachine.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Tags("CoffeeMachine")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ICoffeeMachine _coffeeMachine;

        public CoffeeMachineController(ICoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        /// <summary>
        /// Just a simple test route to check if api is correctly working or not
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
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine state retrieved successfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Failed to retrieve state")]
        public IActionResult GetMachineState()
        {
            //TODO Use models
            var machineState = new
            {
                IsOn = _coffeeMachine.IsOn,
                IsMakingCoffee = _coffeeMachine.IsMakingCoffee
            };

            return Ok(machineState);
        }

        /// <summary>
        /// Get the current alerts of the coffee machine
        /// </summary>
        /// <returns>Machine alerts</returns>
        [HttpGet("alerts")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Machine alerts retrieved successfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Failed to retrieve alerts")]
        public IActionResult GetMachineAlerts()
        {
            var alerts = new
            {
                WaterLevel = _coffeeMachine.WaterLevelState.ToString(),
                BeanFeed = _coffeeMachine.BeanFeedState.ToString(),
                WasteCoffee = _coffeeMachine.WasteCoffeeState.ToString(),
                WaterTray = _coffeeMachine.WaterTrayState.ToString()
            };

            return Ok(alerts);
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
                return Ok("Machine is on");
            }
            catch (Exception ex)
            {
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
                return Ok("Machine is off");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
