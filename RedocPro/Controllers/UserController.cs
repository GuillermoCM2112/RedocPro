using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using Swashbuckle.AspNetCore.Annotations;

namespace RedocPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag(Descriptions.ControllersDescriptions.UserController)]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(OperationId = nameof(AddTaCVersionResponse), Description = EndpointsDescriptions.AddTaCVersion)]
        [SwaggerResponse(200, "Response", type: typeof(AddTaCVersionResponse))]
        public async Task<IActionResult> AddTaCVersion([FromBody] AcceptTaCRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(LatestTaCResponse), Description = EndpointsDescriptions.GetLatestTaC)]
        [SwaggerResponse(200, "Response", type: typeof(LatestTaCResponse))]
        public async Task<IActionResult> GetLatestTaC([FromQuery] GetLatestTaCRequest request)
        {
            return this.Ok();
        }
    }
}
