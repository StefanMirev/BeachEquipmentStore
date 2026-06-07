namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Category;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class CategoryService : ICategoryService
    {
        private readonly AllBusinessLogics _allBls;

        public CategoryService(AllBusinessLogics allBls)
        {
            _allBls = allBls;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await _allBls.CategoriesBL.GetAllAsync();

            if (!categories.Any())
            {
                throw new InvalidOperationException(CategoriesNotFound);
            }

            return categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                })
                .ToList();
        }
    }
}
