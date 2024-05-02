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
    using System.Runtime.CompilerServices;

    public class ProductService : IProductService
    {
        private readonly EquipmentStoreDbContext _data;

        public ProductService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public async Task<ExtendedProductServiceModel> GetProductById(Guid productId)
        {
            if (!await _data.Products.AnyAsync(a => a.Id == productId))
            {
                throw new InvalidOperationException("Продуктът не съществува!");
            }

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
                 .Select(p => new ProductServiceModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price,
                     Quantity = p.Stock
                 })
                 .ToListAsync();
        }

        public async Task<List<ProductServiceModel>> GetRandomProductsInStockAsync()
        {
            int productsInStock = await _data.Products.Where(p => p.Stock > 0).CountAsync();

            if (productsInStock <= 0)
            {
                throw new InvalidOperationException("В момента няма наличност от избрания продукт!");
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
            if (!await _data.Products.AnyAsync(a => a.Id == productId))
            {
                throw new InvalidOperationException("Продуктът не съществува!");
            }

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
                string escapedKeyword = keyword.Replace("%", "\\%");

                filteredProducts = filteredProducts
                    .Where(p => EF.Functions.Like(p.Name, $"%{escapedKeyword}%") ||
                    EF.Functions.Like(p.Manufacturer.Name, $"%{escapedKeyword}%") ||
                    EF.Functions.Like(p.Description, $"%{escapedKeyword}%") ||
                    EF.Functions.Like(p.Category.Name, $"%{escapedKeyword}%"));
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

        public async Task RestockProduct(Guid productId, int quantity)
        {
            if (!await _data.Products.AnyAsync(a => a.Id == productId))
            {
                throw new InvalidOperationException("Продуктът не съществува!");
            }

            var product = await _data.Products.FindAsync(productId);

            product!.Stock += quantity;

            await _data.SaveChangesAsync();
        }
    }
}