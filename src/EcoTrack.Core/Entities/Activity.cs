namespace EcoTrack.Core.Entities
{
    public abstract class Activity
    {
        public Guid ActivityId { get; set; }
        public DateTime DateTime { get; set; }
        public Core.Enums.ActivityType ActivityType { get; set; }
        public decimal CarbonEmission { get; set; }

        // Foreign Key to User
        public Guid UserId { get; set; } // CHANGED to Guid
        public User? User { get; set; }
    }
}