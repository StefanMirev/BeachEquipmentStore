namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.Web.Areas.Admin.ControllerServices;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class AdminProductControllerServiceTests : BaseTest
    {
        private readonly Mock<IProductService> _productService;

        public AdminProductControllerServiceTests()
        {
            _productService = _mockRepository.Create<IProductService>();
        }

        private ProductControllerService GetService()
        {
            return new ProductControllerService(_productService.Object);
        }

        #region GetAllProductsAsync

        [Fact]
        public async Task GetAllProducts_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _productService.Setup(p => p.GetAllProductsAsync())
                .ThrowsAsync(new InvalidOperationException("Service error"));

            var service = GetService();

            //Act
            var result = await service.GetAllProductsAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Service error", result.ResponseMessage);
        }

        [Fact]
        public async Task GetAllProducts_Success_ReturnsProductsOrderedByQuantity()
        {
            //Arrange
            var products = new List<ProductViewModel>
            {
                new ProductViewModel { Name = "Beach Umbrella Long Name", Quantity = 10 },
                new ProductViewModel { Name = "Beach Towel Long Name", Quantity = 2 },
                new ProductViewModel { Name = "Swim Goggles Long Name", Quantity = 5 }
            };

            _productService.Setup(p => p.GetAllProductsAsync()).ReturnsAsync(products);

            var service = GetService();

            //Act
            var result = await service.GetAllProductsAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(3, result.Products.Count);
            Assert.Equal(2, result.Products[0].Quantity);
            Assert.Equal(5, result.Products[1].Quantity);
            Assert.Equal(10, result.Products[2].Quantity);
        }

        #endregion

        #region RestockProductAsync

        [Fact]
        public async Task RestockProduct_QuantityZero_ReturnsFailureResponse()
        {
            //Arrange
            var service = GetService();

            //Act
            var result = await service.RestockProductAsync(Guid.NewGuid(), 0);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ProductQuantityTooLow, result.ResponseMessage);
        }

        [Fact]
        public async Task RestockProduct_NegativeQuantity_ReturnsFailureResponse()
        {
            //Arrange
            var service = GetService();

            //Act
            var result = await service.RestockProductAsync(Guid.NewGuid(), -3);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ProductQuantityTooLow, result.ResponseMessage);
        }

        [Fact]
        public async Task RestockProduct_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var productId = Guid.NewGuid();

            _productService.Setup(p => p.RestockProductAsync(productId, 5))
                .ThrowsAsync(new InvalidOperationException("Product not found"));

            var service = GetService();

            //Act
            var result = await service.RestockProductAsync(productId, 5);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Product not found", result.ResponseMessage);
        }

        [Fact]
        public async Task RestockProduct_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var productId = Guid.NewGuid();

            _productService.Setup(p => p.RestockProductAsync(productId, 20)).Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.RestockProductAsync(productId, 20);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ProductRestockSuccess, result.ResponseMessage);
        }

        #endregion
    }
}
