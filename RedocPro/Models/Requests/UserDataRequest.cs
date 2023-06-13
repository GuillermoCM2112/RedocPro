using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models.Requests
{
	public class UserDataRequest
	{
		///<example>+521234567890</example>
		[Required]
		public string PhoneNumber { get; set; } = string.Empty;

		///<example>1</example>
		[Required]
		public string AnotherId { get; set; } = string.Empty;
	}
}
