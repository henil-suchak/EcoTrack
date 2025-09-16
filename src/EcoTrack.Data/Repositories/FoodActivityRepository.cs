using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    public class FoodActivityRepository : IFoodActivityRepository
    {
        private readonly EcoTrackDbContext _context;

        public FoodActivityRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        public async Task<FoodActivity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<FoodActivity>().FindAsync(id);
        }

        public async Task<IEnumerable<FoodActivity>> GetFoodActivitiesByUserAsync(Guid userId)
        {
            return await _context.Set<FoodActivity>()
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<FoodActivity>> GetAllAsync()
        {
            return await _context.Set<FoodActivity>().ToListAsync();
        }

        public async Task AddAsync(FoodActivity entity)
        {
            await _context.Set<FoodActivity>().AddAsync(entity);
        }

        public void Delete(FoodActivity entity)
        {
            _context.Set<FoodActivity>().Remove(entity);
        }
    }
}