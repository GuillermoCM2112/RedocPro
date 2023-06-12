namespace RedocPro.Models.Requests
{
	public class GetUserProfileRequest
	{
		/// <example>auth0|63b477d3b85540fe7e870500</example>
		public string? UserId { get; set; }

		/// <example>+525544332211</example>
		public string? PhoneNumber { get; set; }
	}
}
