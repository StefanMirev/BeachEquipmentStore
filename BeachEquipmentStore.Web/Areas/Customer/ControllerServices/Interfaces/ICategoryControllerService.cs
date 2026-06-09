using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces
{
    public interface ICategoryControllerService
    {
        Task<GetCategoriesResponse> GetAllCategoriesAsync();
    }
}
