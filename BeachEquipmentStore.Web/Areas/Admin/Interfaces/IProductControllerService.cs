using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Admin.Interfaces
{
    public interface IProductControllerService
    {
        Task<GetProductsResponse> GetAllProductsAsync();

        Task<BaseResponse> RestockProductAsync(Guid productId, int quantity);
    }
}
