using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces
{
    public interface ICategoryControllerService
    {
        Task<GetCategoriesResponse> GetAllCategoriesAsync();
    }
}
