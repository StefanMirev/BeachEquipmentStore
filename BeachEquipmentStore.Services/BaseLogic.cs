namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Database.DbContextTransactionProxy;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Data.Repositories;
    using System.Linq.Expressions;

    public class BaseLogic<T>(IDatabase<T> database) where T : class
    {
        private readonly IDatabase<T> _database = database;

        public async Task<List<T>> GetAllAsync()
        {
            return await _database.GetAllAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.GetAllAsync(predicate);
        }

        public async Task<T?> FindAsync(Guid id)
        {
            return await _database.FindAsync(id);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.FindAsync(predicate);
        }

        public async Task<T?> FindAsync(T entity)
        {
            var id = (Guid?)typeof(T).GetProperty(nameof(IEntity.Id))?.GetValue(entity);
            return await _database.FindAsync(id!.Value);
        }

        public async Task<T?> FindAsNoTrackingAsync(Guid id)
        {
            return await _database.FindAsNoTrackingAsync(id);
        }

        public async Task<T?> FindAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.FindAsNoTrackingAsync(predicate);
        }

        public async Task<T?> FindAsNoTrackingAsync(T entity)
        {
            var id = (Guid?)typeof(T).GetProperty(nameof(IEntity.Id))?.GetValue(entity);
            return await _database.FindAsNoTrackingAsync(id!.Value);
        }

        public void Add(T entity)
        {
            _database.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _database.AddRange(entities);
        }

        public async Task AddAsync(T entity)
        {
            await _database.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _database.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _database.Remove(entity);
        }

        public void Update(T entity)
        {
            _database.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _database.UpdateRange(entities);
        }

        public IQueryable<T> AsQueryable()
        {
            return _database.AsQueryable();
        }

        public IDbContextTransactionProxy GetTransactionProxy()
        {
            return _database.GetTransactionProxy();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
