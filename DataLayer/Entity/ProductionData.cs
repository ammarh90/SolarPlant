using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarPlant.DataLayer.Entity
{
    public class ProductionData
    {
        [Key]
        public int ProductionId { get; set; }
        public DateTime DateOfProduction { get; set; }
        public double ActualProductionPowerOutputKW { get; set; }
        public double ForcastProductionPowerOutputKW { get; set; }
        public string Weather { get; set; }

        [ForeignKey("SolarId")]
        public int SolarId { get; set; }
        public SolarPowerPanel SolarPowerPlant { get; set; }
 
    }
}
