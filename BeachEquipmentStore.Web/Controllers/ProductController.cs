namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using BeachEquipmentStore.ViewModels.Product;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    public class ProductController : Controller
    {
        private readonly ICategoryService _categories;
        private readonly IProductService _products;
        private readonly IManufacturerService _manufacturers;
        private readonly IMemoryCache _cache;

        public ProductController(IProductService products, ICategoryService categories, IManufacturerService manufacturers, IMemoryCache cache)
        {
            _products = products;
            _categories = categories;
            _manufacturers = manufacturers;
            _cache = cache;

        }

        [Route("Product")]
        public async Task<IActionResult> GetSelectedProduct(Guid productId)
        {
            try
            {
                return View(await this._products.GetProductById(productId));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [Route("All")]
        public async Task<IActionResult> All(string keyword, int categoryId, int manufacturerId)
        {
            try
            {
                return View("All", await _products.GetFilteredProductsAsync(keyword, categoryId, manufacturerId));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
