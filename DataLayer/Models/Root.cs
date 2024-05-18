using Newtonsoft.Json;

namespace SolarPlant.DataLayer.Models
{
    public class Root
    {
        [JsonProperty("location")]

        public Location location { get; set; }
        [JsonProperty("forecast")]

        public Forecast forecast { get; set; }
    }
}
