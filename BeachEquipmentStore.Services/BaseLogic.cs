namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Interfaces;
    using BeachEquipmentStore.Services.Infrastructure;
    using System.Linq.Expressions;

    public class BaseLogic<T>(IDatabase database) where T : class
    {
        private readonly IDatabase _database = database;

        public void Add(T entity)
        {
            _database.Add(entity);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _database.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _database.AddAsync(entity);
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _database.AddAsync(entity);
        }

        public IQueryable<T> All()
        {
            return _database.All<T>().AsAsyncQueryable();
        }

        public IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            return _database.All<TEntity>().AsAsyncQueryable();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _database.SearchFor<T>(predicate).AsAsyncQueryable();
        }

        public IQueryable<TEntity> SearchFor<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _database.SearchFor<TEntity>(predicate).AsAsyncQueryable();
        }

        public T? Single(Expression<Func<T, bool>> predicate)
        {
            return _database.Single<T>(predicate);
        }

        public TEntity? Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _database.Single<TEntity>(predicate);
        }

        public async Task<T?> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.SingleAsync<T>(predicate);
        }

        public async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _database.SingleAsync<TEntity>(predicate);
        }

        public T? SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _database.SingleOrDefault<T>(predicate);
        }

        public TEntity? SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _database.SingleOrDefault<TEntity>(predicate);
        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.SingleOrDefaultAsync<T>(predicate);
        }

        public async Task<TEntity?> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _database.SingleOrDefaultAsync<TEntity>(predicate);
        }

        public T? First(Expression<Func<T, bool>> predicate)
        {
            return _database.First<T>(predicate);
        }

        public TEntity? First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _database.First<TEntity>(predicate);
        }

        public async Task<T?> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.FirstAsync<T>(predicate);
        }

        public async Task<TEntity?> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _database.FirstAsync<TEntity>(predicate);
        }

        public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _database.FirstOrDefault<T>(predicate);
        }

        public TEntity? FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _database.FirstOrDefault<TEntity>(predicate);
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.FirstOrDefaultAsync<T>(predicate);
        }

        public async Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _database.FirstOrDefaultAsync<TEntity>(predicate);
        }

        public T? FindById(Guid id)
        {
            return _database.FindById<T>(id);
        }

        public TEntity? FindById<TEntity>(Guid id) where TEntity : class
        {
            return _database.FindById<TEntity>(id);
        }

        public async Task<T?> FindAsync(Guid id)
        {
            return await _database.FindByIdAsync<T>(id);
        }

        public async Task<TEntity?> FindAsync<TEntity>(Guid id) where TEntity : class
        {
            return await _database.FindByIdAsync<TEntity>(id);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.FindAsync<T>(predicate);
        }

        public async Task<TEntity?> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _database.FindAsync<TEntity>(predicate);
        }

        public async Task<T?> FindAsNoTrackingAsync(Guid id)
        {
            return await _database.FindByIdAsNoTrackingAsync<T>(id);
        }

        public async Task<TEntity?> FindAsNoTrackingAsync<TEntity>(Guid id) where TEntity : class
        {
            return await _database.FindByIdAsNoTrackingAsync<TEntity>(id);
        }

        public async Task<T?> FindAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await _database.FindAsNoTrackingAsync<T>(predicate);
        }

        public async Task<TEntity?> FindAsNoTrackingAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _database.FindAsNoTrackingAsync<TEntity>(predicate);
        }

        public T GetNonTrackableEntity(T entity)
        {
            return _database.GetNonTrackableEntity(entity);
        }

        public TEntity GetNonTrackableEntity<TEntity>(TEntity entity) where TEntity : class
        {
            return _database.GetNonTrackableEntity(entity);
        }

        public async Task LoadNavigationProperty<TProperty>(T entity, Expression<Func<T, TProperty?>> property)
            where TProperty : class
        {
            await _database.LoadNavigationProperty(entity, property);
        }

        public async Task LoadNavigationProperties(T entity)
        {
            await _database.LoadNavigationProperties(entity);
        }

        public void Update(T entity)
        {
            _database.Update(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _database.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _database.UpdateRange(entities);
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _database.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _database.Delete(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _database.Delete(entity);
        }

        public IDbContextTransactionProxy GetTransactionProxy()
        {
            return _database.GetTransactionObject();
        }

        public int SaveChanges()
        {
            return _database.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
