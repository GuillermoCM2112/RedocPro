using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class FlagsNethoneProperties
    {
        public FlagsNethoneProperties()
        {
        }

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "value")]
        public bool Value { get; set; } = true;
    }
}
