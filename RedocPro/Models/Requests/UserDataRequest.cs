using RedocPro.Descriptions;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models.Requests
{
	public class UserDataRequest
	{
		[Required]
		[SwaggerSchema(Description = PropertiesDescriptions.FirstNameDescription)]
		[SwaggerSchemaExample("+521234567890")]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]
		[SwaggerSchema(Description = "DeviceId")]
		[SwaggerSchemaExample("1")]
		public string DeviceId { get; set; } = string.Empty;
	}
}
