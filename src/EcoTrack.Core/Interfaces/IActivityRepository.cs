using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    // This interface now includes all methods from IRepository<Activity>
    // plus any new methods we define here.
    public interface IActivityRepository : IRepository<Activity>
    {
        // Example of a custom method specific to activities
        Task<IEnumerable<Activity>> GetActivitiesByUserAsync(Guid userId);
    }
}