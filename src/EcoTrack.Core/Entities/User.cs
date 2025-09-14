namespace EcoTrack.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        // ... other properties

        // Foreign Key for Family
        public int? FamilyId { get; set; }
        // Navigation property - ADD THIS LINE
        public Family? Family { get; set; }

        // Navigation properties
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
        public ICollection<Badge> Badges { get; set; } = new List<Badge>();
    }
}