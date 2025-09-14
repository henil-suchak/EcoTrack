namespace EcoTrack.Core.Entities
{
    public class EmissionFactor
    {
        // RENAMED: from FactorId to EmissionFactorId to follow EF Core's primary key convention
        public int EmissionFactorId { get; set; }

        public string ActivityType { get; set; } = string.Empty;
        public string SubType { get; set; } = string.Empty;
        public string? Region { get; set; }
        public decimal Value { get; set; } // kg CO₂/unit
        public string SourceReference { get; set; } = string.Empty;
    }
}