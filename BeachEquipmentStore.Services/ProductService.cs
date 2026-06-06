namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Services.DTOs;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using BeachEquipmentStore.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class ProductService : IProductService
    {
        private readonly EquipmentStoreDbContext _data;

        public ProductService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public async Task<ExtendedProductViewModel> GetProductByIdAsync(Guid productId)
        {
            if (!await _data.Products.AnyAsync(a => a.Id == productId))
            {
                throw new InvalidOperationException(ProductNotFound);
            }

            var product = await _data.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .FirstAsync(p => p.Id.ToString() == productId.ToString());

            return new ExtendedProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Barcode = product.Barcode,
                Price = product.Price,
                Stock = product.Stock,
                Manufacturer = new ManufacturerViewModel
                {
                    Id = product.Manufacturer.Id,
                    Name = product.Manufacturer.Name
                },
                Category = new CategoryViewModel
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return await _data.Products
                 .Select(p => new ProductViewModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price,
                     Quantity = p.Stock
                 })
                 .ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetRandomProductsInStockAsync()
        {
            var productsInStock = await _data.Products.Where(p => p.Stock > 0).CountAsync();

            if (productsInStock <= 0)
            {
                throw new InvalidOperationException(ProductOutOfStock);
            }

            return await _data.Products
                 .Where(p => p.Stock > 0)
                 .OrderBy(p => Guid.NewGuid())
                 .Take(productsInStock > 9 ? 9 : productsInStock)
                 .Select(p => new ProductViewModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price
                 })
                 .ToListAsync();
        }

        public async Task<List<CartProductViewModel>> GetProductsInCartAsync(List<CartItemDto> cartItems)
        {
            var productsInCart = new List<CartProductViewModel>();

            foreach (var cartItem in cartItems)
            {
                productsInCart.AddRange(await _data.Products
                    .Where(p => p.Id == cartItem.ProductId)
                    .Select(p => new CartProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        CartQuantity = cartItem.Quantity
                    })
                    .ToListAsync());
            }

            return productsInCart;
        }

        public async Task<bool> IsInStockAsync(Guid productId, int quantity)
        {
            if (!await _data.Products.AnyAsync(a => a.Id == productId))
            {
                throw new InvalidOperationException(ProductNotFound);
            }

            return (await _data.Products.FindAsync(productId))!.Stock >= quantity;
        }

        public async Task<ProductSearchViewModel> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId)
        {
            var filteredProducts = _data.Products.AsQueryable();

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

            return new ProductSearchViewModel
            {
                Keyword = keyword,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                Categories = await _data.Categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync(),
                Manufacturers = await _data.Manufacturers.Select(m => new ManufacturerViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToListAsync(),
                Products = await filteredProducts.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Quantity = p.Stock
                }).ToListAsync()
            };
        }

        public async Task RestockProductAsync(Guid productId, int quantity)
        {
            if (!await _data.Products.AnyAsync(a => a.Id == productId))
            {
                throw new InvalidOperationException(ProductNotFound);
            }

            var product = await _data.Products.FindAsync(productId);

            product!.Stock += quantity;

            await _data.SaveChangesAsync();
        }
    }
}
