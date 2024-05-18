using Newtonsoft.Json;

namespace SolarPlant.DataLayer.Models
{
    public class Hour
    {
        [JsonProperty("time_epoch")]
        public int time_epoch { get; set; }
        [JsonProperty("time")]

        public string time { get; set; }
        [JsonProperty("temp_c")]

        public double temp_c { get; set; }
        [JsonProperty("temp_f")]

        public double temp_f { get; set; }
        [JsonProperty("is_day")]

        public int is_day { get; set; }
        [JsonProperty("condition")]

        public Condition condition { get; set; }
        [JsonProperty("wind_mph")]

        public double wind_mph { get; set; }
        [JsonProperty("wind_kph")]

        public double wind_kph { get; set; }
        [JsonProperty("wind_degree")]
        public int wind_degree { get; set; }
        [JsonProperty("wind_dir")]

        public string wind_dir { get; set; }
        [JsonProperty("pressure_mb")]

        public string pressure_mb { get; set; }
        [JsonProperty("pressure_in")]

        public double pressure_in { get; set; }
        [JsonProperty("precip_mm")]

        public string precip_mm { get; set; }
        [JsonProperty("precip_in")]

        public string precip_in { get; set; }
        [JsonProperty("humidity")]

        public int humidity { get; set; }
        [JsonProperty("cloud")]

        public int cloud { get; set; }
        [JsonProperty("feelslike_c")]

        public double feelslike_c { get; set; }
        [JsonProperty("feelslike_f")]

        public double feelslike_f { get; set; }
        [JsonProperty("windchill_c")]

        public double windchill_c { get; set; }
        [JsonProperty("windchill_f")]

        public double windchill_f { get; set; }
        [JsonProperty("heatindex_c")]

        public double heatindex_c { get; set; }
        [JsonProperty("heatindex_f")]

        public double heatindex_f { get; set; }
        [JsonProperty("dewpoint_c")]

        public double dewpoint_c { get; set; }
        [JsonProperty("dewpoint_f")]

        public double dewpoint_f { get; set; }
        [JsonProperty("will_it_rain")]

        public int will_it_rain { get; set; }
        [JsonProperty("chance_of_rain")]

        public int chance_of_rain { get; set; }
        [JsonProperty("will_it_snow")]

        public int will_it_snow { get; set; }
        [JsonProperty("chance_of_snow")]

        public int chance_of_snow { get; set; }
        [JsonProperty("vis_km")]

        public string vis_km { get; set; }
        [JsonProperty("vis_miles")]

        public string vis_miles { get; set; }
        [JsonProperty("gust_mph")]

        public string gust_mph { get; set; }
        [JsonProperty("gust_kph")]

        public double gust_kph { get; set; }
        [JsonProperty("sig_ht_mt")]

        public double sig_ht_mt { get; set; }
        [JsonProperty("swell_ht_mt")]

        public double swell_ht_mt { get; set; }
        [JsonProperty("swell_ht_ft ")]

        public double swell_ht_ft { get; set; }
        [JsonProperty("swell_dir")]

        public string swell_dir { get; set; }
        [JsonProperty("swell_dir_16_point")]

        public string swell_dir_16_point { get; set; }
        [JsonProperty("swell_period_secs")]

        public double swell_period_secs { get; set; }
        [JsonProperty("uv")]

        public string uv { get; set; }
    }
}
