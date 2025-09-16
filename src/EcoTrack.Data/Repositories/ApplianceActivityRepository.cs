using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    public class ApplianceActivityRepository : IApplianceActivityRepository
    {
        private readonly EcoTrackDbContext _context;

        public ApplianceActivityRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        public async Task<ApplianceActivity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<ApplianceActivity>().FindAsync(id);
        }

        public async Task<IEnumerable<ApplianceActivity>> GetApplianceActivitiesByUserAsync(Guid userId)
        {
            return await _context.Set<ApplianceActivity>()
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<ApplianceActivity>> GetAllAsync()
        {
            return await _context.Set<ApplianceActivity>().ToListAsync();
        }

        public async Task AddAsync(ApplianceActivity entity)
        {
            await _context.Set<ApplianceActivity>().AddAsync(entity);
        }

        public void Delete(ApplianceActivity entity)
        {
            _context.Set<ApplianceActivity>().Remove(entity);
        }
    }
}