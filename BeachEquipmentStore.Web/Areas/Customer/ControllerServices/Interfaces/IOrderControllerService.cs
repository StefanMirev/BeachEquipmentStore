using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces
{
    public interface IOrderControllerService
    {
        Task<GetDetailsForCreateOrderResponse> GetDetailsForCreateOrderAsync();

        Task<BaseResponse> CreateOrderAsync(string? addressName, string? town, string? zipCode);

        Task<GetOrderDetailsResponse> GetOrderDetailsAsync(Guid orderId);

    }
}
