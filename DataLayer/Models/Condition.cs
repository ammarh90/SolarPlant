using Newtonsoft.Json;

namespace SolarPlant.DataLayer.Models
{
    public class Condition
    {
        [JsonProperty("text")]

        public string text { get; set; }
        [JsonProperty("icon")]

        public string icon { get; set; }
        [JsonProperty("code")]

        public int code { get; set; }
    }
}
