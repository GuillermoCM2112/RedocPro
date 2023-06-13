using RedocPro.Descriptions;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;

namespace RedocPro.Models.Requests
{
	public class GetUserProfileRequest
	{
		[SwaggerSchema(Description = "User Id")]
		[SwaggerSchemaExample("auth0|63b477d3b85540fe7e870500")]
		public string? UserId { get; set; }

		[SwaggerSchema(Description = PropertiesDescriptions.PhoneNumber)]
		[SwaggerSchemaExample("+521234567890")]
		public string? PhoneNumber { get; set; }
	}
}
