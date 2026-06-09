namespace BeachEquipmentStore.Data
{
    using BeachEquipmentStore.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class Database<T>(DbContext database) : IDatabase where T : class
    {
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            database.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await database.Set<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            return database.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> SearchFor<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return database.Set<TEntity>().Where(predicate);
        }

        public TEntity? Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return database.Set<TEntity>().Single(predicate);
        }

        public async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await database.Set<TEntity>().SingleAsync(predicate);
        }

        public TEntity? SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return database.Set<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<TEntity?> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await database.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public TEntity? First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return database.Set<TEntity>().First(predicate);
        }

        public async Task<TEntity?> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await database.Set<TEntity>().FirstAsync(predicate);
        }

        public TEntity? FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return database.Set<TEntity>().FirstOrDefault(predicate);
        }

        public async Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await database.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity? FindById<TEntity>(Guid id) where TEntity : class
        {
            return database.Set<TEntity>().Find(id);
        }

        public async Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : class
        {
            return await database.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await database.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> FindByIdAsNoTrackingAsync<TEntity>(Guid id) where TEntity : class
        {
            var entity = await database.Set<TEntity>().FindAsync(id);
            if (entity is not null)
                database.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<TEntity?> FindAsNoTrackingAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await database.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public TEntity GetNonTrackableEntity<TEntity>(TEntity entity) where TEntity : class
        {
            return (TEntity)database.Entry(entity).CurrentValues.ToObject();
        }

        public async Task LoadNavigationProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> property)
            where TEntity : class
            where TProperty : class
        {
            await database.Entry(entity).Reference(property).LoadAsync();
        }

        public async Task LoadNavigationProperties<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = database.Entry(entity);
            foreach (var navigation in entry.Navigations)
            {
                if (!navigation.IsLoaded)
                {
                    await navigation.LoadAsync();
                }
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            database.Set<TEntity>().Update(entity);
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            database.Set<TEntity>().UpdateRange(entities);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            database.Set<TEntity>().Remove(entity);
        }

        public IDbContextTransactionProxy GetTransactionObject()
        {
            var transaction = database.Database.BeginTransaction();
            return new DbContextTransactionProxy(transaction);
        }

        public int SaveChanges()
        {
            return database.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await database.SaveChangesAsync();
        }
    }
}
