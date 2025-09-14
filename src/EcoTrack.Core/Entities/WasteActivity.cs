namespace EcoTrack.Core.Entities
{
    public class WasteActivity : Activity
    {
        public string WasteType { get; set; } = string.Empty; // e.g., Recyclable, Landfill, Compost
        public double Amount { get; set; } // in kg
        public double EmissionFactor { get; set; } // kg CO₂ per kg of waste

        public double CalculateEmissions() => Amount * EmissionFactor;
    }


}
