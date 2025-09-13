namespace EcoTrack.Core.Entities
{
    public class LeaderboardEntry
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }

        public int Rank { get; set; }
        public string Period { get; set; } = string.Empty; // Weekly, Monthly
        public double CarbonEmission { get; set; } // total kg CO₂
        public Guid? CommunityId { get; set; } // optional group leaderboard

        // Navigation property
        public User? User { get; set; }
    }
}
