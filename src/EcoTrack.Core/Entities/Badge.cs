namespace EcoTrack.Core.Entities
{
    public class Badge
    {
        // CORRECTED: Changed from Guid to int for consistency
        public int BadgeId { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CriteriaMet { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public DateTime DateEarned { get; set; }

        // CORRECTED: Changed from Guid to int to match the User's primary key
        public int UserId { get; set; }

        // This navigation property is correct!
        public User? User { get; set; }
    }
}