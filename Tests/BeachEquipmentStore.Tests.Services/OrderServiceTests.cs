namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using Core.Enums;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class OrderServiceTests : BaseTest
    {
        private readonly AllBusinessLogics _allBls;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IAddressService> _addressService;

        public OrderServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
            _userService = _mockRepository.Create<IUserService>();
            _addressService = _mockRepository.Create<IAddressService>();
        }

        private OrderService GetOrderService()
        {
            return new OrderService(_addressService.Object, _userService.Object, _allBls);
        }

        #region GetCurrentUserOrderHistoryAsync

        [Fact]
        public async Task GetCurrentUserOrderHistory_UserNotFound_ThrowsArgumentNullException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.GetCurrentUserOrderHistoryAsync());

            Assert.Equal(UserNotFound, exception.ParamName);
        }

        [Fact]
        public async Task GetCurrentUserOrderHistory_ReturnsOrderedList()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var orders = new List<Order>
            {
                new Order
                {
                    CustomerUserId = userId,
                    DeliveryStatus = DeliveryStatus.Пътува,
                    TotalPrice = 50.00m,
                    AddressLogId = Guid.NewGuid()
                },
                new Order
                {
                    CustomerUserId = userId,
                    DeliveryStatus = DeliveryStatus.Доставена,
                    TotalPrice = 30.00m,
                    AddressLogId = Guid.NewGuid()
                }
            };

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(orders);

            var service = GetOrderService();

            //Act
            var result = await service.GetCurrentUserOrderHistoryAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, vm => Assert.NotEqual(Guid.Empty, vm.Id));
        }

        #endregion

        #region GetDetailsForCreateOrderAsync

        [Fact]
        public async Task GetDetailsForCreateOrder_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetDetailsForCreateOrderAsync());

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task GetDetailsForCreateOrder_CustomerUserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync((CustomerUser?)null);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetDetailsForCreateOrderAsync());

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task GetDetailsForCreateOrder_ReturnsViewModel()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var customerUser = new CustomerUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "0888000000"
            };

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 2
            };

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 25.00m,
                Barcode = 1234567890L,
                Stock = 10
            };

            product.Id = productId;

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);

            SearchForDbMockRepoHelper(new List<Address>());
            SearchForDbMockRepoHelper(new List<CartItem> { cartItem });
            SearchForDbMockRepoHelper(new List<Product> { product });

            var service = GetOrderService();

            //Act
            var result = await service.GetDetailsForCreateOrderAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.UserDetails.FirstName);
            Assert.Equal("user@example.com", result.UserDetails.Email);
            Assert.Single(result.Products);
            Assert.Equal(product.Name, result.Products[0].Name);
        }

        #endregion

        #region CreateOrderAsync

        [Fact]
        public async Task CreateOrder_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateOrderAsync("Main Street 1", "Sofia", "1000"));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task CreateOrder_AddressExists_CreatesOrderSuccessfully()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var addressName = "Main Street 123";
            var town = "Sofia";
            var zipCode = "1000";

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var existingAddress = new Address
            {
                Name = addressName,
                Town = town,
                ZipCode = zipCode,
                CustomerUserId = userId
            };

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 2
            };

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 15.00m,
                Barcode = 1234567890L,
                Stock = 10
            };

            product.Id = productId;

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<Address>()).Returns(new List<Address> { existingAddress }.AsQueryable());

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            SearchForDbMockRepoHelper(new List<CartItem> { cartItem });
            SearchForDbMockRepoHelper(new List<Product> { product });

            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<AddressLog>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<ProductLog>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<ProductOrder>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetOrderService();

            //Act
            await service.CreateOrderAsync(addressName, town, zipCode);

            //Assert
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<Order>()), Times.Once);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<ProductLog>()), Times.Once);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<ProductOrder>()), Times.Once);
        }

        #endregion

        #region GetOrderDetailsAsync

        [Fact]
        public async Task GetOrderDetails_OrderNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Order>(It.IsAny<Guid>())).ReturnsAsync((Order?)null);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetOrderDetailsAsync(Guid.NewGuid()));

            Assert.Equal(OrderNotFound, exception.Message);
        }

        [Fact]
        public async Task GetOrderDetails_WrongUser_ThrowsInvalidOperationException()
        {
            //Arrange
            var orderId = Guid.NewGuid();
            var orderOwnerId = Guid.NewGuid();
            var differentUserId = Guid.NewGuid();

            var order = new Order
            {
                CustomerUserId = orderOwnerId,
                DeliveryStatus = DeliveryStatus.Пътува,
                TotalPrice = 100.00m,
                AddressLogId = Guid.NewGuid()
            };

            order.Id = orderId;

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Order>(It.IsAny<Guid>())).ReturnsAsync(order);
            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(differentUserId);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetOrderDetailsAsync(orderId));

            Assert.Equal(OrderNotFound, exception.Message);
        }

        [Fact]
        public async Task GetOrderDetails_ReturnsViewModel()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var addressLogId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var productLogId = Guid.NewGuid();

            var order = new Order
            {
                CustomerUserId = userId,
                DeliveryStatus = DeliveryStatus.Пътува,
                TotalPrice = 50.00m,
                AddressLogId = addressLogId
            };

            order.Id = orderId;

            var addressLog = new AddressLog
            {
                Name = "Main Street 123",
                Town = "Sofia",
                ZipCode = "1000"
            };

            addressLog.Id = addressLogId;

            var productLog = new ProductLog
            {
                Name = "Product Name Here",
                Price = 25.00m
            };

            productLog.Id = productLogId;

            var productOrder = new ProductOrder
            {
                OrderId = orderId,
                ProductId = productId,
                ProductLogId = productLogId,
                Quantity = 2
            };

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 25.00m,
                Barcode = 1234567890L,
                Stock = 8
            };

            product.Id = productId;

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Order>(It.IsAny<Guid>())).ReturnsAsync(order);
            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AddressLog>(It.IsAny<Guid>())).ReturnsAsync(addressLog);

            SearchForDbMockRepoHelper(new List<ProductOrder> { productOrder } );
            SearchForDbMockRepoHelper(new List<ProductLog> { productLog });
            SearchForDbMockRepoHelper(new List<Product> { product });

            var service = GetOrderService();

            //Act
            var result = await service.GetOrderDetailsAsync(orderId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(orderId, result.Id);
            Assert.Equal(addressLog.Name, result.AddressName);
            Assert.Equal(50.00m, result.TotalPrice);
            Assert.Single(result.Products);
            Assert.Equal(productLog.Name, result.Products[0].Name);
            Assert.Equal(2, result.Products[0].Quantity);
        }

        #endregion

        #region GetUndeliveredOrdersAsync

        [Fact]
        public async Task GetUndeliveredOrders_ReturnsPendingOrders()
        {
            //Arrange
            var orders = new List<Order>
            {
                new Order
                {
                    CustomerUserId = Guid.NewGuid(),
                    DeliveryStatus = DeliveryStatus.Пътува,
                    TotalPrice = 20.00m,
                    AddressLogId = Guid.NewGuid()
                },
                new Order
                {
                    CustomerUserId = Guid.NewGuid(),
                    DeliveryStatus = DeliveryStatus.Доставена,
                    TotalPrice = 40.00m,
                    AddressLogId = Guid.NewGuid()
                }
            };

            SearchForDbMockRepoHelper(orders);

            var service = GetOrderService();

            //Act
            var result = await service.GetUndeliveredOrdersAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        #endregion

        #region DeliverOrdersAsync

        [Fact]
        public async Task DeliverOrders_OrderNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Order>(It.IsAny<Guid>())).ReturnsAsync((Order?)null);

            var service = GetOrderService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.DeliverOrdersAsync(Guid.NewGuid()));

            Assert.Equal(OrderNotFound, exception.Message);
        }

        [Fact]
        public async Task DeliverOrders_UpdatesStatusAndReturnsTrue()
        {
            //Arrange
            var order = new Order
            {
                CustomerUserId = Guid.NewGuid(),
                DeliveryStatus = DeliveryStatus.Пътува,
                TotalPrice = 75.00m,
                AddressLogId = Guid.NewGuid()
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Order>(It.IsAny<Guid>())).ReturnsAsync(order);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetOrderService();

            //Act
            var result = await service.DeliverOrdersAsync(order.Id);

            //Assert
            Assert.True(result);
            Assert.Equal(DeliveryStatus.Доставена, order.DeliveryStatus);
            Assert.NotNull(order.ShippingDate);
        }

        #endregion
    }
}
