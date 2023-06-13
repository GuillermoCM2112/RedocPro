using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class NewNethoneRequest
    {
        public string UserId { get; set; } = string.Empty;

        public string AttemptReference { get; set; } = string.Empty;

        public string InquiryType { get; set; } = string.Empty;

        public string EventType { get; set; } = string.Empty;

        public string DeviceId { get; set; } = string.Empty;

        public bool RequiredEvent { get; set; } = false;
    }

    public class InquiryTypes
    {
        public static readonly string Transaction = "TRANSACTION";
        public static readonly string Register = "REGISTER";
        public static readonly string Submit = "SUBMIT";
        public static readonly string Confirm = "CONFIRM";
        public static readonly string Login = "LOGIN";
    }
}
