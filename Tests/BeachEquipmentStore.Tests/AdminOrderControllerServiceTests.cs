namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.Web.Areas.Admin.ControllerServices;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class AdminOrderControllerServiceTests : BaseTest
    {
        private readonly Mock<IOrderService> _orderService;

        public AdminOrderControllerServiceTests()
        {
            _orderService = _mockRepository.Create<IOrderService>();
        }

        private OrderControllerService GetService()
        {
            return new OrderControllerService(_orderService.Object);
        }

        #region GetUndeliveredOrdersAsync

        [Fact]
        public async Task GetUndeliveredOrders_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _orderService.Setup(o => o.GetUndeliveredOrdersAsync())
                .ThrowsAsync(new InvalidOperationException("Service error"));

            var service = GetService();

            //Act
            var result = await service.GetUndeliveredOrdersAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Service error", result.ResponseMessage);
        }

        [Fact]
        public async Task GetUndeliveredOrders_Success_ReturnsPendingOrders()
        {
            //Arrange
            var orders = new List<PendingOrderViewModel>
            {
                new PendingOrderViewModel { Id = Guid.NewGuid() },
                new PendingOrderViewModel { Id = Guid.NewGuid() }
            };

            _orderService.Setup(o => o.GetUndeliveredOrdersAsync()).ReturnsAsync(orders);

            var service = GetService();

            //Act
            var result = await service.GetUndeliveredOrdersAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.UndeliveredOrders.Count);
        }

        #endregion

        #region DeliverOrdersAsync

        [Fact]
        public async Task DeliverOrders_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var orderId = Guid.NewGuid();

            _orderService.Setup(o => o.DeliverOrdersAsync(orderId))
                .ThrowsAsync(new InvalidOperationException("Order not found"));

            var service = GetService();

            //Act
            var result = await service.DeliverOrdersAsync(orderId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Order not found", result.ResponseMessage);
        }

        [Fact]
        public async Task DeliverOrders_ServiceReturnsFalse_ReturnsFailureResponse()
        {
            //Arrange
            var orderId = Guid.NewGuid();

            _orderService.Setup(o => o.DeliverOrdersAsync(orderId)).ReturnsAsync(false);

            var service = GetService();

            //Act
            var result = await service.DeliverOrdersAsync(orderId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(OrderDeliveryFailure, result.ResponseMessage);
        }

        [Fact]
        public async Task DeliverOrders_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var orderId = Guid.NewGuid();

            _orderService.Setup(o => o.DeliverOrdersAsync(orderId)).ReturnsAsync(true);

            var service = GetService();

            //Act
            var result = await service.DeliverOrdersAsync(orderId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(OrderDeliverySuccess, result.ResponseMessage);
        }

        #endregion
    }
}
