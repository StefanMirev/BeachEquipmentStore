namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class CustomerUserControllerServiceTests : BaseTest
    {
        private readonly Mock<IAddressService> _addressService;
        private readonly Mock<IOrderService> _orderService;
        private readonly Mock<IUserService> _userService;

        public CustomerUserControllerServiceTests()
        {
            _addressService = _mockRepository.Create<IAddressService>();
            _orderService = _mockRepository.Create<IOrderService>();
            _userService = _mockRepository.Create<IUserService>();
        }

        private UserControllerService GetService()
        {
            return new UserControllerService(_addressService.Object, _orderService.Object, _userService.Object);
        }

        #region GetUserDetailsAsync

        [Fact]
        public async Task GetUserDetails_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _userService.Setup(u => u.GetUserDetailsAsync(userId))
                .ThrowsAsync(new InvalidOperationException("User not found"));

            var service = GetService();

            //Act
            var result = await service.GetUserDetailsAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("User not found", result.ResponseMessage);
        }

        [Fact]
        public async Task GetUserDetails_Success_ReturnsUserDetails()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var userDetails = new UserDetailsViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                PhoneNumber = "0888000000"
            };

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _userService.Setup(u => u.GetUserDetailsAsync(userId)).ReturnsAsync(userDetails);

            var service = GetService();

            //Act
            var result = await service.GetUserDetailsAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(userDetails, result.UserDetails);
        }

        #endregion

        #region ChangeUserDetailsAsync

        [Fact]
        public async Task ChangeUserDetails_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var userDetails = new UserDetailsViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                PhoneNumber = "0888000000"
            };

            _userService.Setup(u => u.ChangeUserDetailsAsync(userDetails))
                .ThrowsAsync(new InvalidOperationException("Update failed"));

            var service = GetService();

            //Act
            var result = await service.ChangeUserDetailsAsync(userDetails);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Update failed", result.ResponseMessage);
        }

        [Fact]
        public async Task ChangeUserDetails_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var userDetails = new UserDetailsViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                PhoneNumber = "0888000000"
            };

            _userService.Setup(u => u.ChangeUserDetailsAsync(userDetails)).Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.ChangeUserDetailsAsync(userDetails);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(UserDetailsUpdateSuccess, result.ResponseMessage);
        }

        #endregion

        #region ChangeUserPasswordAsync

        [Fact]
        public async Task ChangeUserPassword_UserIdIsEmpty_ReturnsFailureWithUserNotFound()
        {
            //Arrange
            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(Guid.Empty);

            var model = new ChangePasswordViewModel
            {
                CurrentPassword = "OldPassword1!",
                NewPassword = "NewPassword1!",
                ConfirmPassword = "NewPassword1!"
            };

            var service = GetService();

            //Act
            var result = await service.ChangeUserPasswordAsync(model);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.False(result.UserFound);
        }

        [Fact]
        public async Task ChangeUserPassword_IncorrectCurrentPassword_ReturnsFailureWithUserFound()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _userService.Setup(u => u.ChangeUserPasswordAsync("WrongPass1!", "NewPass1!")).ReturnsAsync(false);

            var model = new ChangePasswordViewModel
            {
                CurrentPassword = "WrongPass1!",
                NewPassword = "NewPass1!",
                ConfirmPassword = "NewPass1!"
            };

            var service = GetService();

            //Act
            var result = await service.ChangeUserPasswordAsync(model);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.True(result.UserFound);
        }

        [Fact]
        public async Task ChangeUserPassword_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _userService.Setup(u => u.ChangeUserPasswordAsync("OldPassword1!", "NewPassword1!")).ReturnsAsync(true);

            var model = new ChangePasswordViewModel
            {
                CurrentPassword = "OldPassword1!",
                NewPassword = "NewPassword1!",
                ConfirmPassword = "NewPassword1!"
            };

            var service = GetService();

            //Act
            var result = await service.ChangeUserPasswordAsync(model);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.True(result.UserFound);
            Assert.Equal(UserPasswordChangeSuccess, result.ResponseMessage);
        }

        #endregion

        #region GetAllUserAddressesAsync

        [Fact]
        public async Task GetAllUserAddresses_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _addressService.Setup(a => a.GetAllAddressesByUserIdAsync(userId))
                .ThrowsAsync(new InvalidOperationException("No addresses found"));

            var service = GetService();

            //Act
            var result = await service.GetAllUserAddressesAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("No addresses found", result.ResponseMessage);
        }

        [Fact]
        public async Task GetAllUserAddresses_Success_ReturnsAddresses()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var addresses = new List<AddressDetailsViewModel>
            {
                new AddressDetailsViewModel { Name = "Main Street 123", Town = "Sofia", ZipCode = "1000" },
                new AddressDetailsViewModel { Name = "Second Street 45", Town = "Plovdiv", ZipCode = "4000" }
            };

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _addressService.Setup(a => a.GetAllAddressesByUserIdAsync(userId)).ReturnsAsync(addresses);

            var service = GetService();

            //Act
            var result = await service.GetAllUserAddressesAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Addresses.Count);
        }

        #endregion

        #region AddUserAddressAsync

        [Fact]
        public async Task AddUserAddress_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _addressService.Setup(a => a.AddAddressAsync(userId, "Main Street 1", "Sofia", "INVALID", false))
                .ThrowsAsync(new ArgumentException("Invalid zip code"));

            var service = GetService();

            //Act
            var result = await service.AddUserAddressAsync("Main Street 1", "Sofia", "INVALID", false);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Invalid zip code", result.ResponseMessage);
        }

        [Fact]
        public async Task AddUserAddress_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _addressService.Setup(a => a.AddAddressAsync(userId, "Main Street 123", "Sofia", "1000", false))
                .Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.AddUserAddressAsync("Main Street 123", "Sofia", "1000", false);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(AddressAddSuccess, result.ResponseMessage);
        }

        #endregion

        #region GetUserAddressDetailsAsync

        [Fact]
        public async Task GetUserAddressDetails_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var addressId = Guid.NewGuid();

            _addressService.Setup(a => a.GetAddressDetailsByIdAsync(addressId))
                .ThrowsAsync(new InvalidOperationException("Address not found"));

            var service = GetService();

            //Act
            var result = await service.GetUserAddressDetailsAsync(addressId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Address not found", result.ResponseMessage);
        }

        [Fact]
        public async Task GetUserAddressDetails_Success_ReturnsAddress()
        {
            //Arrange
            var addressId = Guid.NewGuid();

            var address = new AddressDetailsViewModel
            {
                Id = addressId,
                Name = "Main Street 123",
                Town = "Sofia",
                ZipCode = "1000"
            };

            _addressService.Setup(a => a.GetAddressDetailsByIdAsync(addressId)).ReturnsAsync(address);

            var service = GetService();

            //Act
            var result = await service.GetUserAddressDetailsAsync(addressId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(address, result.Address);
        }

        #endregion

        #region ChangeUserAddressDetailsAsync

        [Fact]
        public async Task ChangeUserAddressDetails_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var addressId = Guid.NewGuid();

            _addressService.Setup(a => a.UpdateAddressByIdAsync(addressId, "New Street 1", "Sofia", "1000"))
                .ThrowsAsync(new InvalidOperationException("Address not found"));

            var service = GetService();

            //Act
            var result = await service.ChangeUserAddressDetailsAsync(addressId, "New Street 1", "Sofia", "1000");

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Address not found", result.ResponseMessage);
        }

        [Fact]
        public async Task ChangeUserAddressDetails_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var addressId = Guid.NewGuid();

            _addressService.Setup(a => a.UpdateAddressByIdAsync(addressId, "New Street 123", "Plovdiv", "4000"))
                .Returns(Task.CompletedTask);

            var service = GetService();

            //Act
            var result = await service.ChangeUserAddressDetailsAsync(addressId, "New Street 123", "Plovdiv", "4000");

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(AddressUpdateSuccess, result.ResponseMessage);
        }

        #endregion

        #region DeleteUserAddressAsync

        [Fact]
        public async Task DeleteUserAddress_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var addressId = Guid.NewGuid();

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _addressService.Setup(a => a.DeleteAddressByIdAsync(userId, addressId))
                .ThrowsAsync(new ArgumentException("Address not found"));

            var service = GetService();

            //Act
            var result = await service.DeleteUserAddressAsync(addressId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Address not found", result.ResponseMessage);
        }

        [Fact]
        public async Task DeleteUserAddress_Success_ReturnsRemainingCount()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var addressId = Guid.NewGuid();

            var remaining = new List<AddressDetailsViewModel>
            {
                new AddressDetailsViewModel { Name = "Remaining Street 1", Town = "Sofia", ZipCode = "1000" }
            };

            _userService.Setup(u => u.GetCurrentLoggedInUserId()).Returns(userId);
            _addressService.Setup(a => a.DeleteAddressByIdAsync(userId, addressId)).ReturnsAsync(remaining);

            var service = GetService();

            //Act
            var result = await service.DeleteUserAddressAsync(addressId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.RemainingCount);
        }

        #endregion

        #region GetUserOrderHistoryAsync

        [Fact]
        public async Task GetUserOrderHistory_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _orderService.Setup(o => o.GetCurrentUserOrderHistoryAsync())
                .ThrowsAsync(new ArgumentNullException("user", "User not found"));

            var service = GetService();

            //Act
            var result = await service.GetUserOrderHistoryAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ResponseMessage);
        }

        [Fact]
        public async Task GetUserOrderHistory_Success_ReturnsOrders()
        {
            //Arrange
            var orders = new List<OrderHistoryViewModel>
            {
                new OrderHistoryViewModel { TotalPrice = 50.00m },
                new OrderHistoryViewModel { TotalPrice = 30.00m }
            };

            _orderService.Setup(o => o.GetCurrentUserOrderHistoryAsync()).ReturnsAsync(orders);

            var service = GetService();

            //Act
            var result = await service.GetUserOrderHistoryAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Orders.Count);
        }

        #endregion
    }
}
