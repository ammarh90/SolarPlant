using Newtonsoft.Json;

namespace SolarPlant.DataLayer.Models
{
    public class Astro
    {
        [JsonProperty("sunrise")]

        public string sunrise { get; set; }
        [JsonProperty("sunset")]

        public string sunset { get; set; }
        [JsonProperty("moonrise")]

        public string moonrise { get; set; }
        [JsonProperty("moonset")]

        public string moonset { get; set; }
        [JsonProperty("moon_phase")]

        public string moon_phase { get; set; }
        [JsonProperty("moon_illumination")]

        public string moon_illumination { get; set; }
    }
}
