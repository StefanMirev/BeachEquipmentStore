namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using BeachEquipmentStore.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class ProductService : IProductService
    {
        private readonly AllBusinessLogics _allBls;

        public ProductService(AllBusinessLogics allBls)
        {
            _allBls = allBls;
        }

        public async Task<ExtendedProductViewModel> GetProductByIdAsync(Guid productId)
        {
            var product = await _allBls.ProductsBL.AsQueryable().AsNoTracking()
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == productId)
                ?? throw new InvalidOperationException(ProductNotFound);

            return new ExtendedProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Barcode = product.Barcode,
                Price = product.Price,
                Quantity = product.Stock,
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
            var products = await _allBls.ProductsBL.GetAllAsync();

            return products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Quantity = p.Stock
                })
                .ToList();
        }

        public async Task<List<ProductViewModel>> GetRandomProductsInStockAsync()
        {
            var productsInStock = await _allBls.ProductsBL.GetAllAsync(p => p.Stock > 0);

            if (!productsInStock.Any())
            {
                throw new InvalidOperationException(ProductOutOfStock);
            }

            return productsInStock
                .OrderBy(p => Guid.NewGuid())
                .Take(9)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToList();
        }

        public async Task<bool> IsInStockAsync(Guid productId, int quantity)
        {
            var product = await _allBls.ProductsBL.FindAsNoTrackingAsync(productId)
                ?? throw new InvalidOperationException(ProductNotFound);

            return product.Stock >= quantity;
        }

        public async Task<ProductSearchViewModel> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId)
        {
            var filteredProducts = _allBls.ProductsBL.AsQueryable();

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

            var categories = await _allBls.CategoriesBL.GetAllAsync();
            var manufacturers = await _allBls.ManufacturersBL.GetAllAsync();

            return new ProductSearchViewModel
            {
                Keyword = keyword,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                Categories = categories.Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name }).ToList(),
                Manufacturers = manufacturers.Select(m => new ManufacturerViewModel { Id = m.Id, Name = m.Name }).ToList(),
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
            using var transaction = _allBls.ProductsBL.GetTransactionProxy();
            try
            {
                var product = await _allBls.ProductsBL.FindAsync(productId)
                    ?? throw new InvalidOperationException(ProductNotFound);

                product.Stock += quantity;

                await _allBls.ProductsBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
