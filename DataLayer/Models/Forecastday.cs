using Newtonsoft.Json;
using static SolarPlant.DataLayer.Models.Weather;

namespace SolarPlant.DataLayer.Models
{
    public class Forecastday
    {
        [JsonProperty("date")]

        public string date { get; set; }
        [JsonProperty("date_epoch")]

        public int date_epoch { get; set; }
        [JsonProperty("day")]

        public Day day { get; set; }
        [JsonProperty("astro")]

        public Astro astro { get; set; }
        [JsonProperty("hour")]

        public List<Hour> hour { get; set; }
    }
}
