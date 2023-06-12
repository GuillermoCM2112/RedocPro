using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedocPro.Controllers
{
    /// <summary>
    /// Validate that the API is online.
    /// </summary>
    /// <returns>A generic message with the version.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Health
    ///
    /// </remarks>
    /// <response code="200">Returns a 200 if the API is online.</response>
    /// <response code="500">Unhandled error, validate the error log.</response>
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Health()
        {
            return this.Ok("0.1.5");
        }
    }
}
