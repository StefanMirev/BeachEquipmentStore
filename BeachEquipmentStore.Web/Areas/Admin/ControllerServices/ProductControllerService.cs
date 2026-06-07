using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Areas.Admin.Interfaces;
using BeachEquipmentStore.Web.Responses;
using static BeachEquipmentStore.Common.Constants.Messages;

namespace BeachEquipmentStore.Web.Areas.Admin.ControllerServices
{
    public class ProductControllerService : IProductControllerService
    {
        private readonly IProductService _productService;

        public ProductControllerService(IProductService productService)
        {
            _productService = productService;
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
