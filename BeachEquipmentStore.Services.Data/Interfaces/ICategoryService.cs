namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Category;

    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
