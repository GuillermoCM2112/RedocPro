using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class NethoneResponseBase
    {
        public NethoneResponseBase()
        {
        }

        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "id_str", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Id_str { get; set; } = string.Empty;
    }
}
