namespace EcoTrack.Core.Interfaces
{
    // Now uses Guid as the default key type
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : class
    {
    }

    // This is our flexible base interface
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}