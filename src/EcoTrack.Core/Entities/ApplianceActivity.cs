namespace EcoTrack.Core.Entities
{
    public class ApplianceActivity : Activity
    {
        public string ApplianceType { get; set; } = string.Empty; // e.g., "Fridge", "AC"
        public decimal UsageTime { get; set; } // in hours
        public decimal PowerRating { get; set; } // in watts
        
        public int EmissionFactorId { get; set; }
        public EmissionFactor? EmissionFactor { get; set; }
    }
}