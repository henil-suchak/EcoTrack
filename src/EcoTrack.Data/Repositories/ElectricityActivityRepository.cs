using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    public class ElectricityActivityRepository : IElectricityActivityRepository
    {
        private readonly EcoTrackDbContext _context;

        public ElectricityActivityRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        public async Task<ElectricityActivity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<ElectricityActivity>().FindAsync(id);
        }

        public async Task<IEnumerable<ElectricityActivity>> GetElectricityActivitiesByUserAsync(Guid userId)
        {
            return await _context.Set<ElectricityActivity>()
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<ElectricityActivity>> GetAllAsync()
        {
            return await _context.Set<ElectricityActivity>().ToListAsync();
        }

        public async Task AddAsync(ElectricityActivity entity)
        {
            await _context.Set<ElectricityActivity>().AddAsync(entity);
        }

        public void Delete(ElectricityActivity entity)
        {
            _context.Set<ElectricityActivity>().Remove(entity);
        }
    }
}