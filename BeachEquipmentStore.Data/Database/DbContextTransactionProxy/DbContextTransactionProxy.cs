namespace BeachEquipmentStore.Data.Database.DbContextTransactionProxy
{
    using Microsoft.EntityFrameworkCore.Storage;

    public class DbContextTransactionProxy : IDbContextTransactionProxy
    {
        private readonly IDbContextTransaction _transaction;
        private bool _disposed = false;

        public DbContextTransactionProxy(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
            Dispose();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _transaction.Dispose();
            }
        }
    }
}
