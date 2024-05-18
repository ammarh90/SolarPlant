namespace SolarPlant.Helper
{
    public class Period
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class Timeseries
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double AverageProduction { get; set; }
    }
}
