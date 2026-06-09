using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces
{
    public interface ICartControllerService
    {
        Task<GetCartResponse> GoToCartAsync();

        Task<BaseResponse> AddToCartAsync(Guid productId, int quantity);

        Task<BaseResponse> ClearCartAsync(bool restoreStock);

        Task<BaseResponse> RemoveItemFromCartAsync(Guid productId);
    }
}
