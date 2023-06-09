using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedocPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Health()
        {
            return this.Ok("0.1.5");
        }
    }
}
