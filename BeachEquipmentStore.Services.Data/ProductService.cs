namespace BeachEquipmentStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Web.ViewModels.Home;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using System.Linq;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Data.Models.Product;
    using BeachEquipmentStore.Services.Data.Models.Cart;
    using System.Collections.Generic;

    public class ProductService : IProductService
    {
        private readonly EquipmentStoreDbContext _data;

        public ProductService(EquipmentStoreDbContext data)
        {
            _data = data;
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
    }
}
