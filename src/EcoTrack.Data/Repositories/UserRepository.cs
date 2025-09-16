// We need to import the contracts, the entities, the DbContext, and EF Core's tools.
using EcoTrack.Core.Entities;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data.Repositories
{
    // 'public class UserRepository : IUserRepository' means this class promises
    // to provide an implementation for every method defined in the IUserRepository interface.
    public class UserRepository : IUserRepository
    {
        // This is a private, read-only field to hold our database connection context.
        // It's the "portal" to the database.
        private readonly EcoTrackDbContext _context;

        // This is the constructor. It uses DEPENDENCY INJECTION.
        // Instead of creating its own DbContext, it asks for one to be provided.
        // The application's service container (in Program.cs) is responsible for giving it one.
        public UserRepository(EcoTrackDbContext context)
        {
            _context = context;
        }

        // The actual implementation for GetUserByIdAsync.
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            // 'await': Pauses the method here without freezing the app, waiting for the database.
            // '_context.Users': Accesses the Users table (the DbSet<User>).
            // '.FindAsync(userId)': An efficient EF Core method to find one item by its primary key.
            return await _context.Users.FindAsync(userId);
        }

        // The implementation for GetUserByEmailAsync.
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            // '.FirstOrDefaultAsync()': Searches the Users table for the first entry
            // that matches the condition (u.Email == email). Returns null if none is found.
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        // The implementation for AddUserAsync.
        public async Task<User> AddUserAsync(User user)
        {
            // '.AddAsync()': Tells EF Core to track this new user object.
            // It will be marked for insertion into the database.
            await _context.Users.AddAsync(user);

            // NOTE: We REMOVED SaveChangesAsync() here because the Unit of Work is now
            // responsible for saving all changes at the end of a transaction.
            
            return user;
        }
    }
}