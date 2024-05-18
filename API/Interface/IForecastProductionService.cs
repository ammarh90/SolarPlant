using Microsoft.AspNetCore.Mvc;
using SolarPlant.DataLayer.Models;

namespace SolarPlant.API.Interface
{
    public interface IForecastProductionService
    {
        Task<Root> GetForecastProduction();
    }
}
