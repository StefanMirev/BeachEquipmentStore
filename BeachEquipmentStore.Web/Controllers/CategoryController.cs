namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

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

            return View(allCategories);
        }
    }
}