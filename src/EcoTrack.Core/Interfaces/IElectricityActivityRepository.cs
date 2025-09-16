using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    public interface IElectricityActivityRepository : IRepository<ElectricityActivity>
    {
        Task<IEnumerable<ElectricityActivity>> GetElectricityActivitiesByUserAsync(Guid userId);
    }
}