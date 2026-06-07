namespace BeachEquipmentStore.Data.Repositories
{
    using BeachEquipmentStore.Data.Database.DbContextTransactionProxy;
    using System.Linq.Expressions;

    public interface IDatabase<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable();
        Task<T?> FindAsync(Guid id);
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindAsNoTrackingAsync(Guid id);
        Task<T?> FindAsNoTrackingAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        IDbContextTransactionProxy GetTransactionProxy();
        Task<int> SaveChangesAsync();
    }
}
