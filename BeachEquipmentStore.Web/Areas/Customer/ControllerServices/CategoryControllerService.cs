using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces;

namespace BeachEquipmentStore.Web.Areas.Customer.ControllerServices
{
    public class CategoryControllerService : ICategoryControllerService
    {
        private readonly ICategoryService _categoryService;

        public CategoryControllerService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetCategoriesResponse> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                return new GetCategoriesResponse
                {
                    IsSuccess = true,
                    Categories = categories
                };
            }
            catch (Exception ex)
            {
                return new GetCategoriesResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }
    }
}
