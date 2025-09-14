

namespace EcoTrack.Core.Entities
{
    public class WasteActivity : Activity
    {
        public string WasteType { get; set; } = string.Empty;
        public decimal Amount { get; set; } // Using decimal for precision is better

        // --- CORRECTIONS ---

        // 1. Foreign Key to the EmissionFactor table
        public int EmissionFactorId { get; set; }

        // 2. Navigation Property to the EmissionFactor entity
        public EmissionFactor? EmissionFactor { get; set; }
    }
}