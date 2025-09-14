using EcoTrack.Core.Entities;
using EcoTrack.Core.Enums; // <-- Add this using statement for your enum
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Data
{
    public class EcoTrackDbContext : DbContext
    {
        public EcoTrackDbContext(DbContextOptions<EcoTrackDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<EmissionFactor> EmissionFactors { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; }
        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- USER TO ACTIVITY RELATIONSHIP ---
            modelBuilder.Entity<User>()
                .HasMany(u => u.Activities)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            // --- ACTIVITY INHERITANCE CONFIGURATION (TPH) ---
            modelBuilder.Entity<Activity>()
                // 1. Define the discriminator column using the ActivityType enum
                .HasDiscriminator(a => a.ActivityType)
                // 2. Map each C# class to its corresponding enum value
                .HasValue<TravelActivity>(ActivityType.Travel)
                .HasValue<FoodActivity>(ActivityType.Food)
                .HasValue<ElectricityActivity>(ActivityType.Electricity)
                .HasValue<ApplianceActivity>(ActivityType.Appliance)
                .HasValue<WasteActivity>(ActivityType.Waste);
            
            // --- ACTIVITY SUBTYPE TO EMISSIONFACTOR RELATIONSHIPS ---

            modelBuilder.Entity<TravelActivity>()
                .HasOne(ta => ta.EmissionFactor)
                .WithMany()
                .HasForeignKey(ta => ta.EmissionFactorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodActivity>()
                .HasOne(fa => fa.EmissionFactor)
                .WithMany()
                .HasForeignKey(fa => fa.EmissionFactorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ElectricityActivity>()
                .HasOne(ea => ea.EmissionFactor)
                .WithMany()
                .HasForeignKey(ea => ea.EmissionFactorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplianceActivity>()
                .HasOne(aa => aa.EmissionFactor)
                .WithMany()
                .HasForeignKey(aa => aa.EmissionFactorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WasteActivity>()
                .HasOne(wa => wa.EmissionFactor)
                .WithMany()
                .HasForeignKey(wa => wa.EmissionFactorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}