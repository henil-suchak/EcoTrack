using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    public interface IApplianceActivityRepository : IRepository<ApplianceActivity>
    {
        Task<IEnumerable<ApplianceActivity>> GetApplianceActivitiesByUserAsync(Guid userId);
    }
}