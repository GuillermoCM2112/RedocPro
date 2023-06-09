using Newtonsoft.Json;

namespace RedocPro.Environments
{
	public static class TestEnvironment
	{
		public static string GenerateTestEnvironment()
		{
			return JsonConvert.SerializeObject(new PostmanEnvironment()
			{
				name = "TEST_ENVIRONMENT",
				values = new List<PostmanVariable>
						 {
							new PostmanVariable()
							{
								key = "baseUrl",
								value = "https://petstore.swagger"
							},
							new PostmanVariable()
							{
								key = "baseUrl_dev",
								value = "https://dev.petstore.swagger"
							},
							new PostmanVariable()
							{
								key = "baseUrl_qa",
								value = "https://qa.petstore.swagger"
							}
						 }
			}, Formatting.Indented);
		}
	}

	public class PostmanEnvironment
	{
		public string id { get; set; } = string.Empty;
		public string name { get; set; } = string.Empty;
		public List<PostmanVariable> values { get; set; } = new List<PostmanVariable>();
		public string _postman_variable_scope { get; set; } = "environment";
		public DateTime _postman_exported_at { get; set; } = DateTime.Now;
		public string _postman_exported_using { get; set; } = string.Empty;
	}

	public class PostmanVariable
	{
		public string key { get; set; } = string.Empty;
		public string value { get; set; } = string.Empty;
		public bool enabled { get; set; } = true;
		public string type { get; set; } = "any";
	}
}
