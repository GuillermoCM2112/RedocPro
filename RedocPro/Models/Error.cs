using System.Text.Json.Serialization;

namespace RedocPro.Models
{
    public class Error
    {
        [JsonPropertyName("errorCode")]
        public string? ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }
    }
}
