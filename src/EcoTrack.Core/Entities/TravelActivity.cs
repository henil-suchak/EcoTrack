namespace EcoTrack.Core.Entities
{
    public class TravelActivity : Activity
    {
        public string Mode { get; set; } = string.Empty; // e.g., "Car", "Bus"
        public decimal Distance { get; set; } // in km
        public string? FuelType { get; set; } // e.g., "Petrol", "Electric"
        public string? LocationStart { get; set; }
        public string? LocationEnd { get; set; }
        
        // Foreign Key to the specific emission factor used
        public int EmissionFactorId { get; set; }
        public EmissionFactor? EmissionFactor { get; set; }
    }
}