using System.Net;

namespace RedocPro.Models.Responses
{
    public class ErrorResponse
    {
        public HttpStatusCode HttpCode { get; set; }

        public string ErrorCode { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
    }
}
