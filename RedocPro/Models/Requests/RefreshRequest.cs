using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models.Requests
{
	public class RefreshRequest
	{
		/// <example>v1.McGUUd_CL7lc4UjVa2jlAgAG7lCyif14ItPqa_VyqXbeLfR1IpHdqu02QT3XuSsGekr0zfh3PJBszwsWGnC8lJw</example>
		[Required]
		public string RefreshToken { get; set; } = string.Empty;
	}
}
