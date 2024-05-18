using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using SolarPlant.DataLayer.Confing;
using SolarPlant.DataLayer.Entity;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace SolarPlant.DataLayer
{
    public class SolarDbContext : IdentityDbContext
    {
        public SolarDbContext(){}
        public SolarDbContext(DbContextOptions<SolarDbContext> options) : base(options)
        {

        }

        public DbSet<ProductionData> ProductionDatas { get; set; }
        public DbSet<SolarPowerPanel> SolarPowerPlants { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Apply database configuration
            modelBuilder.ApplyConfiguration(new SolarConfiguration());

            // Apply seed data
            InitBase.SeedData(modelBuilder);
        }
    }
}
