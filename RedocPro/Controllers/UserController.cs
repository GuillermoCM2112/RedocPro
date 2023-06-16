using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using RedocPro.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RedocPro.Controllers
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag(ControllersDescriptions.UserController)]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(OperationId = nameof(AddTaCVersion), Description = EndpointsDescriptions.AddTaCVersion)]
        [SwaggerResponse(200, EndpointsDescriptions.ResponsePost200, type: typeof(AddTaCVersionResponse))]
        [SwaggerResponse(500, EndpointsDescriptions.Response500, type: typeof(Error))]
        public IActionResult AddTaCVersion([FromBody] AcceptTaCRequest request) => this.Ok();

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(GetLatestTaC), Description = EndpointsDescriptions.GetLatestTaC)]
        [SwaggerResponse(200, EndpointsDescriptions.ResponseGet200, type: typeof(LatestTaCResponse))]
        [SwaggerResponse(500, EndpointsDescriptions.Response500, type: typeof(Error))]
        public IActionResult GetLatestTaC([FromQuery] GetLatestTaCRequest request) => this.Ok();
    }
}
