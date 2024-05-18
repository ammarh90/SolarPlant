using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace SolarPlant.DataLayer.Models
{
    public class ApplicationUser
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
