using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarPlant.DataLayer.Entity
{
    public class SolarPowerPanel
    {
        [Key]
        public int SolarId { get; set; }
        public string Name { get; set; }
        public double InstalledPowerInKW { get; set; }
        public DateTime DateOfInstallation { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public ICollection<ProductionData> ProductionDatas { get; set; }
    }
}
