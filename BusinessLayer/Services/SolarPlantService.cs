using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx;
using MySqlX.XDevAPI;
using SolarPlant.API.Controllers;
using SolarPlant.API.Interface;
using SolarPlant.DataLayer;
using SolarPlant.DataLayer.Entity;
using SolarPlant.DataLayer.Models;
using SolarPlant.Helper;


namespace SolarPlant.BusinessLayer.Services
{
    public class SolarPlantService : ISolarPlantService
    {
        private readonly SolarDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SolarPlantService> _logger;


        public SolarPlantService(SolarDbContext context, IHttpClientFactory httpClientFactory, ILogger<SolarPlantService> logger)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<SolarPowerPanel>> GetSolarPowerPlants()
        {
            try
            {
                return await _context.SolarPowerPlants
                    .Include(l => l.ProductionDatas)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                var errorMessage = "An error occurred while fetching solar power plants.";
                _logger.LogError(ex, errorMessage);

                  throw new Exception(errorMessage, ex);
            }

        }
        public async Task<SolarPowerPanel> GetSolarPowerPlantsByIdAync(int id)
        {
            try
            {
                return await _context.SolarPowerPlants.Include(l => l.ProductionDatas).FirstOrDefaultAsync(l => l.SolarId == id);

            }
            catch (Exception ex)
            {
                var errorMessage = "An error occurred while fetching solar power plants by id.";
                _logger.LogError(ex, errorMessage);
                throw new Exception(errorMessage, ex);
            }
        }


        public async Task<SolarPowerPanel> UpdateSolarPowerPlant(int id, SolarPowerPanel updatedPlant)
        {
            var existingPlant = _context.SolarPowerPlants.FirstOrDefault(p => p.SolarId == id);
            if (existingPlant != null)
            {
                existingPlant.Name = updatedPlant.Name;
                existingPlant.InstalledPowerInKW = updatedPlant.InstalledPowerInKW;
                existingPlant.DateOfInstallation = updatedPlant.DateOfInstallation;
                existingPlant.Latitude = updatedPlant.Latitude;
                existingPlant.Longitude = updatedPlant.Longitude;
            }
            return existingPlant;
        }

        //public async Task<IActionResult> DeleteSolarPlant(int id)
        //{
        //    try
        //    {
        //        var solarPowerPlant = await _context.SolarPowerPlants.FindAsync(id);
        //        if (solarPowerPlant == null)
        //        {
        //            throw new Exception("Solar power plant with ID {id} not found.");
        //        }
        //        _context.SolarPowerPlants.Remove(solarPowerPlant);
        //        await _context.SaveChangesAsync();

        //        return OkResult();

        //    }
        //    catch (Exception ex)
        //    {
        //        var errorMessage = "An error occurred while deleting solar power plant with ID: {id}";
        //        _logger.LogError(ex, errorMessage);
        //        throw new Exception(errorMessage, ex);
        //    }
        //}

        public async Task<List<Timeseries>> CalculateActualProduction(int solarPanelId, string granularity, DateTime startDate, DateTime endDate)
        {
            var timeseries = new List<Timeseries>();

            if (granularity.ToLower() == "15min")
            {
                var data = await _context.ProductionDatas
                   .Where(pd => pd.SolarId == solarPanelId && pd.ActualProductionPowerOutputKW > 0)
                   .Where(pd => pd.DateOfProduction >= startDate && pd.DateOfProduction <= endDate)
                   .ToListAsync();

                foreach (var period in GetPeriods(startDate, endDate, TimeSpan.FromMinutes(15)))
                {
                    var avgProduction = data.Where(d => d.DateOfProduction >= period.Start && d.DateOfProduction < period.End).Average(d => d.ActualProductionPowerOutputKW);
                    timeseries.Add(new Timeseries { StartTime = period.Start, EndTime = period.End, AverageProduction = avgProduction });
                }
            }
            else if (granularity.ToLower() == "1hr")
            {
                var data = await _context.ProductionDatas
                   .Where(pd => pd.SolarId == solarPanelId && pd.ActualProductionPowerOutputKW > 0)
                   .Where(pd => pd.DateOfProduction.Hour % 4 == 0) // Ensure we group every 4 hours
                   .Where(pd => pd.DateOfProduction >= startDate && pd.DateOfProduction <= endDate)
                   .ToListAsync();

                foreach (var period in GetPeriods(startDate, endDate, TimeSpan.FromHours(1)))
                {
                    var avgProduction = data.Where(d => d.DateOfProduction >= period.Start && d.DateOfProduction < period.End).Average(d => d.ActualProductionPowerOutputKW);
                    timeseries.Add(new Timeseries { StartTime = period.Start, EndTime = period.End, AverageProduction = avgProduction });
                }
            }

            return timeseries;
        }
        public async Task<List<Timeseries>> CalculateForecastProduction(int solarId, string granularity, DateTime startDate, DateTime endDate)
        {

            var timeseries = new List<Timeseries>();

            if (granularity.ToLower() == "15min")
            {
                var data = await _context.ProductionDatas
                   .Where(pd => pd.SolarId == solarId && pd.ForcastProductionPowerOutputKW > 0)
                   .Where(pd => pd.DateOfProduction >= startDate && pd.DateOfProduction <= endDate)
                   .ToListAsync();

                foreach (var period in GetPeriods(startDate, endDate, TimeSpan.FromMinutes(15)))
                {
                    var avgProduction = data.Where(d => d.DateOfProduction >= period.Start && d.DateOfProduction < period.End).Average(d => d.ForcastProductionPowerOutputKW);
                    timeseries.Add(new Timeseries { StartTime = period.Start, EndTime = period.End, AverageProduction = avgProduction });
                }
            }
            else if (granularity.ToLower() == "1hr")
            {
                var data = await _context.ProductionDatas
                   .Where(pd => pd.SolarId == solarId && pd.ActualProductionPowerOutputKW > 0)
                   .Where(pd => pd.DateOfProduction.Hour % 4 == 0) // Ensure we group every 4 hours
                   .Where(pd => pd.DateOfProduction >= startDate && pd.DateOfProduction <= endDate)
                   .ToListAsync();

                foreach (var period in GetPeriods(startDate, endDate, TimeSpan.FromHours(1)))
                {
                    var avgProduction = data.Where(d => d.DateOfProduction >= period.Start && d.DateOfProduction < period.End).Average(d => d.ForcastProductionPowerOutputKW);
                    timeseries.Add(new Timeseries { StartTime = period.Start, EndTime = period.End, AverageProduction = avgProduction });
                }
            }

            return timeseries;
        }

        private static IEnumerable<Period> GetPeriods(DateTime startDate, DateTime endDate, TimeSpan interval)
        {
            var periods = new List<Period>();
            var current = startDate;

            while (current <= endDate)
            {
                periods.Add(new Period { Start = current, End = current.Add(interval) });
                current = current.Add(interval);
            }

            return periods;
        }
    }
}
