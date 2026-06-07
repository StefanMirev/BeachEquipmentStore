namespace BeachEquipmentStore.Data.Database.DbContextTransactionProxy
{
    public interface IDbContextTransactionProxy : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
