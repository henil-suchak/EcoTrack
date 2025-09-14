namespace EcoTrack.Core.Entities
{
    public class LeaderboardEntry
    {
        // RENAMED: from EntryId to LeaderboardEntryId to follow convention
        public int LeaderboardEntryId { get; set; }

        public int Rank { get; set; }
        public string Period { get; set; } = string.Empty; // e.g., "Weekly", "Monthly"
        public decimal CarbonEmission { get; set; }
        public int? CommunityId { get; set; } // Optional for group leaderboards

        // Foreign Key to User
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}