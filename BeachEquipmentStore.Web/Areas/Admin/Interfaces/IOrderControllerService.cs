using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Admin.Interfaces
{
    public interface IOrderControllerService
    {
        Task<GetUndeliveredOrdersResponse> GetUndeliveredOrdersAsync();

        Task<BaseResponse> DeliverOrdersAsync(Guid orderId);
    }
}
