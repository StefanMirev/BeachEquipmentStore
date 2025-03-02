namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Profile;

    public interface IOrderService
    {
        Task<List<OrderHistoryViewModel>> GetOrderHistory(Guid userId);

        Task<CreateOrderViewModel> GetDataRequiredForOrder(Guid userId);

        Task GenerateOrder(Guid userId, bool hasAddress, string? addressName, string? town, string zipCode, decimal totalSum);

        Task<OrderDetailViewModel> GetOrderDetails(string orderId);

        Task<List<CompleteOrderViewModel>> GetUndeliveredOrders();

        Task DeliverOrders(Guid orderId);
    }
}