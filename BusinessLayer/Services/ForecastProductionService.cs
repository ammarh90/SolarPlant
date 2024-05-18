using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SolarPlant.API.Interface;
using SolarPlant.DataLayer;
using SolarPlant.DataLayer.Models;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;
using System.Text.Json;
using Nancy.Json;
using Nancy.Responses;


namespace SolarPlant.BusinessLayer.Services
{
    public class ForecastProductionService : IForecastProductionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly SolarDbContext _context;
        private string _apiKey;

        public ForecastProductionService(IHttpClientFactory httpClientFactory, IConfiguration configuration, SolarDbContext context)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _context = context;
            _apiKey = _configuration["Weather:APIKey"];

        }

        public async Task<Root> GetForecastProduction() //int id
        {

            try
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["q"] = "paris";
                query["days"] = Convert.ToString(1);
                query["key"] = _configuration["Weather:APIKey"];
                HttpClient webClient = _httpClientFactory.CreateClient("Weather");
                HttpResponseMessage response = await webClient.GetAsync(webClient.BaseAddress + "marine.json?" + query.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Root>().Result;

                    //Root temp = JsonConvert.DeserializeObject<Root>(jsonResult.ToString());
                    ///Root temp = JsonConvert.DeserializeObject<Root>(File.WriteAllText(jsonResult.ToString()));

                    //var power = _context.SolarPowerPlants
                    //.Where(e => e.SolarId == id)
                    //.Select(e => e.InstalledPowerInKW)
                    //.FirstOrDefault();
                    
                    //try to deserilize object to use some property to get weather forcast calculation for solar id

                }
                throw new Exception("Erorr");

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
