using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    public interface IWasteActivityRepository : IRepository<WasteActivity>
    {
        Task<IEnumerable<WasteActivity>> GetWasteActivitiesByUserAsync(Guid userId);
    }
}