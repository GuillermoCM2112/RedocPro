using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedocPro.Entities;
namespace RedocPro.Controllers
{
    [ApiController]
    [Route("ciam/api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class NethoneController : ControllerBase
    {
        private readonly ILogger<NethoneController> logger;
        public NethoneController(
           ILogger<NethoneController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut] 
        [ProducesResponseType(200, Type = typeof(NethoneResponseConfirm))]
        public async Task<IActionResult> NethoneTransactionConfirm([FromBody] FlagsNethoneConfirm request)
        {
            return this.Ok("0.1.5");
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(NethoneResponseConfirm))]
        public async Task<IActionResult> NethoneTransaction([FromBody] NethoneTransactionRequest request)
        {
            return this.Ok("0.1.5");
        }

        [HttpPost]
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
        [ProducesResponseType(200, Type = typeof(JsonContent))]
        public async Task<IActionResult> NethoneRecommendationPay(string ObjNewCardRequest)
        {
            return this.Ok("0.1.5");
        }

    }
}
