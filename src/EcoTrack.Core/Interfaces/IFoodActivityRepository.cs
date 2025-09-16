using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    public interface IFoodActivityRepository : IRepository<FoodActivity>
    {
        Task<IEnumerable<FoodActivity>> GetFoodActivitiesByUserAsync(Guid userId);
    }
}