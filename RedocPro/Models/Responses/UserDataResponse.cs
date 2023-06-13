using RedocPro.Descriptions;
using Swashbuckle.AspNetCore.Annotations;

namespace RedocPro.Models.Responses
{
	public class UserDataResponse
	{
		[SwaggerSchema(Description = PropertiesDescriptions.FirstNameDescription)]
		public string FirstName { get; set; } = string.Empty;

		[SwaggerSchema(Description = PropertiesDescriptions.LastNameDescription)]
		public string LastName { get; set; } = string.Empty;

		[SwaggerSchema(Description = PropertiesDescriptions.EmailDescription)]
		public string Email { get; set; } = string.Empty;
	}
}
