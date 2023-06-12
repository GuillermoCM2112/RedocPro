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
    [SwaggerTag("List Auth endpoints.")]
    public class AuthController : ControllerBase
    {
        [HttpPost("ChangeUserPassword")]
        [SwaggerOperation(
            Summary = "Change User Password",
            Description = "This endpoint will change the password of the user.",
            OperationId = "ChangeUserPassword")]
        [ProducesResponseType(200, Type = typeof(UserChangeResponse))]
        public async Task<IActionResult> ChangeUserPassword([FromBody] UpdatePasswordRequest request)
        {
            return this.Ok();
        }
        /// <summary>
        /// Change User Property
        /// </summary>
        /// <remarks>This endpoint will change the property of the user.</remarks>
        /// <response code="200">Returns a 200 if the user property change.</response>
        /// <response code="500">Unhandled error, validate the error log.</response>
        [HttpPost("ChangeUserProperty")]
       
        [ProducesResponseType(200, Type = typeof(UserChangeResponse))]
        public async Task<IActionResult> ChangeUserProperty([FromBody] UpdateUserRequest request)
        {
            return this.Ok();
        }
        /// <summary>
        /// User Validation
        /// </summary>
        /// <remarks>
        /// This endpoint will validate if the user has any of the following states: 
        /// <ul><li>NotRegistered = 0</li><li>PreRegistered = 1</li><li>Registered = 2</li><li>OTPRequired = 3</li>
        /// <li>SoftBlock = 4</li><li>HardBlock = 5</li><li>CancelledAccount = 8</li><li>FirstLoginOxxo = 20</li></ul>
        /// </remarks>
        /// <response code="200">Returns a status of the user.</response>
        /// <response code="500">Unhandled error, validate the error log.</response>
        [HttpGet("UserValidation")]
        [ProducesResponseType(200, Type = typeof(UserValidationResponse))]
        public async Task<IActionResult> UserValidation([FromQuery] UserValidationRequest request)
        {
            return this.Ok();
        }
    }
}
