using BeachEquipmentStore.ViewModels.Category;

namespace BeachEquipmentStore.Services.Interfaces
{

    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
