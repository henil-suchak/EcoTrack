namespace EcoTrack.Core.Entities
{
    public class Family
    {
        public Guid FamilyId { get; set; }
        public string FamilyName { get; set; } = string.Empty;

        // Navigation: list of users in this family
        public ICollection<User> Members { get; set; } = new List<User>();

        // Optional: shared resource tracking
        public string? SharedConsumption { get; set; } // e.g., JSON with electricity/waste allocation
    }
}
