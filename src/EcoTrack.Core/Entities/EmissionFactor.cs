namespace EcoTrack.Core.Entities
{
    public class EmissionFactor
    {
        public Guid FactorId { get; set; }
        public string ActivityType { get; set; } = string.Empty; // Travel, Food, Electricity, etc.
        public string SubType { get; set; } = string.Empty; // e.g., Car-Petrol, Beef, Train
        public string? Region { get; set; } // optional region-specific factor
        public double Value { get; set; } // kg CO₂ per unit
        public string SourceReference { get; set; } = string.Empty; // e.g., IPCC, IEA
    }
}
