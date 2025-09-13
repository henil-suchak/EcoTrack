namespace EcoTrack.Core.Entities
{
    public class Badge
    {
        public Guid BadgeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CriteriaMet { get; set; } = string.Empty; // e.g., "Meat-Free Week"
        public string IconUrl { get; set; } = string.Empty;

        public Guid UserId { get; set; } // assigned to user
        public DateTime DateEarned { get; set; } = DateTime.UtcNow;

        // Navigation property
        public User? User { get; set; }
    }
}
