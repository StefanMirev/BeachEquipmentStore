using BeachEquipmentStore.Services.Data.Models.Order;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderServiceModel> GetDataRequiredForOrder(string userId);
    }
}