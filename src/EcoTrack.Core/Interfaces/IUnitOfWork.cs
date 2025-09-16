namespace EcoTrack.Core.Interfaces
{
    // ': IDisposable' means any class that implements this interface must have a 'Dispose' method,
    // which is used for cleaning up resources like database connections.
    public interface IUnitOfWork : IDisposable
    {
        // A read-only property that provides access to an IUserRepository.
        // The business logic will use this to get to the user-related database methods.
        IUserRepository Users { get; }
        
        // We will add properties for other repositories here later (e.g., IActivityRepository).

        // Declares a single method to save ALL changes made during a business transaction.
        // The 'int' it returns is the number of records that were changed in the database.
        Task<int> CompleteAsync();
    }
}