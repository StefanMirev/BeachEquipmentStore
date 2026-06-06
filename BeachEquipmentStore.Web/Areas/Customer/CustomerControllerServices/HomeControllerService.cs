using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public HomeControllerService(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public async Task<GetProductsResponse> ResolveHomePage()
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
