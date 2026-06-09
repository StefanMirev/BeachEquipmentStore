namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class CartControllerServiceTests : BaseTest
    {
        private readonly Mock<ICartService> _cartService;
        private readonly Mock<IProductService> _productService;

        public CartControllerServiceTests()
        {
            _cartService = _mockRepository.Create<ICartService>();
            _productService = _mockRepository.Create<IProductService>();
        }

        private CartControllerService GetService()
        {
            return new CartControllerService(_cartService.Object, _productService.Object);
        }

        #region GoToCartAsync

        [Fact]
        public async Task GoToCart_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _cartService.Setup(c => c.GetCartProductsAsync())
                .ThrowsAsync(new InvalidOperationException("Cart error"));

            var service = GetService();

            //Act
            var result = await service.GoToCartAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Cart error", result.ResponseMessage);
        }

        [Fact]
        public async Task GoToCart_Success_ReturnsCartProducts()
        {
            //Arrange
            var products = new List<CartProductViewModel>
            {
                new CartProductViewModel { Name = "Beach Towel Long Name", Quantity = 2 },
                new CartProductViewModel { Name = "Beach Umbrella Long Name", Quantity = 1 }
            };

            _cartService.Setup(c => c.GetCartProductsAsync()).ReturnsAsync(products);

            var service = GetService();

            //Act
            var result = await service.GoToCartAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Products.Count);
        }

        #endregion

        #region AddToCartAsync

        [Fact]
        public async Task AddToCart_QuantityZero_ReturnsFailureResponse()
        {
            //Arrange
            var service = GetService();

            //Act
            var result = await service.AddToCartAsync(Guid.NewGuid(), 0);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ResponseMessage);
        }

        [Fact]
        public async Task AddToCart_NegativeQuantity_ReturnsFailureResponse()
        {
            //Arrange
            var service = GetService();

            //Act
            var result = await service.AddToCartAsync(Guid.NewGuid(), -5);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ResponseMessage);
        }

        [Fact]
        public async Task AddToCart_ProductOutOfStock_ReturnsFailureResponse()
        {
            //Arrange
            var productId = Guid.NewGuid();

            _productService.Setup(p => p.IsInStockAsync(productId, 3)).ReturnsAsync(false);

            var service = GetService();

            //Act
            var result = await service.AddToCartAsync(productId, 3);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ProductOutOfStock, result.ResponseMessage);
        }

        [Fact]
        public async Task AddToCart_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var productId = Guid.NewGuid();

            _productService.Setup(p => p.IsInStockAsync(productId, 2)).ReturnsAsync(true);
            _cartService.Setup(c => c.AddItemToCartAsync(productId, 2)).Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.AddToCartAsync(productId, 2);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(CartAddSuccess, result.ResponseMessage);
        }

        #endregion

        #region ClearCartAsync

        [Fact]
        public async Task ClearCart_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _cartService.Setup(c => c.ClearCartAsync(true))
                .ThrowsAsync(new InvalidOperationException("Clear failed"));

            var service = GetService();

            //Act
            var result = await service.ClearCartAsync(restoreStock: true);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Clear failed", result.ResponseMessage);
        }

        [Fact]
        public async Task ClearCart_Success_ReturnsSuccessResponse()
        {
            //Arrange
            _cartService.Setup(c => c.ClearCartAsync(true)).Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.ClearCartAsync(restoreStock: true);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(CartClearSuccess, result.ResponseMessage);
        }

        #endregion

        #region RemoveItemFromCartAsync

        [Fact]
        public async Task RemoveItemFromCart_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var productId = Guid.NewGuid();

            _cartService.Setup(c => c.RemoveItemFromCartAsync(productId))
                .ThrowsAsync(new InvalidOperationException("Item not found"));

            var service = GetService();

            //Act
            var result = await service.RemoveItemFromCartAsync(productId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Item not found", result.ResponseMessage);
        }

        [Fact]
        public async Task RemoveItemFromCart_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var productId = Guid.NewGuid();

            _cartService.Setup(c => c.RemoveItemFromCartAsync(productId)).Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.RemoveItemFromCartAsync(productId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(CartRemoveSuccess, result.ResponseMessage);
        }

        #endregion
    }
}
