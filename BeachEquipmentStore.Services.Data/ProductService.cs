namespace BeachEquipmentStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using System.Linq;
    using BeachEquipmentStore.Services.Data.Models.Product;
    using BeachEquipmentStore.Services.Data.Models.Cart;
    using System.Collections.Generic;
    using BeachEquipmentStore.Services.Data.Models.Manufacturer;
    using BeachEquipmentStore.Services.Data.Models.Category;
    using Product = BeachEquipmentStore.Data.Models.Product;
    using BeachEquipmentStore.Data.Models;
    using System.Data.Common;
    using Microsoft.Data.SqlClient;

    public class ProductService : IProductService
    {
        private readonly EquipmentStoreDbContext _data;

        public ProductService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public async Task<ExtendedProductServiceModel> GetProductById(Guid productId)
        {
            Product product = await _data.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .FirstAsync(p => p.Id.ToString() == productId.ToString());

            return new ExtendedProductServiceModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Barcode = product.Barcode,
                Price = product.Price,
                Stock = product.Stock,
                Manufacturer = new ManufacturerServiceModel
                {
                    Id = product.Manufacturer.Id,
                    Name = product.Manufacturer.Name
                },
                Category = new CategoryServiceModel
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };
        }

        public async Task<List<ProductServiceModel>> GetAllProductsAsync()
        {
            return await _data.Products
                .OrderBy(p => p.Stock)
                 .ThenBy(p => p.CategoryId)
                 .ThenBy(p => p.Id)
                 .Select(p => new ProductServiceModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price
                 })
                 .ToListAsync();
        }

        public async Task<List<ProductServiceModel>> GetRandomProductsInStockAsync()
        {
            int productsInStock = await _data.Products.Where(p => p.Stock > 0).CountAsync();

            if (productsInStock <= 0)
            {
                throw new InvalidOperationException("There are currently no products in stock!");
            }

            return await _data.Products
                 .Where(p => p.Stock > 0)
                 .OrderBy(p => Guid.NewGuid())
                 .Take(productsInStock > 9 ? 9 : productsInStock)
                 .Select(p => new ProductServiceModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price
                 })
                 .ToListAsync();
        }

        public async Task<List<ProductServiceModel>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _data.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToListAsync();
        }

        public async Task<List<ProductServiceModel>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return await _data.Products
                .Where(p => p.ManufacturerId == manufacturerId)
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToListAsync();
        }

        public async Task<List<ProductServiceModel>> GetProductsInCart(List<CartServiceModel> cartItems)
        {
            List<ProductServiceModel> productsInCart = new List<ProductServiceModel>();

            foreach (CartServiceModel cartItem in cartItems)
            {
                productsInCart.AddRange(await _data.Products
                    .Where(p => p.Id == cartItem.ProductId)
                    .Select(p => new ProductServiceModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Quantity = cartItem.Quantity
                    })
                    .ToListAsync());
            }

            return productsInCart;
        }

        public async Task<bool> IsInStock(Guid productId, int quantity)
        {
            Product product = await _data.Products
                .FirstAsync(p => p.Id == productId);

            return product.Stock >= quantity ? true : false;
        }

        public async Task<ExtendedFiltrationServiceModel> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId)
        {
            var filteredProducts = _data.Products.AsQueryable();
            List<Category> allCategories = await _data.Categories.ToListAsync();
            List<Manufacturer> allManufacturers = await _data.Manufacturers.ToListAsync();

            if (!string.IsNullOrEmpty(keyword))
            {   
                filteredProducts = filteredProducts
                    .Where(p => EF.Functions.Like(p.Name, $"%{keyword}%") ||
                    EF.Functions.Like(p.Manufacturer.Name, $"%{keyword}%") ||
                    EF.Functions.Like(p.Description, $"%{keyword}%") ||
                    EF.Functions.Like(p.Category.Name, $"%{keyword}%"));
            }

            if (categoryId > 0)
            {
                filteredProducts = filteredProducts.Where(p => p.CategoryId == categoryId);
            }

            if (manufacturerId > 0)
            {
                filteredProducts = filteredProducts.Where(p => p.Manufacturer.Id == manufacturerId);
            }

            var filteredModel = new ExtendedFiltrationServiceModel
            {
                Keyword = keyword,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                FilteredProducts = new FilterProductsServiceModel
                {
                    Categories = allCategories.Select(c => new CategoryServiceModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                .ToList(),
                    Manufacturers = allManufacturers.Select(m => new ManufacturerServiceModel
                    {
                        Id = m.Id,
                        Name = m.Name
                    })
                .ToList(),
                    Products = filteredProducts.Select(p => new ProductServiceModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Quantity = p.Stock
                    }).ToList()
                }
            };

            return filteredModel;
        }
    }
}