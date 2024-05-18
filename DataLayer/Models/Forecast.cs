using Newtonsoft.Json;
using static SolarPlant.DataLayer.Models.Weather;

namespace SolarPlant.DataLayer.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]

        public List<Forecastday> forecastday { get; set; }

    }
}
