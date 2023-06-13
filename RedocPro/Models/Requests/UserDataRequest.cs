using RedocPro.Descriptions;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models.Requests
{
    public class UserDataRequest
    {
        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.PhoneNumber)]
        [SwaggerSchemaExample("+521234567890")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = "Device identifier")]
        [SwaggerSchemaExample("A1B2C3D4E5")]
        public string DeviceId { get; set; } = string.Empty;
    }
}
