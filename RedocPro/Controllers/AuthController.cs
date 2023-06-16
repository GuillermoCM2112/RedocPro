using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using RedocPro.Models;
using RedocPro.Models.Requests;
using RedocPro.Models.Responses;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RedocPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion(1.0)]
    [ApiVersion(1.1)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag(ControllersDescriptions.AuthController)]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(Login), Description = EndpointsDescriptions.LoginDescription)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Response", Type = typeof(AccessResponse))]
        [SwaggerResponse(401, EndpointsDescriptions.Login401Description, type: typeof(Error))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(Error))]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return this.Ok();
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(Signup), Description = EndpointsDescriptions.SignupDescription)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Response", Type = typeof(AccessResponse))]
        [SwaggerResponse(400, EndpointsDescriptions.Signup400Description, type: typeof(Error))]
        [SwaggerResponse(409, EndpointsDescriptions.Signup409Description, type: typeof(Error))]
        [SwaggerResponse(421, EndpointsDescriptions.Signup421Description, type: typeof(Error))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(Error))]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            return this.Ok();
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(RefreshToken), Description = EndpointsDescriptions.RefreshTokenDescription)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Response", Type = typeof(AccessResponse))]
        [SwaggerResponse(401, EndpointsDescriptions.RefreshToken401Description, type: typeof(Error))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(Error))]
        public IActionResult RefreshToken([FromBody] RefreshRequest request)
        {
            return this.Ok();
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(ChangeUserPassword), Description = EndpointsDescriptions.ChangeUserPassword)]
        [SwaggerResponse(200, "Response", type: typeof(UserChangeResponse))]
        [SwaggerResponse(404, "SPCI-404: User not found", type: typeof(Error))]
        public IActionResult ChangeUserPassword([FromBody] UpdatePasswordRequest request)
        {
            return this.Ok();
        }


        [HttpPost]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(ChangeUserProperty), Description = EndpointsDescriptions.ChangeUserProperty)]
        [SwaggerResponse(200, "Returns a 200 if the user property change.")]
        [SwaggerResponse(404, "SPCI-404: User not found", type: typeof(Error))]
        public IActionResult ChangeUserProperty([FromBody] UpdateUserRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(UserValidation), Description = EndpointsDescriptions.UserValidation)]
        [SwaggerResponse(200, "Response", type: typeof(UserValidationResponse))]
        [SwaggerResponse(404, "SPCI-404: User not found", type: typeof(Error))]
        public IActionResult UserValidation([FromQuery] UserValidationRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(GetTransversalUserData), Description = EndpointsDescriptions.GetTransversalUserDataDescription)]
        [SwaggerResponse(200, "Response", type: typeof(UserDataResponse))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
        public IActionResult GetTransversalUserData([FromQuery] UserDataRequest request)
        {
            return this.Ok();
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(RevokeRefreshToken), Description = EndpointsDescriptions.RevokeRefreshTokenDescription)]
        [SwaggerResponse(200, "Response", type: typeof(RefreshResponse))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
        public IActionResult RevokeRefreshToken([FromBody] RefreshRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(GetUserProfile), Description = EndpointsDescriptions.GetUserProfileDescription)]
        [SwaggerResponse(200, "Response", type: typeof(UserChangeResponse))]
        [SwaggerResponse(500, "Unhandled error, validate the error log.", type: typeof(ErrorResponse))]
        public IActionResult GetUserProfile([FromQuery] GetUserProfileRequest request)
        {
            return this.Ok();
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [SwaggerOperation(OperationId = nameof(TokenValidator), Description = EndpointsDescriptions.TokenValidatorDescription)]
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
        [MapToApiVersion(1.0)]
        //[Route(nameof(UpdateUserProfile))]
        [SwaggerSchemaExample(nameof(PerfilUsuario))]
        [SwaggerOperation(OperationId = nameof(UpdateUserProfile), Description = EndpointsDescriptions.UpdateUserProfileDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.UpdateUserProfile200Description, type: typeof(CambiarCuentaRespuesta))]
        [SwaggerResponse(400, EndpointsDescriptions.UpdateUserProfile400Description, type: typeof(Error))]
        [SwaggerResponse(401, EndpointsDescriptions.UpdateUserProfile401Description, type: typeof(Error))]
        [SwaggerResponse(409, EndpointsDescriptions.UpdateUserProfile409Description, type: typeof(Error))]
        [SwaggerResponse(500, EndpointsDescriptions.UpdateUserProfile500Description, type: typeof(Error))]
        public IActionResult UpdateUserProfile([FromBody] PerfilUsuario user) => this.Ok(user);
        #endregion

        #region RecoveryUserPassword
        [HttpPost]
        [MapToApiVersion(1.0)]
        //[Route(nameof(RecoveryUserPassword))]
        [SwaggerSchemaExample(nameof(RecuperarContrasena))]
        [SwaggerOperation(OperationId = nameof(RecoveryUserPassword), Description = EndpointsDescriptions.RecoveryUserPasswordDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.RecoveryUserPassword200Description, type: typeof(CambiarCuentaRespuesta))]
        [SwaggerResponse(401, EndpointsDescriptions.RecoveryUserPassword401Description, type: typeof(Error))]
        [SwaggerResponse(500, EndpointsDescriptions.RecoveryUserPassword500Description, type: typeof(Error))]
        public IActionResult RecoveryUserPassword([FromBody] RecuperarContrasena user) => this.Ok(user);
        #endregion

        #region CancelUserAccount
        [HttpPost]
        //[Route(nameof(CancelUserAccount))]
        [MapToApiVersion(1.0)]
        [SwaggerSchemaExample(nameof(CancelarCuenta))]
        [SwaggerOperation(OperationId = nameof(CancelUserAccount), Description = EndpointsDescriptions.CancelUserAccountDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.CancelUserAccount200Description, type: typeof(CancelarCuentaRespuesta))]
        [SwaggerResponse(401, EndpointsDescriptions.CancelUserAccount401Description, type: typeof(Error))]
        [SwaggerResponse(500, EndpointsDescriptions.CancelUserAccount500Description, type: typeof(Error))]
        public IActionResult CancelUserAccount([FromBody] CancelarCuenta request) => this.Ok(request);

        [HttpPost]
        [Route(nameof(CancelUserAccount))]
        [MapToApiVersion(1.1)]
        [SwaggerSchemaExample(nameof(CancelarCuenta))]
        [SwaggerOperation(OperationId = nameof(CancelUserAccount), Description = EndpointsDescriptions.CancelUserAccountDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.CancelUserAccount200Description, type: typeof(CancelarCuentaRespuesta))]
        [SwaggerResponse(401, EndpointsDescriptions.CancelUserAccount401Description, type: typeof(Error))]
        [SwaggerResponse(500, EndpointsDescriptions.CancelUserAccount500Description, type: typeof(Error))]
        public IActionResult CancelUserAccount_1_1([FromBody] CancelarCuenta request) => this.Ok(request);
        #endregion
    }
}