using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Descriptions;
using RedocPro.Entities;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
using RedocPro.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace RedocPro.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag(Descriptions.ControllersDescriptions.NethoneController)]
    public class NethoneController : ControllerBase
    {
        private readonly ILogger<NethoneController> logger;
        public NethoneController(
           ILogger<NethoneController> logger)
        {
            this.logger = logger;
        }
         
        /// <param name="request">The Nethone flags to validate.</param> >
        /// <returns>Payment token information.</returns> 
        [HttpPut]  
        [SwaggerOperation(OperationId = nameof(NethoneTransactionConfirm), Description = EndpointsDescriptions.NethoneTransactionConfirm)]
        [SwaggerResponse(200, "Response", type: typeof(NethoneResponseConfirm))]
        [SwaggerResponse(404, "Status not found.", type: typeof(ErrorResponse))]
        [SwaggerResponse(402, "Payment Required,verify internal log for more information.", type: typeof(ErrorResponse))]
        [SwaggerResponse(401, "Unauthorized,verify internal log for more information.", type: typeof(ErrorResponse))]
        public async Task<IActionResult> NethoneTransactionConfirm([FromBody] FlagsNethoneConfirm request)
        {
            return this.Ok("0.1.5");
        }
         
        /// <param name="request">The Nethone flags to validate.</param> >
        /// <returns>Payment token information.</returns> 
        [HttpPost]
        [SwaggerOperation(OperationId = nameof(NethoneTransaction), Description = EndpointsDescriptions.NethoneTransaction)]
        [SwaggerResponse(200, "Response", type: typeof(NethoneResponseConfirm))]
        [SwaggerResponse(404, "Status not found.", type: typeof(ErrorResponse))]
        [SwaggerResponse(402, "Payment Required,verify internal log for more information.", type: typeof(ErrorResponse))]  
        [ProducesResponseType(200, Type = typeof(NethoneResponseConfirm))]
        public async Task<IActionResult> NethoneTransaction([FromBody] NethoneTransactionRequest request)
        {
            return this.Ok("0.1.5");
        }


        
        /// <param name="request">The Nethone flags to validate.</param> >
        /// <returns>Payment token information.</returns> 
        [HttpPost]
        [SwaggerOperation(OperationId = nameof(NethoneRecommendation), Description = EndpointsDescriptions.NethoneRecommendation)]
        [SwaggerResponse(200, "Response", type: typeof(NethoneResponse))]
        [SwaggerResponse(404, "Status not found.", type: typeof(ErrorResponse))]
        [SwaggerResponse(402, "Payment Required,verify internal log for more information.", type: typeof(ErrorResponse))]
        [ProducesResponseType(200, Type = typeof(NethoneResponse))]
        public async Task<IActionResult> NethoneRecommendation([FromBody] NewNethoneRequest request)
        {
            return this.Ok("0.1.5");
        }

        /// <summary>
        /// NethoneRecommendationPay: check if the data has suspicious or fraudulent activity
        /// </summary>
        /// <param name="ObjNewCardRequest">Object with data new card</param>
        /// <returns>Check recommendation pay</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(NethoneResponse))]
        public async Task<IActionResult> NethoneRecommendationPay(string ObjNewCardRequest)
        {
            return this.Ok("0.1.5");
        }

    }
}
