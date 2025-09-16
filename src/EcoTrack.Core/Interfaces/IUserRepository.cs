using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    // Updated to specify User's key is a Guid
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}