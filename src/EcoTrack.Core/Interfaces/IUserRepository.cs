// This line imports the 'User' class definition, so the interface knows what a 'User' is.
using EcoTrack.Core.Entities;

namespace EcoTrack.Core.Interfaces
{
    // 'public interface' declares a contract that other classes can implement.
    public interface IUserRepository
    {
        // Declares a method named 'GetUserByIdAsync'.
        // Task<User?>: This means the method is asynchronous (doesn't block the app) and will
        // eventually return either a 'User' object or 'null' if no user is found.
        // (int userId): This is the input parameter the method requires.
        Task<User?> GetUserByIdAsync(int userId);

        // Declares a method to find a user by their email address.
        Task<User?> GetUserByEmailAsync(string email);
        
        // Declares a method to add a new user to the database.
        // It takes a 'User' object as input and returns the saved 'User' object
        // (which will now have a 'UserId' assigned by the database).
        Task<User> AddUserAsync(User user);
    }
}