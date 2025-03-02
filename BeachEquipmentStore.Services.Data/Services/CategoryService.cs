namespace BeachEquipmentStore.Services.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly EquipmentStoreDbContext _data;

        public CategoryService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            if (!_data.Categories.Any())
            {
                throw new InvalidOperationException("Няма валидни категории!");
            }

            return await _data.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();
        }
    }
}