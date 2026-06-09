namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;

    public class CustomerProductControllerServiceTests : BaseTest
    {
        private readonly Mock<IProductService> _productService;

        public CustomerProductControllerServiceTests()
        {
            _productService = _mockRepository.Create<IProductService>();
        }

        private ProductControllerService GetService()
        {
            return new ProductControllerService(_productService.Object);
        }

        #region GetProductByIdAsync

        [Fact]
        public async Task GetProductById_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _productService.Setup(p => p.GetProductByIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new InvalidOperationException("Product not found"));

            var service = GetService();

            //Act
            var result = await service.GetProductByIdAsync(Guid.NewGuid());

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Product not found", result.ResponseMessage);
        }

        [Fact]
        public async Task GetProductById_Success_ReturnsProduct()
        {
            //Arrange
            var productId = Guid.NewGuid();

            var product = new ExtendedProductViewModel
            {
                Name = "Beach Umbrella Long Name",
                Price = 29.99m
            };

            _productService.Setup(p => p.GetProductByIdAsync(productId)).ReturnsAsync(product);

            var service = GetService();

            //Act
            var result = await service.GetProductByIdAsync(productId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(product, result.Product);
        }

        #endregion

        #region GetFilteredProductsAsync

        [Fact]
        public async Task GetFilteredProducts_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _productService.Setup(p => p.GetFilteredProductsAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(new InvalidOperationException("Filter error"));

            var service = GetService();

            //Act
            var result = await service.GetFilteredProductsAsync("umbrella", 0, 0);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Filter error", result.ResponseMessage);
        }

        [Fact]
        public async Task GetFilteredProducts_Success_ReturnsProducts()
        {
            //Arrange
            var searchResult = new ProductSearchViewModel
            {
                Products = new List<ProductViewModel>
                {
                    new ProductViewModel { Name = "Beach Umbrella Long Name" }
                }
            };

            _productService.Setup(p => p.GetFilteredProductsAsync("umbrella", 1, 0))
                .ReturnsAsync(searchResult);

            var service = GetService();

            //Act
            var result = await service.GetFilteredProductsAsync("umbrella", 1, 0);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(searchResult, result.Products);
        }

        #endregion
    }
}
