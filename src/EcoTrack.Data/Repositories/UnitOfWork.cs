using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Data;

namespace EcoTrack.Data.Repositories
{
    // This class implements the IUnitOfWork contract.
    public class UnitOfWork : IUnitOfWork
    {
        // It holds a single, private instance of the DbContext.
        private readonly EcoTrackDbContext _context;

        // This is the public property that provides access to the UserRepository.
        // 'private set;' means it can only be assigned a value from within this class (in the constructor).
        public IUserRepository Users { get; private set; }
        public IActivityRepository Activities { get; private set; } // ADD THIS LINE
        public ITravelActivityRepository TravelActivities { get; private set; }
        public IFoodActivityRepository FoodActivities { get; private set; }
        public IElectricityActivityRepository ElectricityActivities { get; private set; }
        public IApplianceActivityRepository ApplianceActivities { get; private set; }
        public IWasteActivityRepository WasteActivities { get; private set; }
        // The constructor receives the DbContext via dependency injection.
        public UnitOfWork(EcoTrackDbContext context)
        {
            _context = context;

            // This is a key step: The UnitOfWork CREATES the repository instances,
            // passing its own DbContext to them. This guarantees all repositories
            // share the exact same database session and transaction.
            Users = new UserRepository(_context);
            Activities = new ActivityRepository(_context);
            TravelActivities = new TravelActivityRepository(_context);
            FoodActivities = new FoodActivityRepository(_context);
            ElectricityActivities = new ElectricityActivityRepository(_context);
            ApplianceActivities = new ApplianceActivityRepository(_context);
            WasteActivities = new WasteActivityRepository(_context);
        }

        // This is the implementation of the save method.
        // It simply calls SaveChangesAsync() on the shared DbContext. This one call
        // will save all changes made through all repositories that were used.
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // This is the implementation of the Dispose method.
        // It cleans up the DbContext, which releases the database connection.
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}