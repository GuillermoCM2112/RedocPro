﻿using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
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
    }
}
