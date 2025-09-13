namespace EcoTrack.Core.Entities
{
    public class Suggestion
    {
        public Guid SuggestionId { get; set; }
        public Guid UserId { get; set; } // FK to User

        public string Description { get; set; } = string.Empty;
        public double SavingAmount { get; set; } // estimated kg CO₂ saved
        public string Category { get; set; } = string.Empty; // Travel, Food, Energy
        public DateTime DateTimeIssued { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
        public bool IsAccepted { get; set; } = false;

        // Navigation property
        public User? User { get; set; }
    }
}
