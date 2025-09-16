using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    // Extends the generic repository for the TravelActivity entity
    public interface ITravelActivityRepository : IRepository<TravelActivity>
    {
        // Custom method to fetch travel activities for a specific user
        Task<IEnumerable<TravelActivity>> GetTravelActivitiesByUserAsync(Guid userId);
    }
}