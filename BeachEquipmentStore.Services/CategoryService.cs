namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;
    using static Core.Common.Constants.Messages;

    public class CategoryService : ICategoryService
    {
        private readonly AllBusinessLogics _allBls;

        public CategoryService(AllBusinessLogics allBls)
        {
            _allBls = allBls;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await _allBls.CategoriesBL.All()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

            if (!categories.Any())
            {
                throw new InvalidOperationException(CategoriesNotFound);
            }

            return categories;
        }
    }
}
