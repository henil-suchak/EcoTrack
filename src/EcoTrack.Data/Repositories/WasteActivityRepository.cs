using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    public class WasteActivityRepository : IWasteActivityRepository
    {
        private readonly EcoTrackDbContext _context;

        public WasteActivityRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        public async Task<WasteActivity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<WasteActivity>().FindAsync(id);
        }

        public async Task<IEnumerable<WasteActivity>> GetWasteActivitiesByUserAsync(Guid userId)
        {
            return await _context.Set<WasteActivity>()
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<WasteActivity>> GetAllAsync()
        {
            return await _context.Set<WasteActivity>().ToListAsync();
        }

        public async Task AddAsync(WasteActivity entity)
        {
            await _context.Set<WasteActivity>().AddAsync(entity);
        }

        public void Delete(WasteActivity entity)
        {
            _context.Set<WasteActivity>().Remove(entity);
        }
    }
}