namespace EcoTrack.Core.Entities
{
    public class FoodActivity : Activity
    {
        public string FoodType { get; set; } = string.Empty; // e.g., "Beef", "Rice"
        public decimal Quantity { get; set; } // in kg or servings
        public string Source { get; set; } = string.Empty; // "home-cooked", "restaurant"
        
        public int EmissionFactorId { get; set; }
        public EmissionFactor? EmissionFactor { get; set; }
    }
}