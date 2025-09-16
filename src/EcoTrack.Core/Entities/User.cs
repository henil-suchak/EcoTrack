namespace EcoTrack.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? LifestylePreferences { get; set; }
        public string? ConnectedAccounts { get; set; }

        // Foreign Key for Family
        public int? FamilyId { get; set; }
        public Family? Family { get; set; }

        // Navigation properties
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
        public ICollection<Badge> Badges { get; set; } = new List<Badge>();
    }
}