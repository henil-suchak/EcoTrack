using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly EcoTrackDbContext _context;

        public ActivityRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        // CORRECTED: The userId parameter is now a Guid
        public async Task<IEnumerable<Activity>> GetActivitiesByUserAsync(Guid userId)
        {
            return await _context.Activities
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
        }

        // CORRECTED: The id parameter is now a Guid and the method is fully implemented
        public async Task<Activity?> GetByIdAsync(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task AddAsync(Activity entity)
        {
            await _context.Activities.AddAsync(entity);
        }

        public void Delete(Activity entity)
        {
            _context.Activities.Remove(entity);
        }
    }
}