using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class NethoneTransactionRequest
    {
        public NethoneTransactionRequest()
        {
        }

        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "merchant_reference")]
        public string Merchant_reference { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "payment_method")]
        public string Payment_method { get; set; } = "card";

        [JsonProperty(PropertyName = "user_reference")]
        public string User_reference { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "profiling_reference")]
        public string Profiling_reference { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "card_token")]
        public string Card_token { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "flags")]
        public List<FlagsNethoneProperties> Flags { get; set; } = new();

        [JsonProperty(PropertyName = "inquiry_id")]
        public long Inquiry_id { get; set; } = 0;
    }
}
