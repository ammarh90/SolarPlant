using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarPlant.DataLayer;
using SolarPlant.DataLayer.Entity;
using System.Reflection.Emit;

namespace SolarPlant.DataLayer.Confing
{
    public class SolarConfiguration : IEntityTypeConfiguration<SolarPowerPanel>
    {
        public void Configure(EntityTypeBuilder<SolarPowerPanel> builder)
        {

            // Configure the entity properties and relationships 
            builder.HasKey(u => u.SolarId);
            builder.Property(u => u.DateOfInstallation).IsRequired();
            builder.Property(u => u.DateOfInstallation).IsRequired();
            builder.Property(u => u.InstalledPowerInKW).IsRequired();
            builder.Property(u => u.Latitude).IsRequired();
            builder.Property(u => u.Longitude).IsRequired();
            builder.HasMany(s => s.ProductionDatas)
           .WithOne(p => p.SolarPowerPlant)
           .HasForeignKey(p => p.SolarId)
           .OnDelete(DeleteBehavior.Cascade);
          
        }
    }
}
