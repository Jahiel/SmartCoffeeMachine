using Microsoft.AspNetCore.Mvc;

namespace SmartCoffeMachine.V1.Controllers
{
    // Ajout de l'attribut ApiController pour activer les fonctionnalités REST
    [ApiController]
    // Route définissant l'URL de l'API
    [Route("api/[controller]")]
    public class CoffeeMachineController : ControllerBase
    {
        // Action GET pour tester l'API
        [HttpGet]
        public IActionResult Get()
        {
            // Retourne un message de test si l'API est bien fonctionnelle
            return Ok("API is working");
        }
    }
}
