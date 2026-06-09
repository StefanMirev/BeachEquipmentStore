namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.User;
    using BeachEquipmentStore.Web.Areas.Admin.ControllerServices;
    using Moq;
    using static Core.Common.Constants.Messages;

    public class AdminUserControllerServiceTests : BaseTest
    {
        private readonly Mock<IUserService> _userService;

        public AdminUserControllerServiceTests()
        {
            _userService = _mockRepository.Create<IUserService>();
        }

        private UserControllerService GetService()
        {
            return new UserControllerService(_userService.Object);
        }

        #region GetAllNonAdminUsersAsync

        [Fact]
        public async Task GetAllNonAdminUsers_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _userService.Setup(u => u.GetAllNonAdminUsersAsync())
                .ThrowsAsync(new InvalidOperationException("Service error"));

            var service = GetService();

            //Act
            var result = await service.GetAllNonAdminUsersAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Service error", result.ResponseMessage);
        }

        [Fact]
        public async Task GetAllNonAdminUsers_Success_ReturnsUsers()
        {
            //Arrange
            var users = new List<UserViewModel>
            {
                new UserViewModel { Email = "user1@example.com" },
                new UserViewModel { Email = "user2@example.com" }
            };

            _userService.Setup(u => u.GetAllNonAdminUsersAsync()).ReturnsAsync(users);

            var service = GetService();

            //Act
            var result = await service.GetAllNonAdminUsersAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Users.Count);
        }

        #endregion

        #region MakeAdminAsync

        [Fact]
        public async Task MakeAdmin_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.MakeAdminAsync(userId))
                .ThrowsAsync(new InvalidOperationException("User not found"));

            var service = GetService();

            //Act
            var result = await service.MakeAdminAsync(userId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("User not found", result.ResponseMessage);
        }

        [Fact]
        public async Task MakeAdmin_ServiceReturnsFalse_ReturnsFailureResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.MakeAdminAsync(userId)).ReturnsAsync(false);

            var service = GetService();

            //Act
            var result = await service.MakeAdminAsync(userId);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserAdminGrantFailure, result.ResponseMessage);
        }

        [Fact]
        public async Task MakeAdmin_Success_ReturnsSuccessResponse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            _userService.Setup(u => u.MakeAdminAsync(userId)).ReturnsAsync(true);

            var service = GetService();

            //Act
            var result = await service.MakeAdminAsync(userId);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(UserAdminGrantSuccess, result.ResponseMessage);
        }

        #endregion
    }
}
