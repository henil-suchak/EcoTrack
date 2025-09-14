namespace EcoTrack.Core.Entities
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal SavingAmount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime DateTimeIssued { get; set; }
        public bool IsRead { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        // Navigation Property - ADD THIS LINE
        public User? User { get; set; }
    }
}