using RedocPro.Descriptions;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models.Responses
{
    public class RefreshResponse
    {
        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.RefreshToken)]
        [SwaggerSchemaExample("v1.McGUUd_CL7lc4UjVa2jlAgAG7lCyif14ItPqa_VyqXbeLfR1IpHdqu02QT3XuSsGekr0zfh3PJBszwsWGnC8lJw")]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
