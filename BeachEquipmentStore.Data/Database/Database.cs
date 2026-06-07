namespace BeachEquipmentStore.Data.Repositories
{
    using BeachEquipmentStore.Data.Database.DbContextTransactionProxy;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class Database<T>(DbContext context) : IDatabase<T> where T : class
    {
        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T?> FindAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<T?> FindAsNoTrackingAsync(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity is not null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<T?> FindAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
        }

        public IQueryable<T> AsQueryable()
        {
            return context.Set<T>().AsQueryable();
        }

        public IDbContextTransactionProxy GetTransactionProxy()
        {
            var transaction = context.Database.BeginTransaction();
            return new DbContextTransactionProxy(transaction);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
