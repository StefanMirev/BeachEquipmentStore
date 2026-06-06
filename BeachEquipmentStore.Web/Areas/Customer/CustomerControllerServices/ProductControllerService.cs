using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
using static BeachEquipmentStore.Common.Constants.Messages;

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

        public async Task<GetProductsResponse> GetAllProductsAsync()
        {
            try
            {
                var allProducts = await _productService.GetAllProductsAsync();

                return new GetProductsResponse
                {
                    IsSuccess = true,
                    Products = allProducts
                        .OrderBy(p => p.Quantity)
                        .ToList()
                };
            }
            catch (Exception ex)
            {
                return new GetProductsResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> RestockProductAsync(Guid productId, int quantity)
        {
            try
            {
                if (quantity < 1)
                {
                    throw new ArgumentException(ProductQuantityTooLow);
                }

                await _productService.RestockProductAsync(productId, quantity);

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = ProductRestockSuccess
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }
    }
}
