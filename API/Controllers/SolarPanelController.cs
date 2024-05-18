using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SolarPlant.API.Interface;
using SolarPlant.BusinessLayer.Services;
using SolarPlant.DataLayer;
using SolarPlant.DataLayer.Entity;
using SolarPlant.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarPlant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SolarPanelController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISolarPlantService _solarPlant;
        private readonly ILogger<SolarPanelController> _logger;
        private readonly SolarDbContext _context;

        public SolarPanelController(IHttpClientFactory httpClientFactory, ISolarPlantService solarPlant, ILogger<SolarPanelController> logger,SolarDbContext context)
        {
            _httpClientFactory = httpClientFactory;
            _solarPlant = solarPlant;
            _logger = logger;
            _context = context;
        }


        [HttpGet("solarpanel")]
        public async Task<List<SolarPowerPanel>> GetSolarPanel()
        {
            try
            {
                return await _solarPlant.GetSolarPowerPlants();

            }
            catch (Exception ex)
            {
                var errorMessage = "An error occurred while fetching solar power plants.";
                _logger.LogError(ex, errorMessage);

                throw new Exception(errorMessage, ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<SolarPowerPanel> GetSolarPanel(int id)
        {
            try
            {

                return await _solarPlant.GetSolarPowerPlantsByIdAync(id);

            }
            catch (Exception ex)
            {
                var errorMessage = "An error occurred while fetching solar power plants.";
                _logger.LogError(ex, errorMessage);

                throw new Exception(errorMessage, ex);
            }
        }
        [HttpPost]
        public async Task<ActionResult<SolarPowerPanel>> CreateEmployee([FromBody] SolarPowerPanel panel)
        {
            try
            {
                if (panel == null || panel.ProductionDatas == null)
                    return BadRequest();

                foreach (var data in panel.ProductionDatas)
                {
                    _context.ProductionDatas.Add(data);
                    await _context.SaveChangesAsync();
                }

                // Add the employee to the database
                _context.SolarPowerPlants.Add(panel);
                await _context.SaveChangesAsync();

                //// Iterate through each job and add it to the database
                //foreach (var data in panel.ProductionDatas)
                //{
                //    _context.ProductionDatas.Add(data);
                //    await _context.SaveChangesAsync();
                //}

                // Return the created employee
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolarPlant(int id)
        {
            try
            {
                var solarPowerPlant = await _context.SolarPowerPlants.FindAsync(id);
                if (solarPowerPlant == null)
                {
                    return NotFound($"Solar power plant with ID {id} not found.");
                }

                _context.SolarPowerPlants.Remove(solarPowerPlant);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Solar power plant deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting solar power plant with ID: {id}");
                throw new Exception($"An error occurred while deleting solar power plant with ID: {id}", ex);
            }
        }


        [HttpGet("{solarPanelId}/timeseries")]
        public async Task<ActionResult<IEnumerable<Timeseries>>> GetTimeseries(int solarPanelId, string type, string granularity, DateTime startDate, DateTime endDate)
        {
            DateTimeConverter c = new DateTimeConverter();
            DateTime dt = (DateTime)c.ConvertFromString("2012-05-10");
            startDate = dt;
            endDate = dt;
            var timeseries = new List<Timeseries>();

            try
            {
                switch (type.ToLower())
                {
                    case "actual":
                        timeseries = await _solarPlant.CalculateActualProduction(solarPanelId, granularity, startDate, endDate);
                        break;
                    case "forecast":
                        timeseries = await _solarPlant.CalculateForecastProduction(solarPanelId, granularity, startDate, endDate);
                        break;
                    default:
                        return BadRequest("Invalid timeseries type.");
                }
            }
            catch (Exception ex) 
            {
                var errorMessage = "An error occurred while calculate solar power plants.";
                _logger.LogError(ex, errorMessage);
            }

            return Ok(timeseries);
        }

    }
}
