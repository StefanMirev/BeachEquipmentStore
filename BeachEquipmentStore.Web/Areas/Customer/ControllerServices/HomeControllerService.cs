using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly IProductService _productService;

        public HomeControllerService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetProductsResponse> ResolveHomePageAsync()
        {
            try
            {
                return new GetProductsResponse
                {
                    IsSuccess = true,
                    Products = await _productService.GetRandomProductsInStockAsync()
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
    }
}
