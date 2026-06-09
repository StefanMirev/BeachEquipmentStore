namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;

    public class HomeControllerServiceTests : BaseTest
    {
        private readonly Mock<IProductService> _productService;

        public HomeControllerServiceTests()
        {
            _productService = _mockRepository.Create<IProductService>();
        }

        private HomeControllerService GetService()
        {
            return new HomeControllerService(_productService.Object);
        }

        #region ResolveHomePageAsync

        [Fact]
        public async Task ResolveHomePage_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _productService.Setup(p => p.GetRandomProductsInStockAsync())
                .ThrowsAsync(new InvalidOperationException("No products in stock"));

            var service = GetService();

            //Act
            var result = await service.ResolveHomePageAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("No products in stock", result.ResponseMessage);
        }

        [Fact]
        public async Task ResolveHomePage_Success_ReturnsProducts()
        {
            //Arrange
            var products = new List<ProductViewModel>
            {
                new ProductViewModel { Name = "Product One Long Name" },
                new ProductViewModel { Name = "Product Two Long Name" }
            };

            _productService.Setup(p => p.GetRandomProductsInStockAsync()).ReturnsAsync(products);

            var service = GetService();

            //Act
            var result = await service.ResolveHomePageAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Products.Count);
        }

        #endregion
    }
}
