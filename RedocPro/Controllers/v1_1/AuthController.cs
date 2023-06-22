using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Models;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RedocPro.v1_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion(1.1)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag(ControllersDescriptions.AuthController)]
    public class AuthController : ControllerBase
    {

        #region CancelUserAccount
        [HttpPost]
        [MapToApiVersion(1.1)]
        [SwaggerSchemaExample(nameof(CancelarCuenta))]
        [SwaggerOperation(OperationId = nameof(CancelUserAccount), Description = EndpointsDescriptions.CancelUserAccountDescription)]
        [SwaggerResponse(200, EndpointsDescriptions.CancelUserAccount200Description, type: typeof(CancelarCuentaRespuesta))]
        [SwaggerResponse(401, EndpointsDescriptions.CancelUserAccount401Description, type: typeof(Error))]
        [SwaggerResponse(500, EndpointsDescriptions.CancelUserAccount500Description, type: typeof(Error))]
        public IActionResult CancelUserAccount([FromBody] CancelarCuenta request) => this.Ok(request);
        #endregion
    }
}