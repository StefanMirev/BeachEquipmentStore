using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Category;
using BeachEquipmentStore.Web.ViewModels.Manufacturer;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BeachEquipmentStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService _categories;
        private readonly IProductService _products;
        private readonly IManufacturerService _manufacturers;

        public ProductController(IProductService products, ICategoryService categories, IManufacturerService manufacturers)
        {
            _products = products;
            _categories = categories;
            _manufacturers = manufacturers;

        }
        public async Task<IActionResult> All()
        {
            var categories = await _categories.GetAllCategoriesAsync();
            var manufacturers = await _manufacturers.GetAllManufacturersAsync();
            var queryResult = await this._products.GetAllProductsAsync();

            
            FilterProductsViewModel allProducts = new FilterProductsViewModel()
            {
                Products = queryResult.Select(p => new ProductViewModel
                {

                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                }).ToList(),
                Categories = categories.Select(p => new CategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
                Manufacturers = manufacturers.Select(p => new ManufacturerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList()
            };

            ExtendendedFiltrationViewModel model = new ExtendendedFiltrationViewModel()
            {
                FilteredProducts = allProducts
            };

            return View(model);
        }

        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            var queryProducts = await this._products.GetProductsByCategoryAsync(categoryId);
            var categories = await _categories.GetAllCategoriesAsync();
            var manufacturers = await _manufacturers.GetAllManufacturersAsync();
            var resultProducts = new FilterProductsViewModel()
            {
                Products = queryProducts.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                }).ToList(),
                Categories = categories.Select(p => new CategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
                Manufacturers = manufacturers.Select(p => new ManufacturerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList()
            };

            ExtendendedFiltrationViewModel model = new ExtendendedFiltrationViewModel()
            {
                FilteredProducts = resultProducts
            };

            return View(model);
        }

        public async Task<IActionResult> ProductsByManufacturer(int manufacturerId)
        {
            var queryProducts = await this._products.GetProductsByManufacturerAsync(manufacturerId);
            var categories = await _categories.GetAllCategoriesAsync();
            var manufacturers = await _manufacturers.GetAllManufacturersAsync();
            var resultProducts = new FilterProductsViewModel()
            {
                Products = queryProducts.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                }).ToList(),
                Categories = categories.Select(p => new CategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
                Manufacturers = manufacturers.Select(p => new ManufacturerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList()
            };

            ExtendendedFiltrationViewModel model = new ExtendendedFiltrationViewModel()
            {
                FilteredProducts = resultProducts
            };

            return View(model);
        }

        public async Task<IActionResult> GetSelectedProduct(Guid productId)
        {
            var selectedProduct = await this._products.GetProductById(productId);

            return View(new ExtendedProductViewModel
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                Description = selectedProduct.Description,
                ImageUrl = selectedProduct.ImageUrl,
                Barcode = selectedProduct.Barcode,
                Price = selectedProduct.Price,
                Stock = selectedProduct.Stock,
                Manufacturer = new ManufacturerViewModel
                {
                    Id = selectedProduct.Manufacturer.Id,
                    Name = selectedProduct.Manufacturer.Name,
                },
                Category = new CategoryViewModel
                {
                    Id = selectedProduct.Category.Id,
                    Name = selectedProduct.Category.Name
                }
            });
        }

        public async Task<IActionResult> FilterProducts(string keyword, int categoryId, int manufacturerId)
        {
            var filteredProducts = await _products.GetFilteredProductsAsync(keyword, categoryId, manufacturerId);

            return View("All", new ExtendendedFiltrationViewModel()
            {
                Keyword = filteredProducts.Keyword,
                CategoryId = filteredProducts.CategoryId,
                ManufacturerId = filteredProducts.ManufacturerId,
                FilteredProducts = new FilterProductsViewModel
                {
                    Categories = filteredProducts.FilteredProducts.Categories.Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList(),
                    Manufacturers = filteredProducts.FilteredProducts.Manufacturers.Select(m => new ManufacturerViewModel 
                    { 
                        Id = m.Id,
                        Name = m.Name 
                    })
                    .ToList(),
                    Products = filteredProducts.FilteredProducts.Products.Select(p => new ProductViewModel
                    {
                        Id= p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Quantity = p.Quantity
                    })
                    .ToList()
                }
            });
        }
    }
}
