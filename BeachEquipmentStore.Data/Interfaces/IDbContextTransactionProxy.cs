namespace BeachEquipmentStore.Data.Interfaces
{
    public interface IDbContextTransactionProxy : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
