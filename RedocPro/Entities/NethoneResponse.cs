using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RedocPro.Entities
{
    public class NethoneResponse : NethoneResponseBase
    {
        [JsonProperty(PropertyName = "advice", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Advice { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "info", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Info Info { get; set; } = new();
    }

    public class Info
    {
        [JsonProperty(PropertyName = "fingerprint", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Fingerprint Fingerprint { get; set; } = new();

        [JsonProperty(PropertyName = "rules", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<Rule> Rules { get; set; } = new();
    }

    public class Fingerprint
    {
        [JsonProperty(PropertyName = "signals", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Signals { get; set; } = new List<string>();

        [JsonProperty(PropertyName = "profiling_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Profiling_type { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "attempt_reference", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Attempt_reference { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "created_date", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Created_date { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "ip", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Ip { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "network", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Network Network { get; set; } = new();

        [JsonProperty(PropertyName = "device", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Devices Device { get; set; } = new();
    }

    public class Network
    {
        [JsonProperty(PropertyName = "link_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Link_type { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "user_declared_ip", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public DeclaredIp User_declared_ip { get; set; } = new();
    }

    public class DeclaredIp
    {
        [JsonProperty(PropertyName = "addr", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Addr { get; set; } = string.Empty;
    }

    public class Devices
    {
        [JsonProperty(PropertyName = "carrier", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Carrier Carrier { get; set; } = new();

        [JsonProperty(PropertyName = "disk", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Disk Disk { get; set; } = new();

        [JsonProperty(PropertyName = "device", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public DeviceInside Device { get; set; } = new();

        [JsonProperty(PropertyName = "battery", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Batterys Battery { get; set; } = new();
    }

    public class Carrier
    {
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "country", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "iso_country_code", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Iso_country_code { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "mobile_country_code", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile_country_code { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "mobile_network_code", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile_network_code { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "allows_voip", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Allows_voip { get; set; } = false;

        [JsonProperty(PropertyName = "icc_card", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Icc_card { get; set; } = false;

        [JsonProperty(PropertyName = "roaming", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Roaming { get; set; } = false;

        [JsonProperty(PropertyName = "sim_state", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Sim_state { get; set; } = 0;

        [JsonProperty(PropertyName = "radio_phone_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Radio_phone_type { get; set; } = 0;

        [JsonProperty(PropertyName = "network_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Network_type { get; set; } = string.Empty;
    }

    public class Disk
    {
        [JsonProperty(PropertyName = "total_space", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile_network_code { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "free_space_root", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Free_space_root { get; set; } = string.Empty;
    }

    public class DeviceInside
    {
        [JsonProperty(PropertyName = "android_id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Android_id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "model", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "manufacturer", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Manufacturer { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "brand", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "build_fingerprint", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Build_fingerprint { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "product", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "http_proxy", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Http_proxy { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "wifi_on", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Wifi_on { get; set; } = false;

        [JsonProperty(PropertyName = "bt_on", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Bt_on { get; set; } = false;

        [JsonProperty(PropertyName = "uptime_ms", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Uptime_ms { get; set; } = string.Empty;
    }

    public class Batterys
    {
        [JsonProperty(PropertyName = "battery_health", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Battery_health { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "extra_health", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_health { get; set; } = 0;

        [JsonProperty(PropertyName = "level", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public double Levelextra_status { get; set; } = 0.0;

        [JsonProperty(PropertyName = "extra_level", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_level { get; set; } = 0;

        [JsonProperty(PropertyName = "extra_scale_level", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_scale_level { get; set; } = 0;

        [JsonProperty(PropertyName = "battery", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Battery { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "extra_plugged", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_plugged { get; set; } = 0;

        [JsonProperty(PropertyName = "charging_state", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Charging_state { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "extra_status", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_status { get; set; } = 0;

        [JsonProperty(PropertyName = "extra_present", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Extra_present { get; set; } = false;

        [JsonProperty(PropertyName = "extra_technology", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Extra_technology { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "extra_temperature", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_temperature { get; set; } = 0;

        [JsonProperty(PropertyName = "extra_voltage", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Extra_voltage { get; set; } = 0;
    }

    public class Rule
    {
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "id_str", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Id_str { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "advice", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Advice { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "mode", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; } = string.Empty;
    }
}
