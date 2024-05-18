using Newtonsoft.Json;

namespace SolarPlant.DataLayer.Models
{
    public class Day
    {
        [JsonProperty("maxtemp_c")]

        public double maxtemp_c { get; set; }
        [JsonProperty("maxtemp_f")]

        public double maxtemp_f { get; set; }
        [JsonProperty("mintemp_c")]

        public double mintemp_c { get; set; }
        [JsonProperty("mintemp_f")]

        public double mintemp_f { get; set; }
        [JsonProperty("avgtemp_c")]

        public double avgtemp_c { get; set; }
        [JsonProperty("avgtemp_f")]

        public double avgtemp_f { get; set; }
        [JsonProperty("maxwind_mph")]

        public double maxwind_mph { get; set; }
        [JsonProperty("maxwind_kph")]

        public double maxwind_kph { get; set; }
        [JsonProperty("totalprecip_mm")]

        public string totalprecip_mm { get; set; }
        [JsonProperty("totalprecip_in")]

        public string totalprecip_in { get; set; }
        [JsonProperty("avgvis_km")]

        public string avgvis_km { get; set; }
        [JsonProperty("avgvis_miles")]

        public string avgvis_miles { get; set; }
        [JsonProperty("avghumidity")]

        public string avghumidity { get; set; }
        [JsonProperty("daily_will_it_rain")]

        public int daily_will_it_rain { get; set; }
        [JsonProperty("daily_chance_of_rain")]

        public int daily_chance_of_rain { get; set; }
        [JsonProperty("daily_will_it_snow")]

        public int daily_will_it_snow { get; set; }
        [JsonProperty("daily_chance_of_snow")]

        public int daily_chance_of_snow { get; set; }
        [JsonProperty("condition")]

        public Condition condition { get; set; }
        [JsonProperty("uv")]

        public string uv { get; set; }

    }
}
