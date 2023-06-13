using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class NethoneResponseConfirm : NethoneResponseBase
    {
        public NethoneResponseConfirm()
        {
        }

        [JsonProperty(PropertyName = "reference", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Reference { get; set; } = string.Empty;
    }
}
