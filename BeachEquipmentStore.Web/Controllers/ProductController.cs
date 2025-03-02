﻿namespace BeachEquipmentStore.Web.Controllers
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

        //[Route("Alll")]
        //public async Task<IActionResult> All()
        //{
        //    try
        //    {
        //        var categories = await _categories.GetAllCategoriesAsync();
        //        var manufacturers = await _manufacturers.GetAllManufacturersAsync();
        //        var queryResult = await this._products.GetAllProductsAsync();


        //        FilterProductsViewModel allProducts = new FilterProductsViewModel()
        //        {
        //            Products = queryResult.Select(p => new ProductViewModel
        //            {

        //                Id = p.Id,
        //                Name = p.Name,
        //                ImageUrl = p.ImageUrl,
        //                Price = p.Price,
        //            }).ToList(),
        //            Categories = categories.Select(p => new CategoryViewModel
        //            {
        //                Id = p.Id,
        //                Name = p.Name
        //            }).ToList(),
        //            Manufacturers = manufacturers.Select(p => new ManufacturerViewModel
        //            {
        //                Id = p.Id,
        //                Name = p.Name,
        //            }).ToList()
        //        };

        //        ExtendendedFiltrationViewModel model = new ExtendendedFiltrationViewModel()
        //        {
        //            FilteredProducts = allProducts
        //        };

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = ex.Message;

        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        [Route("Product")]
        public async Task<IActionResult> GetSelectedProduct(Guid productId)
        {
            try
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
                            Id = p.Id,
                            Name = p.Name,
                            ImageUrl = p.ImageUrl,
                            Price = p.Price,
                            Quantity = p.Quantity
                        })
                        .ToList()
                    }
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
