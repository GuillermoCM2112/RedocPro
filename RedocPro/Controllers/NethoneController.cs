using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Entities;
using RedocPro.Entities.RequestPayloads;
using RedocPro.Entities.ResponsePayloads;
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

        /// <summary>
        /// NethoneTransactionConfirm: Validates Nethone transaction integrity
        /// </summary>
        /// <param name="request">The Nethone flags to validate.</param>
        /// <response code="200">Returns payment token information.</response>
        /// <response code="404">Unhandled error, validate the error log.</response>
        /// <response code="402">Auth0 error,validate the error log.</response>
        /// <returns>Payment token information.</returns> 
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AccessResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(200, Type = typeof(NethoneResponseConfirm))]
        public async Task<IActionResult> NethoneTransactionConfirm([FromBody] FlagsNethoneConfirm request)
        {
            return this.Ok("0.1.5");
        }



        /// <summary>
        /// NethoneTransaction: Process Nethone transaction
        /// </summary>
        /// <param name="request">The Nethone flags to validate.</param>
        /// <response code="200">Returns payment token information.</response>
        /// <response code="404">Unhandled error, validate the error log.</response>
        /// <response code="402">Auth0 error,validate the error log.</response>
        /// <returns>Payment token information.</returns> 
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccessResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(200, Type = typeof(NethoneResponseConfirm))]
        public async Task<IActionResult> NethoneTransaction([FromBody] NethoneTransactionRequest request)
        {
            return this.Ok("0.1.5");
        }



        /// <summary>
        /// NethoneRecommendation: Process Nethone recommendation
        /// </summary>
        /// <param name="request">The Nethone flags to validate.</param>
        /// <response code="200">Returns payment token information.</response>
        /// <response code="404">Unhandled error, validate the error log.</response>
        /// <response code="402">Auth0 error,validate the error log.</response>
        /// <returns>Payment token information.</returns> 
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccessResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
