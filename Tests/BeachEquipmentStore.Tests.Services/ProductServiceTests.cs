namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Tests.Common;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class ProductServiceTests : BaseTest
    {
        private readonly AllBusinessLogics _allBls;

        public ProductServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
        }

        private ProductService GetProductService()
        {
            return new ProductService(_allBls);
        }

        #region IsInStockAsync

        [Fact]
        public async Task IsInStock_ProductNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Product>(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

            var service = GetProductService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.IsInStockAsync(Guid.NewGuid(), 1));

            Assert.Equal(ProductNotFound, exception.Message);
        }

        [Fact]
        public async Task IsInStock_SufficientStock_ReturnsTrue()
        {
            //Arrange
            var product = new Product
            {
                Name = "Test Product Name",
                Description = "A valid description for product",
                ImageUrl = "http://img.test/product.jpg",
                Price = 9.99m,
                Barcode = 1234567890L,
                Stock = 10
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);

            var service = GetProductService();

            //Act
            var result = await service.IsInStockAsync(product.Id, 5);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsInStock_InsufficientStock_ReturnsFalse()
        {
            //Arrange
            var product = new Product
            {
                Name = "Test Product Name",
                Description = "A valid description for product",
                ImageUrl = "http://img.test/product.jpg",
                Price = 9.99m,
                Barcode = 1234567890L,
                Stock = 3
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);

            var service = GetProductService();

            //Act
            var result = await service.IsInStockAsync(product.Id, 5);

            //Assert
            Assert.False(result);
        }

        #endregion

        #region GetAllProductsAsync

        [Fact]
        public async Task GetAllProducts_ReturnsAllProducts()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product Alpha Name",
                    Description = "Description for alpha product",
                    ImageUrl = "http://img.test/alpha.jpg",
                    Price = 5.00m,
                    Barcode = 1111111111L,
                    Stock = 10
                },
                new Product
                {
                    Name = "Product Beta Name",
                    Description = "Description for beta product",
                    ImageUrl = "http://img.test/beta.jpg",
                    Price = 15.00m,
                    Barcode = 2222222222L,
                    Stock = 0
                }
            };

            _dbMockRepo.Setup(d => d.All<Product>()).Returns(products.AsQueryable());

            var service = GetProductService();

            //Act
            var result = await service.GetAllProductsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count);
            Assert.All(result, vm =>
            {
                var match = products.First(p => p.Id == vm.Id);
                Assert.Equal(match.Name, vm.Name);
                Assert.Equal(match.Price, vm.Price);
                Assert.Equal(match.Stock, vm.Quantity);
            });
        }

        #endregion

        #region GetProductByIdAsync

        [Fact]
        public async Task GetProductById_ProductNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Product>(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

            var service = GetProductService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetProductByIdAsync(Guid.NewGuid()));

            Assert.Equal(ProductNotFound, exception.Message);
        }

        [Fact]
        public async Task GetProductById_ReturnsExtendedProductViewModel()
        {
            //Arrange
            var manufacturer = new Manufacturer
            {
                Id = 1,
                Name = "Vinex",
                ImageUrl = "http://img.test/vinex.jpg"
            };

            var category = new Category
            {
                Id = 2,
                Name = "Р§Р°РґСЉСЂРё"
            };

            var product = new Product
            {
                Name = "Test Product Name",
                Description = "A valid description for product",
                ImageUrl = "http://img.test/product.jpg",
                Price = 29.99m,
                Barcode = 9876543210L,
                Stock = 5,
                ManufacturerId = manufacturer.Id,
                CategoryId = category.Id
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);

            SearchForDbMockRepoHelper(new List<Manufacturer> { manufacturer });
            SearchForDbMockRepoHelper(new List<Category> { category });

            var service = GetProductService();

            //Act
            var result = await service.GetProductByIdAsync(product.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(manufacturer.Id, result.Manufacturer.Id);
            Assert.Equal(manufacturer.Name, result.Manufacturer.Name);
            Assert.Equal(category.Id, result.Category.Id);
            Assert.Equal(category.Name, result.Category.Name);
        }

        #endregion

        #region GetRandomProductsInStockAsync

        [Fact]
        public async Task GetRandomProductsInStock_NoProductsInStock_ThrowsInvalidOperationException()
        {
            //Arrange
            SearchForDbMockRepoHelper(new List<Product>());

            var service = GetProductService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetRandomProductsInStockAsync());

            Assert.Equal(ProductOutOfStock, exception.Message);
        }

        [Fact]
        public async Task GetRandomProductsInStock_WithProductsInStock_ReturnsUpToNineItems()
        {
            //Arrange
            var products = Enumerable.Range(1, 12).Select(i => new Product
            {
                Name = $"Product {i} Long Name",
                Description = $"Description for product number {i}",
                ImageUrl = $"http://img.test/{i}.jpg",
                Price = i * 2.5m,
                Barcode = 1000000000L + i,
                Stock = i
            }).ToList();

            SearchForDbMockRepoHelper(products);

            var service = GetProductService();

            //Act
            var result = await service.GetRandomProductsInStockAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(9, result.Count);
            Assert.All(result, vm => Assert.True(vm.Price > 0));
        }

        #endregion

        #region GetFilteredProductsAsync

        [Fact]
        public async Task GetFilteredProducts_NoFilters_ReturnsAllProducts()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product Alpha Name",
                    Description = "Description for alpha product",
                    ImageUrl = "http://img.test/alpha.jpg",
                    Price = 10.00m,
                    Barcode = 1111111111L,
                    Stock = 5
                },
                new Product
                {
                    Name = "Product Beta Name",
                    Description = "Description for beta product",
                    ImageUrl = "http://img.test/beta.jpg",
                    Price = 20.00m,
                    Barcode = 2222222222L,
                    Stock = 3
                }
            };

            _dbMockRepo.Setup(d => d.All<Product>()).Returns(products.AsQueryable());

            SetupCategoriesRepo();
            SetupManufacturersRepo();

            var service = GetProductService();

            //Act
            var result = await service.GetFilteredProductsAsync(null!, 0, 0);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Products.Count);
            Assert.Equal(_categories.Count, result.Categories.Count);
            Assert.Equal(_manufacturers.Count, result.Manufacturers.Count);
        }

        [Fact]
        public async Task GetFilteredProducts_WithCategoryFilter_ReturnsFilteredByCategory()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product In Category",
                    Description = "Description for first product",
                    ImageUrl = "http://img.test/a.jpg",
                    Price = 10.00m,
                    Barcode = 1111111111L,
                    Stock = 5,
                    CategoryId = 1
                },
                new Product
                {
                    Name = "Product Other Category",
                    Description = "Description for second product",
                    ImageUrl = "http://img.test/b.jpg",
                    Price = 20.00m,
                    Barcode = 2222222222L,
                    Stock = 3,
                    CategoryId = 2
                }
            };

            _dbMockRepo.Setup(d => d.All<Product>()).Returns(products.AsQueryable());

            SetupCategoriesRepo();
            SetupManufacturersRepo();

            var service = GetProductService();

            //Act
            var result = await service.GetFilteredProductsAsync(null!, 1, 0);

            //Assert
            Assert.Single(result.Products);
            Assert.Equal("Product In Category", result.Products[0].Name);
        }

        [Fact]
        public async Task GetFilteredProducts_WithKeyword_EntersKeywordBranch()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.All<Product>()).Returns(new List<Product>().AsQueryable());

            SetupCategoriesRepo();
            SetupManufacturersRepo();

            var service = GetProductService();

            //Act
            var result = await service.GetFilteredProductsAsync("beach", 0, 0);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("beach", result.Keyword);
            Assert.Empty(result.Products);
        }

        [Fact]
        public async Task GetFilteredProducts_WithManufacturerFilter_ReturnsFilteredByManufacturer()
        {
            //Arrange
            var targetManufacturer = new Manufacturer
            {
                Id = 1,
                Name = "Vinex"
            };

            var otherManufacturer = new Manufacturer
            {
                Id = 2,
                Name = "Other Brand"
            };

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product By Vinex",
                    Description = "Description for vinex product",
                    ImageUrl = "http://img.test/vinex.jpg",
                    Price = 10.00m,
                    Barcode = 1111111111L,
                    Stock = 5,
                    ManufacturerId = 1,
                    Manufacturer = targetManufacturer
                },
                new Product
                {
                    Name = "Product By Other",
                    Description = "Description for other product",
                    ImageUrl = "http://img.test/other.jpg",
                    Price = 20.00m,
                    Barcode = 2222222222L,
                    Stock = 3,
                    ManufacturerId = 2,
                    Manufacturer = otherManufacturer
                }
            };

            _dbMockRepo.Setup(d => d.All<Product>()).Returns(products.AsQueryable());

            SetupCategoriesRepo();
            SetupManufacturersRepo();

            var service = GetProductService();

            //Act
            var result = await service.GetFilteredProductsAsync(null!, 0, 1);

            //Assert
            Assert.Single(result.Products);
            Assert.Equal("Product By Vinex", result.Products[0].Name);
        }

        #endregion

        #region RestockProductAsync

        [Fact]
        public async Task RestockProduct_ProductNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

            var service = GetProductService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.RestockProductAsync(Guid.NewGuid(), 10));

            Assert.Equal(ProductNotFound, exception.Message);
        }

        [Fact]
        public async Task RestockProduct_AddsQuantityToStock()
        {
            //Arrange
            var product = new Product
            {
                Name = "Test Product Name",
                Description = "A valid description for product",
                ImageUrl = "http://img.test/product.jpg",
                Price = 19.99m,
                Barcode = 9876543210L,
                Stock = 10
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetProductService();

            //Act
            await service.RestockProductAsync(product.Id, 5);

            //Assert
            Assert.Equal(15, product.Stock);
        }

        #endregion
    }
}
