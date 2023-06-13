using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using RedocPro.Models;
using RedocPro.Models.Requests;
using RedocPro.Models.Responses;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;

namespace RedocPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SwaggerTag("List Auth endpoints.")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Validates if the user has permissions to log in.
        /// </summary>
        /// <param name="request">The user credentials.</param>
        /// <response code="200">Returns access token information.</response>
        /// <response code="500">Unhandled error, validate the error log.</response>
        /// <returns>El producto encontrado.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccessResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return this.Ok();
        }

        /// <summary>
        /// Creates a user if meets the validations.
        /// </summary>
        /// <param name="request">The user information.</param>
        /// <response code="200">Returns access token information.</response>
        /// <response code="500">Unhandled error, validate the error log.</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccessResponse))]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            return this.Ok();
        }

        /// <summary>
        /// Generates a new refresh token.
        /// </summary>
        /// <param name="request">The refresh token.</param>
        /// <response code="200">Returns a status of the user.</response>
        /// <response code="500">Unhandled error, validate the error log.</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccessResponse))]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest request)
        {
            return this.Ok();
        }

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

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(GetTransversalUserData), Description = EndpointsDescriptions.GetTransversalUserDataDescription)]
        [SwaggerResponse(200, "Response", type: typeof(UserDataResponse))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
        public IActionResult GetTransversalUserData([FromQuery] UserDataRequest request)
        {
            return this.Ok();
        }

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(RevokeRefreshToken), Description = EndpointsDescriptions.RevokeRefreshTokenDescription)]
        [SwaggerResponse(200, "Response", type: typeof(RefreshResponse))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
        public IActionResult RevokeRefreshToken([FromBody] RefreshRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(GetUserProfile), Description = EndpointsDescriptions.GetUserProfileDescription)]
        [SwaggerResponse(200, "Response", type: typeof(UserChangeResponse))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
        public IActionResult GetUserProfile([FromQuery] GetUserProfileRequest request)
        {
            return this.Ok();
        }


		[HttpGet]
		[SwaggerOperation(OperationId = nameof(GetTransversalUserData), Description = EndpointsDescriptions.GetTransversalUserDataDescription)]
		[SwaggerResponse(200, "Response", type: typeof(UserDataResponse))]
		[SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
		public IActionResult GetTransversalUserData([FromQuery] UserDataRequest request)
		{
			return this.Ok();
		}

		[HttpPost]
		[SwaggerOperation(OperationId = nameof(RevokeRefreshToken), Description = EndpointsDescriptions.RevokeRefreshTokenDescription)]
		[SwaggerResponse(200, "Response", type: typeof(RefreshResponse))]
		[SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
		public IActionResult RevokeRefreshToken([FromBody] RefreshRequest request)
		{
			return this.Ok();
		}

		[HttpGet]
		[SwaggerOperation(OperationId = nameof(GetUserProfile), Description = EndpointsDescriptions.GetUserProfileDescription)]
		[SwaggerResponse(200, "Response", type: typeof(UserChangeResponse))]
		[SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
		public IActionResult GetUserProfile([FromQuery] GetUserProfileRequest request)
		{
			return this.Ok();
		}

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(GetUserProfile), Description = EndpointsDescriptions.TokenValidatorDescription)]
        [Route("TokenValidator")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public IActionResult TokenValidator()
        {
            var token = this.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? string.Empty;
            var jwtToken = string.IsNullOrWhiteSpace(token) ? null : "";

            if (jwtToken != null)
            {
                return this.Ok("Valid");
            }

            throw new Exception("Invalid");
        }

        #region UpdateUserProfile
        [HttpPatch]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[Route(nameof(UpdateUserProfile))]
        [SwaggerSchemaExample(nameof(PerfilUsuario))]
        [SwaggerOperation(OperationId = nameof(UpdateUserProfile), Description = EndpointsDescriptions.UpdateUserProfileDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.UpdateUserProfile200Description, type: typeof(CambiarCuentaRespuesta))]
        [SwaggerResponse(400, EndpointsDescriptions.UpdateUserProfile400Description, type: typeof(Error))]
        [SwaggerResponse(401, EndpointsDescriptions.UpdateUserProfile401Description, type: typeof(ErrorResponse))]
        [SwaggerResponse(409, EndpointsDescriptions.UpdateUserProfile409Description, type: typeof(Error))]
        [SwaggerResponse(500, EndpointsDescriptions.UpdateUserProfile500Description, type: typeof(ErrorResponse))]
        public IActionResult UpdateUserProfile([FromBody] PerfilUsuario user) => this.Ok(user);
        #endregion

        #region RecoveryUserPassword
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[Route(nameof(RecoveryUserPassword))]
        [SwaggerSchemaExample(nameof(RecuperarContrasena))]
        [SwaggerOperation(OperationId = nameof(UpdateUserProfile), Description = EndpointsDescriptions.RecoveryUserPasswordDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.RecoveryUserPassword200Description, type: typeof(CambiarCuentaRespuesta))]
        [SwaggerResponse(401, EndpointsDescriptions.RecoveryUserPassword401Description, type: typeof(ErrorResponse))]
        [SwaggerResponse(500, EndpointsDescriptions.RecoveryUserPassword500Description, type: typeof(ErrorResponse))]
        public IActionResult RecoveryUserPassword([FromBody] RecuperarContrasena user) => this.Ok(user);
        #endregion

        #region CancelUserAccount
        [HttpPost]
        [Route("CancelUserAccount")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[Route(nameof(CancelUserAccount))]
        [SwaggerSchemaExample(nameof(CancelarCuenta))]
        [SwaggerOperation(OperationId = nameof(UpdateUserProfile), Description = EndpointsDescriptions.CancelUserAccountDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.CancelUserAccount200Description, type: typeof(CancelarCuentaRespuesta))]
        [SwaggerResponse(401, EndpointsDescriptions.CancelUserAccount401Description, type: typeof(ErrorResponse))]
        [SwaggerResponse(500, EndpointsDescriptions.CancelUserAccount500Description, type: typeof(ErrorResponse))]
        public IActionResult CancelUserAccount([FromBody] CancelarCuenta request) => this.Ok(request);
        #endregion
    }
}