using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using Swashbuckle.AspNetCore.Annotations;

namespace RedocPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("ChangeUserPassword")]
        [SwaggerOperation(
            Summary = "Change User password",
            Description = "This endpoint will change the password of the user-",
            OperationId = "ChangeUserPassword",
            Tags = new[] { "Auth" })]
        [ProducesResponseType(200, Type = typeof(UserChangeResponse))]
        public async Task<IActionResult> ChangeUserPassword([FromBody] UpdatePasswordRequest request)
        {
            return this.Ok();
        }
    }
}
