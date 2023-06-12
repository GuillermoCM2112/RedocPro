using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class FlagsNethoneConfirm
    {
        public FlagsNethoneConfirm()
        {
        }

        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        [JsonProperty(PropertyName = "flags", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<FlagsNethoneProperties> Flags { get; set; } = new();
    }
}
