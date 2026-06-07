namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Order;

    public interface IOrderService
    {
        Task<List<OrderHistoryViewModel>> GetCurrentUserOrderHistoryAsync();

        Task<CreateOrderViewModel> GetDetailsForCreateOrderAsync();

        Task CreateOrderAsync(string? addressName, string? town, string? zipCode);

        Task<OrderDetailViewModel> GetOrderDetailsAsync(Guid orderId);

        Task<List<PendingOrderViewModel>> GetUndeliveredOrdersAsync();

        Task<bool> DeliverOrdersAsync(Guid orderId);
    }
}
