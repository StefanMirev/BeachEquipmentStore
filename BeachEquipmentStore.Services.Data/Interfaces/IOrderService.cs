using BeachEquipmentStore.Services.Data.Models.Order;
using BeachEquipmentStore.Web.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderServiceModel> GetDataRequiredForOrder(string userId);

        Task GenerateOrder(string userId, bool hasAddress, string? addressName, string? town, int zipCode, decimal totalSum);

        Task<OrderDetailServiceModel> GetOrderDetails(string orderId);
    }
}