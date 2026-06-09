namespace BeachEquipmentStore.Data.Interfaces
{
    using System.Linq.Expressions;

    public interface IDatabase
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> All<TEntity>() where TEntity : class;
        IQueryable<TEntity> SearchFor<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity? Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity? SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity?> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity? First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity? FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity?> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity?> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity? FindById<TEntity>(Guid id) where TEntity : class;
        Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : class;
        Task<TEntity?> FindByIdAsNoTrackingAsync<TEntity>(Guid id) where TEntity : class;
        Task<TEntity?> FindAsNoTrackingAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity GetNonTrackableEntity<TEntity>(TEntity entity) where TEntity : class;
        Task LoadNavigationProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> property) where TEntity : class where TProperty : class;
        Task LoadNavigationProperties<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        IDbContextTransactionProxy GetTransactionObject();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
