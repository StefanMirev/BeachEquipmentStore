using BeachEquipmentStore.Services.Data.Models.Category;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryServiceModel>> GetAllCategoriesAsync();
    }
}
