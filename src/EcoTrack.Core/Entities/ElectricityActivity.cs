namespace EcoTrack.Core.Entities
{
    public class ElectricityActivity : Activity
    {
        public decimal Consumption { get; set; } // in kWh
        public string SourceType { get; set; } = string.Empty; // "smart meter", "bill upload"
        
        public int EmissionFactorId { get; set; }
        public EmissionFactor? EmissionFactor { get; set; }
    }
}