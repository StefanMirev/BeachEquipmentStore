using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces
{
    public interface IProductControllerService
    {
        Task<GetProductResponse> GetProductByIdAsync(Guid productId);

        Task<GetFilteredProductsResponse> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId);

    }
}
