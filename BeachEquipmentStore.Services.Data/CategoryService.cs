using BeachEquipmentStore.Data;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace BeachEquipmentStore.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly EquipmentStoreDbContext _data;

        public CategoryService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public async Task<List<CategoryServiceModel>> GetAllCategoriesAsync()
        {
            if (!_data.Categories.Any())
            {
                throw new InvalidOperationException("Няма валидни категории!");
            }

            return await _data.Categories
                .Select(c => new CategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();
        }
    }
}