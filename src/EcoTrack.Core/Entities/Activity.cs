using EcoTrack.Core.Enums;

namespace EcoTrack.Core.Entities
{
    public abstract class Activity
    {
        public Guid ActivityId { get; set; }
        public DateTime DateTime { get; set; }
        public ActivityType ActivityType { get; set; }
        public decimal CarbonEmission { get; set; } // Calculated value in kg CO₂

        // Foreign Key to User
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}