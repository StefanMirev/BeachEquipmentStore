using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categories;

        public CategoryController(ICategoryService categories)
        {
            _categories = categories;
        }

        [Route("Categories")]
        public async Task<IActionResult> AllCategories()
        {
            var allCategories = await _categories.GetAllCategoriesAsync();

            List<CategoryViewModel> resultCategories = allCategories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                })
                .ToList();

            return View(resultCategories);
        }
    }
}