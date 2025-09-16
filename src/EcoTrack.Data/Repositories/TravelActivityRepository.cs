using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    public class TravelActivityRepository : ITravelActivityRepository
    {
        private readonly EcoTrackDbContext _context;

        public TravelActivityRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        public async Task<TravelActivity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TravelActivity>().FindAsync(id);
        }

        public async Task<IEnumerable<TravelActivity>> GetTravelActivitiesByUserAsync(Guid userId)
        {
            return await _context.Set<TravelActivity>()
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<TravelActivity>> GetAllAsync()
        {
            return await _context.Set<TravelActivity>().ToListAsync();
        }

        public async Task AddAsync(TravelActivity entity)
        {
            await _context.Set<TravelActivity>().AddAsync(entity);
        }

        public void Delete(TravelActivity entity)
        {
            _context.Set<TravelActivity>().Remove(entity);
        }
    }
}