using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RedocPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion(1.0)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag(ControllersDescriptions.HealthController)]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(OperationId = nameof(Health), Description = "Validate that the API is online.")]
        [SwaggerResponse(200, "Returns a 200 with the version if the API is online.")]
        [SwaggerResponse(500, EndpointsDescriptions.Response500)]
        public IActionResult Health() => this.Ok("0.1.5");
    }
}
