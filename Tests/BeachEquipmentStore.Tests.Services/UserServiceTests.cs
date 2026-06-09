namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Profile;
    using Core.Utilities;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using System.Security.Claims;
    using static Core.Common.Constants.Messages;

    public class UserServiceTests : BaseTest
    {
        private static readonly string TestPassword = "ValidPass1!A";

        private readonly AllBusinessLogics _allBls;
        private readonly Mock<HttpContext> _httpContext;
        private readonly Mock<IAuthenticationService> _authenticationService;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IServiceProvider> _serviceProvider;

        public UserServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
            _httpContext = _mockRepository.Create<HttpContext>();
            _authenticationService = _mockRepository.Create<IAuthenticationService>();
            _httpContextAccessor = _mockRepository.Create<IHttpContextAccessor>();
            _serviceProvider = _mockRepository.Create<IServiceProvider>();
        }

        private UserService GetUserService()
        {
            return new UserService(_allBls, _httpContextAccessor.Object);
        }

        #region GetCurrentLoggedInUserId

        [Fact]
        public void GetCurrentLoggedInUserId_ValidClaim_ReturnsUserId()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            var service = GetUserService();

            //Act
            var result = service.GetCurrentLoggedInUserId();

            //Assert
            Assert.Equal(userId, result);
        }

        [Fact]
        public void GetCurrentLoggedInUserId_NullContext_ReturnsGuidEmpty()
        {
            //Arrange
            _httpContextAccessor.Setup(h => h.HttpContext).Returns((HttpContext?)null);

            var service = GetUserService();

            //Act
            var result = service.GetCurrentLoggedInUserId();

            //Assert
            Assert.Equal(Guid.Empty, result);
        }

        #endregion

        #region GetCurrentLoggedInUserAsync

        [Fact]
        public async Task GetCurrentLoggedInUser_NullContext_ReturnsNull()
        {
            //Arrange
            _httpContextAccessor.Setup(h => h.HttpContext).Returns((HttpContext?)null);

            var service = GetUserService();

            //Act
            var result = await service.GetCurrentLoggedInUserAsync();

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetCurrentLoggedInUser_AuthenticatedUser_ReturnsViewModel()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, "user@example.com"),
                new Claim(ClaimTypes.GivenName, "John"),
                new Claim(ClaimTypes.Surname, "Doe")
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            var service = GetUserService();

            //Act
            var result = await service.GetCurrentLoggedInUserAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("user@example.com", result.Email);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        #endregion

        #region IsUserSignedIn

        [Fact]
        public void IsUserSignedIn_AuthenticatedUser_ReturnsTrue()
        {
            //Arrange
            var principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>(), "Test"));

            var service = GetUserService();

            //Act
            var result = service.IsUserSignedIn(principal);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUserSignedIn_UnauthenticatedUser_ReturnsFalse()
        {
            //Arrange
            var principal = new ClaimsPrincipal(new ClaimsIdentity());

            var service = GetUserService();

            //Act
            var result = service.IsUserSignedIn(principal);

            //Assert
            Assert.False(result);
        }

        #endregion

        #region IsCurrentLoggedInUserAdmin

        [Fact]
        public void IsCurrentLoggedInUserAdmin_AdminUser_ReturnsTrue()
        {
            //Arrange
            var claims = new List<Claim>
            {
                new Claim("UserType", "Admin")
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            var service = GetUserService();

            //Act
            var result = service.IsCurrentLoggedInUserAdmin();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsCurrentLoggedInUserAdmin_CustomerUser_ReturnsFalse()
        {
            //Arrange
            var claims = new List<Claim>
            {
                new Claim("UserType", "Customer")
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            var service = GetUserService();

            //Act
            var result = service.IsCurrentLoggedInUserAdmin();

            //Assert
            Assert.False(result);
        }

        #endregion

        #region GetUserDetailsAsync

        [Fact]
        public async Task GetUserDetails_CustomerUserNotFound_ThrowsArgumentException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync((CustomerUser?)null);

            var service = GetUserService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.GetUserDetailsAsync(Guid.NewGuid()));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task GetUserDetails_UserNotFound_ThrowsArgumentException()
        {
            //Arrange
            var customerUser = new CustomerUser
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "0888000000"
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetUserService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.GetUserDetailsAsync(Guid.NewGuid()));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task GetUserDetails_ReturnsViewModel()
        {
            //Arrange
            var customerUser = new CustomerUser
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "0888000000"
            };

            var user = new User
            {
                Email = "john@example.com",
                Username = "john@example.com"
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            var service = GetUserService();

            //Act
            var result = await service.GetUserDetailsAsync(Guid.NewGuid());

            //Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("john@example.com", result.Email);
            Assert.Equal("0888000000", result.PhoneNumber);
        }

        #endregion

        #region ChangeUserDetailsAsync

        [Fact]
        public async Task ChangeUserDetails_CustomerUserNotFound_ThrowsArgumentException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync((CustomerUser?)null);

            var service = GetUserService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.ChangeUserDetailsAsync(new UserDetailsViewModel
                {
                    FirstName = "New",
                    LastName = "Name",
                    Email = "new@example.com",
                    PhoneNumber = "0999000000"
                }));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task ChangeUserDetails_UpdatesFieldsSuccessfully()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var customerUser = new CustomerUser
            {
                Id = userId,
                FirstName = "Old First",
                LastName = "Old Last",
                PhoneNumber = "0888000000"
            };

            var user = new User
            {
                Id = userId,
                Email = "old@example.com",
                Username = "old@example.com"
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.FindByIdAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetUserService();

            //Act
            await service.ChangeUserDetailsAsync(new UserDetailsViewModel
            {
                FirstName = "New First",
                LastName = "New Last",
                Email = "new@example.com",
                PhoneNumber = "0999999999"
            });

            //Assert
            Assert.Equal("New First", customerUser.FirstName);
            Assert.Equal("New Last", customerUser.LastName);
            Assert.Equal("new@example.com", user.Email);
            Assert.Equal("0999999999", customerUser.PhoneNumber);
        }

        #endregion

        #region ChangeUserPasswordAsync

        [Fact]
        public async Task ChangeUserPassword_WrongCurrentPassword_ReturnsFalse()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);

            _dbMockRepo.Setup(d => d.FindByIdAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            var service = GetUserService();

            //Act
            var result = await service.ChangeUserPasswordAsync("WrongPass1!A", "NewPass1!AB");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task ChangeUserPassword_CorrectPassword_ChangesPasswordAndSignsOut()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            _httpContext.Setup(h => h.User).Returns(principal);
            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);

            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);

            _authenticationService.Setup(a => a
                .SignOutAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<AuthenticationProperties?>()))
                .Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetUserService();

            //Act
            var result = await service.ChangeUserPasswordAsync(TestPassword, "NewPass1!AB");

            //Assert
            Assert.True(result);
            Assert.True(PasswordHasher.VerifyPassword("NewPass1!AB", user.PasswordHash));
        }

        #endregion

        #region GetAllNonAdminUsersAsync

        [Fact]
        public async Task GetAllNonAdminUsers_ReturnsJoinedList()
        {
            //Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            var customerUsers = new List<CustomerUser>
            {
                new CustomerUser
                {
                    Id = userId1,
                    FirstName = "John",
                    LastName = "Doe"
                },
                new CustomerUser
                {
                    Id = userId2,
                    FirstName = "Jane",
                    LastName = "Smith"
                }
            };

            var users = new List<User>
            {
                new User
                {
                    Id = userId1,
                    Email = "john@example.com",
                    Username = "john@example.com"
                },
                new User
                {
                    Id = userId2,
                    Email = "jane@example.com",
                    Username = "jane@example.com"
                }
            };

            _dbMockRepo.Setup(d => d.All<CustomerUser>()).Returns(customerUsers.AsQueryable());
            _dbMockRepo.Setup(d => d.All<User>()).Returns(users.AsQueryable());

            var service = GetUserService();

            //Act
            var result = await service.GetAllNonAdminUsersAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, vm => vm.Email == "john@example.com" && vm.FirstName == "John");
            Assert.Contains(result, vm => vm.Email == "jane@example.com" && vm.FirstName == "Jane");
        }

        #endregion
    }
}
