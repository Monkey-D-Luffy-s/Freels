using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        [HttpGet]
        [Route("Ping")]
        public IActionResult Ping()
        {
            return Ok("Success");
        }
    }
}
