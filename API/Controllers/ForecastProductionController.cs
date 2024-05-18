using Microsoft.AspNetCore.Mvc;
using SolarPlant.API.Interface;
using SolarPlant.DataLayer.Models;

namespace SolarPlant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class ForecastProductionController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IForecastProductionService _weatherForecastService;
        private readonly ILogger<ForecastProductionController> _logger;

        public ForecastProductionController(IHttpClientFactory httpClientFactory, IForecastProductionService weatherForecastService, ILogger<ForecastProductionController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _weatherForecastService = weatherForecastService;
            _logger = logger;
        }

        [HttpGet]
        [Route("forcast")]
        public async Task<Root> ForecastProduction()
        {
            try
            {
                return await _weatherForecastService.GetForecastProduction();

            }
            catch (Exception ex)
            {
                var errorMessage = "An error occurred while fetching solar power plants.";
                _logger.LogError(ex, errorMessage);

                throw new Exception(errorMessage, ex);
            }
        }
    }
}
