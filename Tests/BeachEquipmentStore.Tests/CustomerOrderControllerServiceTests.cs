namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class CustomerOrderControllerServiceTests : BaseTest
    {
        private readonly Mock<ICartService> _cartService;
        private readonly Mock<IOrderService> _orderService;

        public CustomerOrderControllerServiceTests()
        {
            _cartService = _mockRepository.Create<ICartService>();
            _orderService = _mockRepository.Create<IOrderService>();
        }

        private OrderControllerService GetService()
        {
            return new OrderControllerService(_cartService.Object, _orderService.Object);
        }

        #region GetDetailsForCreateOrderAsync

        [Fact]
        public async Task GetDetailsForCreateOrder_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _orderService.Setup(o => o.GetDetailsForCreateOrderAsync())
                .ThrowsAsync(new InvalidOperationException("User not found"));

            var service = GetService();

            //Act
            var result = await service.GetDetailsForCreateOrderAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("User not found", result.ResponseMessage);
        }

        [Fact]
        public async Task GetDetailsForCreateOrder_Success_ReturnsViewModel()
        {
            //Arrange
            var createOrderViewModel = new CreateOrderViewModel
            {
                UserDetails = new UserSummaryViewModel
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            };

            _orderService.Setup(o => o.GetDetailsForCreateOrderAsync()).ReturnsAsync(createOrderViewModel);

            var service = GetService();

            //Act
            var result = await service.GetDetailsForCreateOrderAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(createOrderViewModel, result.DetailsForCreateOrder);
        }

        #endregion

        #region CreateOrderAsync

        [Fact]
        public async Task CreateOrder_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _orderService.Setup(o => o.CreateOrderAsync("Main Street 1", "Sofia", "1000"))
                .ThrowsAsync(new InvalidOperationException("Order error"));

            var service = GetService();

            //Act
            var result = await service.CreateOrderAsync("Main Street 1", "Sofia", "1000");

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Order error", result.ResponseMessage);
        }

        [Fact]
        public async Task CreateOrder_Success_ClearsCartAndReturnsSuccess()
        {
            //Arrange
            _orderService.Setup(o => o.CreateOrderAsync("Main Street 1", "Sofia", "1000")).Returns(Task.CompletedTask);
            _cartService.Setup(c => c.ClearCartAsync(false)).Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.CreateOrderAsync("Main Street 1", "Sofia", "1000");

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(OrderCreateSuccess, result.ResponseMessage);
        }

        #endregion

        #region GetOrderDetailsAsync

        [Fact]
        public async Task GetOrderDetails_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var orderId = Guid.NewGuid();

            _orderService.Setup(o => o.GetOrderDetailsAsync(orderId))
                .ThrowsAsync(new InvalidOperationException("Order not found"));

            var service = GetService();

            //Act
            var result = await service.GetOrderDetailsAsync(orderId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Order not found", result.ResponseMessage);
        }

        [Fact]
        public async Task GetOrderDetails_Success_ReturnsOrderDetails()
        {
            //Arrange
            var orderId = Guid.NewGuid();

            var orderDetails = new OrderDetailViewModel
            {
                Id = orderId,
                AddressName = "Main Street 123",
                TotalPrice = 99.99m
            };

            _orderService.Setup(o => o.GetOrderDetailsAsync(orderId)).ReturnsAsync(orderDetails);

            var service = GetService();

            //Act
            var result = await service.GetOrderDetailsAsync(orderId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(orderDetails, result.OrderDetails);
        }

        #endregion
    }
}
