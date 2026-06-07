using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class ProductControllerService : IProductControllerService
    {
        private readonly IProductService _productService;

        public ProductControllerService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetProductResponse> GetProductByIdAsync(Guid productId)
        {
            try
            {
                return new GetProductResponse
                {
                    IsSuccess = true,
                    Product = await this._productService.GetProductByIdAsync(productId)
                };
            }
            catch (Exception ex)
            {
                return new GetProductResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<GetFilteredProductsResponse> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId)
        {
            try
            {
                return new GetFilteredProductsResponse
                {
                    IsSuccess = true,
                    Products = await this._productService.GetFilteredProductsAsync(keyword, categoryId, manufacturerId)
                };
            }
            catch (Exception ex)
            {
                return new GetFilteredProductsResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

    }
}
