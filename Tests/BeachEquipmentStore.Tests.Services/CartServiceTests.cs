namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using Moq;
    using System.Linq.Expressions;
    using static Core.Common.Constants.Messages;

    public class CartServiceTests : BaseTest
    {
        private readonly AllBusinessLogics _allBls;
        private readonly Mock<IUserService> _userService;

        public CartServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
            _userService = _mockRepository.Create<IUserService>();
        }

        private CartService GetCartService()
        {
            return new CartService(_userService.Object, _allBls);
        }

        #region GetCartProductsAsync

        [Fact]
        public async Task GetCartProducts_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetCartService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetCartProductsAsync());

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task GetCartProducts_EmptyCart_ReturnsEmptyList()
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

            SearchForDbMockRepoHelper(new List<CartItem>());

            var service = GetCartService();

            //Act
            var result = await service.GetCartProductsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetCartProducts_WithItems_ReturnsMappedViewModels()
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

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 2
            };

            var product = new Product
            {
                Name = "Product In Cart",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 15.00m,
                Barcode = 1234567890L,
                Stock = 5
            };

            product.Id = productId;

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(new List<CartItem> { cartItem });
            SearchForDbMockRepoHelper(new List<Product> { product });

            var service = GetCartService();

            //Act
            var result = await service.GetCartProductsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(product.Name, result[0].Name);
            Assert.Equal(product.Price, result[0].Price);
            Assert.Equal(cartItem.Quantity, result[0].CartQuantity);
        }

        #endregion

        #region AddItemToCartAsync

        [Fact]
        public async Task AddItemToCart_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetCartService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.AddItemToCartAsync(Guid.NewGuid(), 1));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task AddItemToCart_NewItem_AddsCartItemAndDeductsStock()
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

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 10.00m,
                Barcode = 1234567890L,
                Stock = 20
            };

            product.Id = productId;

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<CartItem, bool>>>())).ReturnsAsync((CartItem?)null);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<CartItem>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetCartService();

            //Act
            await service.AddItemToCartAsync(productId, 3);

            //Assert
            Assert.Equal(17, product.Stock);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<CartItem>()), Times.Once);
        }

        [Fact]
        public async Task AddItemToCart_ExceptionDuringSave_RollsBackAndRethrows()
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

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 10.00m,
                Barcode = 1234567890L,
                Stock = 20
            };

            product.Id = productId;

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<CartItem, bool>>>())).ReturnsAsync((CartItem?)null);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<CartItem>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ThrowsAsync(new Exception("DB error"));

            var service = GetCartService();

            //Act & Assert
            await Assert.ThrowsAsync<Exception>(() => service.AddItemToCartAsync(productId, 1));
        }

        [Fact]
        public async Task AddItemToCart_ExistingItem_IncrementsQuantityAndDeductsStock()
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

            var existingCartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 1
            };

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 10.00m,
                Barcode = 1234567890L,
                Stock = 15
            };

            product.Id = productId;

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<CartItem, bool>>>())).ReturnsAsync(existingCartItem);
            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetCartService();

            //Act
            await service.AddItemToCartAsync(productId, 2);

            //Assert
            Assert.Equal(3, existingCartItem.Quantity);
            Assert.Equal(13, product.Stock);
        }

        #endregion

        #region ClearCartAsync

        [Fact]
        public async Task ClearCart_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetCartService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.ClearCartAsync(false));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task ClearCart_WithoutRestoreStock_ClearsCart()
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

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 2
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(new List<CartItem> { cartItem });

            _dbMockRepo.Setup(d => d.Delete(It.IsAny<CartItem>()));
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetCartService();

            //Act
            await service.ClearCartAsync(false);

            //Assert
            _dbMockRepo.Verify(d => d.Delete(It.IsAny<CartItem>()), Times.Once);
            _dbMockRepo.Verify(d => d.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task ClearCart_WithRestoreStock_RestoresStockAndClears()
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

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 3
            };

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 10.00m,
                Barcode = 1234567890L,
                Stock = 5
            };

            product.Id = productId;

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(new List<CartItem> { cartItem });

            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.Delete(It.IsAny<CartItem>()));
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetCartService();

            //Act
            await service.ClearCartAsync(true);

            //Assert
            Assert.Equal(8, product.Stock);
            _dbMockRepo.Verify(d => d.Delete(It.IsAny<CartItem>()), Times.Once);
        }

        [Fact]
        public async Task ClearCart_ExceptionDuringSave_RollsBackAndRethrows()
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

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 2
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(new List<CartItem> { cartItem });

            _dbMockRepo.Setup(d => d.Delete(It.IsAny<CartItem>()));
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ThrowsAsync(new Exception("DB error"));

            var service = GetCartService();

            //Act & Assert
            await Assert.ThrowsAsync<Exception>(() => service.ClearCartAsync(false));
        }

        #endregion

        #region RemoveItemFromCartAsync

        [Fact]
        public async Task RemoveItemFromCart_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetCartService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.RemoveItemFromCartAsync(Guid.NewGuid()));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task RemoveItemFromCart_ProductNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

            var service = GetCartService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.RemoveItemFromCartAsync(Guid.NewGuid()));

            Assert.Equal(ProductNotFound, exception.Message);
        }

        [Fact]
        public async Task RemoveItemFromCart_ExceptionDuringSave_RollsBackAndRethrows()
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
                Price = 10.00m,
                Barcode = 1234567890L,
                Stock = 8
            };

            product.Id = productId;

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.All<CartItem>()).Returns(new List<CartItem> { cartItem }.AsQueryable());
            _dbMockRepo.Setup(d => d.Delete(It.IsAny<CartItem>()));
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ThrowsAsync(new Exception("DB error"));

            var service = GetCartService();

            //Act & Assert
            await Assert.ThrowsAsync<Exception>(() => service.RemoveItemFromCartAsync(productId));
        }

        [Fact]
        public async Task RemoveItemFromCart_RemovesItemAndRestoresStock()
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

            var cartItem = new CartItem
            {
                CustomerUserId = userId,
                ProductId = productId,
                Quantity = 4
            };

            var product = new Product
            {
                Name = "Product Name Here",
                Description = "A valid product description",
                ImageUrl = "http://img.test/product.jpg",
                Price = 10.00m,
                Barcode = 1234567890L,
                Stock = 6
            };

            product.Id = productId;

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsync<Product>(It.IsAny<Guid>())).ReturnsAsync(product);
            _dbMockRepo.Setup(d => d.All<CartItem>()).Returns(new List<CartItem> { cartItem }.AsQueryable());
            _dbMockRepo.Setup(d => d.Delete(It.IsAny<CartItem>()));
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetCartService();

            //Act
            await service.RemoveItemFromCartAsync(productId);

            //Assert
            Assert.Equal(10, product.Stock);
            _dbMockRepo.Verify(d => d.Delete(It.IsAny<CartItem>()), Times.Once);
        }

        #endregion
    }
}
