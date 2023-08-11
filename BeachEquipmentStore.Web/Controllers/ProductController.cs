using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _products;

        public ProductController(IProductService products)
        {
            _products = products;
        }
        public async Task<IActionResult> All()
        {
            List<ProductViewModel> allProducts = new List<ProductViewModel>();
            
            var queryResult = await this._products.GetAllProductsAsync();

            allProducts.AddRange(queryResult.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price
            }));

            return View(allProducts);
        }

        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            var queryProducts = await this._products.GetProductsByCategoryAsync(categoryId);

            var resultProducts = queryProducts
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToList();

            return View(resultProducts);
        }

        public async Task<IActionResult> ProductsByManufacturer(int manufacturerId)
        {
            var queryProducts = await this._products.GetProductsByManufacturerAsync(manufacturerId);

            var resultProducts = queryProducts
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToList();

            return View(resultProducts);
        }
    }
}
