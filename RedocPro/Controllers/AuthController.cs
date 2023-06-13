using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedocPro.Descriptions;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using RedocPro.Models;
using RedocPro.Models.Requests;
using RedocPro.Models.Responses;
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

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(ChangeUserPassword), Description = EndpointsDescriptions.ChangeUserPassword)]
        [SwaggerResponse(200, "Response", type: typeof(UserChangeResponse))]
        [SwaggerResponse(404, "SPCI-404: User not found", type: typeof(Error))]
        public async Task<IActionResult> ChangeUserPassword([FromBody] UpdatePasswordRequest request)
        {
            return this.Ok();
        }


        [HttpPost]
        [SwaggerOperation(OperationId = nameof(ChangeUserProperty), Description = EndpointsDescriptions.ChangeUserProperty)]
        [SwaggerResponse(200, "Returns a 200 if the user property change.")]
        [SwaggerResponse(404, "SPCI-404: User not found", type: typeof(Error))]
        public async Task<IActionResult> ChangeUserProperty([FromBody] UpdateUserRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(UserValidation), Description = EndpointsDescriptions.UserValidation)]
        [SwaggerResponse(200, "Response", type: typeof(UserValidationResponse))]
        [SwaggerResponse(404, "SPCI-404: User not found", type: typeof(Error))]
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

        /// <summary>
        /// TokenValidator: validates that the token sent is correct
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
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
        /// <summary>
        /// UpdateUserProfile
        /// </summary>
        /// <param name="user">*User information.*</param>
        /// <returns>Returns the requested object to update.</returns>
        /// <remarks>
        /// 
        /// Updates the partial information of user.
        ///
        /// </remarks>
        /// <response code="200">The information is updated correctly</response>
        /// <response code="401">
        /// - Invalid token (SPCI-401-7): the given token is not valid.
        /// - Invalid token (SPCI-401-8): the scope header is invalid.
        /// - Nethone request a review (SPNE-401): review the user.
        /// - Nethone refuse the request (SPNE-402): user refused.
        /// </response>
        /// <response code="400">
        /// - The information is wrong (SPCI-400): the email provided is not valid.
        /// </response>
        /// <response code="409">
        /// - The email has been used. (SPCI-409-2): old email.
        /// </response>
        /// <response code="500">
        /// - Loyalty User was not able to create (SPCI-500): if the user not exists in Loyalty.
        /// - Unhandled error, is necesary validate the log.
        /// </response>
        [HttpPatch]
        [Route("UpdateUserProfile")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(CambiarCuentaRespuesta))]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(401, Type = typeof(Error))]
        [ProducesResponseType(409, Type = typeof(Error))]
        [ProducesResponseType(500, Type = typeof(Error))]
        public IActionResult UpdateUserProfile([FromBody] PerfilUsuario user) => this.Ok(user);
        #endregion

        #region RecoveryUserPassword
        /// <summary>
        /// RecoveryUserPassword
        /// </summary>
        /// <param name="user">*User information with the new password.*</param>
        /// <returns>Returns the requested object to update.</returns>
        /// <remarks>
        /// 
        /// Recovery an user's password, based on the requested data
        ///
        /// </remarks>
        /// <response code="200">The password was recovered successfully.</response>
        /// <response code="401">
        /// - Invalid token (SPCI-401-7): the given token is not valid.
        /// - Invalid token (SPCI-401-8): the scope header is invalid.
        /// </response>
        /// <response code="500">
        /// - ChangeUserPassword User Not Found in Auth0 (SPCI-500): error.
        /// - Invalid grant to recover password (SPCI-500): error.
        /// - RecoveryUserPassword User Not Found in Auth0. (SPCI-500): error.
        /// - Unhandled error, is necesary validate the log.
        /// </response>
        [HttpPost]
        [Route("RecoveryUserPassword")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(CambiarCuentaRespuesta))]
        [ProducesResponseType(401, Type = typeof(Error))]
        [ProducesResponseType(500, Type = typeof(Error))]
        public IActionResult RecoveryUserPassword([FromBody] RecuperarContrasena user) => this.Ok(user);

        #endregion

        #region CancelUserAccount
        /// <summary>
        /// CancelUserAccount
        /// </summary>
        /// <param name="request">*User information with the cancel the account.*</param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// Endpoint in charge of canceling a user's account with the requested data.
        ///
        /// </remarks>
        /// <response code="200">The account is close correctly</response>
        /// <response code="401">
        /// - The username or password is incorrect (SPCI-401-1): incorrect data (wrong email or password).
        /// </response>
        /// <response code="500">
        /// - CancelUserAccount User Not Found in Auth0 (SPCI-500): error.
        /// - CancelUserAccount invalid grant.(SPCI-500): error.
        /// - Generic error from Auth0 Service.(SPCI-500): error.
        /// - Unhandled error, is necesary validate the log.
        /// </response>
        [HttpPost]
        [Route("CancelUserAccount")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(CancelarCuentaRespuesta))]
        [ProducesResponseType(401, Type = typeof(Error))]
        [ProducesResponseType(500, Type = typeof(Error))]
        public IActionResult CancelUserAccount([FromBody] CancelarCuenta request) => this.Ok(request);
        #endregion
    }   
}