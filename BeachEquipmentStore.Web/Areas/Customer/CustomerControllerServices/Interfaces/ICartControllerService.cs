using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces
{
    public interface ICartControllerService
    {
        Task<GetCartResponse> GoToCartAsync();

        Task<BaseResponse> AddToCartAsync(Guid productId, int quantity);

        Task<BaseResponse> RemoveAllItemsFromCartAsync();

        Task<BaseResponse> RemoveItemFromCartAsync(Guid productId);
    }
}
