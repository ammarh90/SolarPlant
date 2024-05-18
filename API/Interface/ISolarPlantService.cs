using Microsoft.AspNetCore.Mvc;
using SolarPlant.DataLayer.Entity;
using SolarPlant.Helper;

namespace SolarPlant.API.Interface
{
    public interface ISolarPlantService
    {
        Task<List<SolarPowerPanel>> GetSolarPowerPlants();
        Task<SolarPowerPanel> GetSolarPowerPlantsByIdAync(int id);
        Task<SolarPowerPanel> UpdateSolarPowerPlant(int id, SolarPowerPanel updatedPlant);
        //Task<IActionResult> AddSolarPlant(SolarPowerPanel addSolarPlant);
        //Task<IActionResult> DeleteSolarPlant(int id);
        Task<List<Timeseries>> CalculateActualProduction(int solarPanelId, string granularity, DateTime startDate, DateTime endDate);
        Task<List<Timeseries>> CalculateForecastProduction(int solarId, string granularity, DateTime startDate, DateTime endDate);
    }
}

