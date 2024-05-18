using Bogus;
using Microsoft.EntityFrameworkCore;
using SolarPlant.DataLayer.Entity;

namespace SolarPlant.DataLayer
{
    public static class InitBase
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var id = 1;
            var data = new Faker<SolarPowerPanel>()
                .RuleFor(m => m.SolarId, f => id++)
                .RuleFor(m => m.Name, f => f.Company.CompanyName())
                .RuleFor(m => m.DateOfInstallation, f => f.Date.Recent(10)) // Last 4 years
                .RuleFor(m => m.InstalledPowerInKW, f => f.Random.Number(1000, 5000))
                .RuleFor(m => m.Latitude, f => f.Address.Latitude())
                .RuleFor(m => m.Longitude, f => f.Address.Longitude());

            // Generate 100 items
            var solarPowerPlants = data.Generate(100);

            modelBuilder.Entity<SolarPowerPanel>().HasData(solarPowerPlants);

            var date = DateTime.Now - TimeSpan.FromMinutes(-15); //

            var ids = 1;
            var solarid = 1;
            var production = new Faker<ProductionData>()
                .RuleFor(m => m.ProductionId, f => ids++)
                .RuleFor(m => m.SolarId, f => solarid++)
                .RuleFor(m => m.DateOfProduction, f => date)
                .RuleFor(m => m.ActualProductionPowerOutputKW, f => f.Random.Double(0, 5000))
                .RuleFor(m => m.ForcastProductionPowerOutputKW, f => f.Random.Double(0, 5000))
                .RuleFor(m => m.Weather, f => f.PickRandom("sunny", "cloudy", "rainy", "windy"));

            var prod = production.Generate(100);

            modelBuilder.Entity<ProductionData>().HasData(prod);

        }
    }
}
