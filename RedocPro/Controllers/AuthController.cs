using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Models;

namespace RedocPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Updates the partial information of a user.
        /// </summary>
        /// <param name="user">*User information.*</param>
        /// <returns>Returns the requested object to update.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH api/Auth/RecoveryUserPassword
        ///     {
        ///         "prop1": "...",
        ///         "prop2": "...",
        ///         "prop3": "...",
        ///         "prop4": "...",
        ///         "prop5": "...",
        ///         "prop6": "...",
        ///         "prop7": "...",
        ///         "prop8": ".",
        ///         "prop9": "...",
        ///         "prop510": "..."
        ///     }
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
        [ProducesResponseType(200, Type = typeof(PerfilUsuario))]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(401, Type = typeof(Error))]
        [ProducesResponseType(409, Type = typeof(Error))]
        [ProducesResponseType(500)]
        public IActionResult UpdateUserProfile([FromBody] PerfilUsuario user) => this.Ok(user);
    }
}
