namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Tests.Common;
    using Core.Enums;
    using Core.Utilities;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using static Core.Common.Constants.Messages;

    public class AuthServiceTests : BaseTest
    {
        private static readonly string TestPassword = "ValidPass1!A";

        private readonly AllBusinessLogics _allBls;
        private readonly Mock<HttpContext> _httpContext;
        private readonly Mock<IAuthenticationService> _authenticationService;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IServiceProvider> _serviceProvider;

        public AuthServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
            _httpContext = _mockRepository.Create<HttpContext>();
            _authenticationService = _mockRepository.Create<IAuthenticationService>();
            _httpContextAccessor = _mockRepository.Create<IHttpContextAccessor>();
            _serviceProvider = _mockRepository.Create<IServiceProvider>();
        }

        private AuthService GetAuthService()
        {
            return new AuthService(_allBls, _httpContextAccessor.Object);
        }

        #region LoginAsync

        [Fact]
        public async Task Login_UnknownEmail_ReturnsFalse()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync((User?)null);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync("unknown@example.com", TestPassword, false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Login_AdminUserInactive_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@example.com",
                Username = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var inactiveAdminUser = new AdminUser
            {
                Id = user.Id,
                IsActive = false
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync(inactiveAdminUser);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, TestPassword, false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Login_AdminUserWrongPassword_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@example.com",
                Username = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var adminUser = new AdminUser
            {
                Id = user.Id,
                FirstName = "Admin",
                LastName = "Test",
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync(adminUser);
            
            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, "WrongPassword1!", false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Login_AdminUserValidCredentials_ReturnsTrue()
        {
            //Arrange
            var adminRoleId = Guid.NewGuid();

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@example.com",
                Username = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var adminUser = new AdminUser
            {
                Id = user.Id,
                FirstName = "Admin",
                LastName = "Test",
                IsActive = true,
                UserRoleId = adminRoleId
            };

            var adminRole = new UserRole
            { 
                Id = adminRoleId,
                Name = "Administrator",
                RoleType = UserType.Admin,
                CanRead = true, CanWrite = true,
                CanDelete = true, IsActive = true
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync(adminUser);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<UserRole>(It.IsAny<Guid>())).ReturnsAsync(adminRole);

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);

            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);

            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);

            _authenticationService.Setup(a => a
                .SignInAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            
            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, TestPassword, false);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Login_CustomerUserInactive_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var inactiveCustomerUser = new CustomerUser
            {
                Id = user.Id,
                IsActive = false
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(inactiveCustomerUser);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, TestPassword, false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Login_CustomerUserLockedOut_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var lockedCustomerUser = new CustomerUser
            {
                Id = user.Id,
                IsActive = true,
                LockoutEnabled = true,
                LockoutEnd = DateTimeOffset.Now.AddMinutes(10)
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(lockedCustomerUser);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, TestPassword, false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Login_CustomerUserWrongPassword_LockoutDisabled_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                IsActive = true,
                LockoutEnabled = false
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            
            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, "WrongPassword1!", false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Login_CustomerUserWrongPassword_LockoutEnabled_IncrementsFailedCount_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                IsActive = true,
                LockoutEnabled = true,
                AccessFailedCount = 2
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, "WrongPassword1!", false);

            //Assert
            Assert.False(result);
            Assert.Equal(3, customerUser.AccessFailedCount);
            Assert.Null(customerUser.LockoutEnd);
        }

        [Fact]
        public async Task Login_CustomerUserWrongPassword_FifthFailure_LocksAccount_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                IsActive = true,
                LockoutEnabled = true,
                AccessFailedCount = 4 
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, "WrongPassword1!", false);

            //Assert
            Assert.False(result);
            Assert.Equal(5, customerUser.AccessFailedCount);
            Assert.NotNull(customerUser.LockoutEnd);
            Assert.True(customerUser.LockoutEnd > DateTimeOffset.Now);
        }

        [Fact]
        public async Task Login_CustomerUserValidCredentials_ReturnsTrue()
        {
            //Arrange
            var customerRoleId = Guid.NewGuid();

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                FirstName = "Customer",
                LastName = "Test",
                IsActive = true,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                UserRoleId = customerRoleId
            };

            var customerRole = new UserRole
            {
                Id = customerRoleId,
                Name = "Customer",
                RoleType = UserType.Customer,
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<UserRole>(It.IsAny<Guid>())).ReturnsAsync(customerRole);

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);

            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);

            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);

            _authenticationService.Setup(a => a
                .SignInAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, TestPassword, false);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Login_CustomerUserValidCredentials_WithPreviousFailures_ResetsCountAndReturnsTrue()
        {
            //Arrange
            var customerRoleId = Guid.NewGuid();

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "customer@example.com",
                Username = "customer@example.com",
                PasswordHash = PasswordHasher.HashPassword(TestPassword)
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                FirstName = "Customer",
                LastName = "Test",
                IsActive = true,
                LockoutEnabled = true,
                AccessFailedCount = 3,
                UserRoleId = customerRoleId
            };

            var customerRole = new UserRole
            {
                Id = customerRoleId,
                Name = "Customer",
                RoleType = UserType.Customer,
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<AdminUser>(It.IsAny<Guid>())).ReturnsAsync((AdminUser?)null);
            _dbMockRepo.Setup(d => d.FindByIdAsync<CustomerUser>(It.IsAny<Guid>())).ReturnsAsync(customerUser);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<UserRole>(It.IsAny<Guid>())).ReturnsAsync(customerRole);

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);

            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);

            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);

            _authenticationService.Setup(a => a
                .SignInAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);

            var service = GetAuthService();

            //Act
            var result = await service.LoginAsync(user.Email, TestPassword, false);

            //Assert
            Assert.True(result);
            Assert.Equal(0, customerUser.AccessFailedCount);
            Assert.Null(customerUser.LockoutEnd);
        }

        #endregion

        #region RegisterAsync

        [Fact]
        public async Task Register_WeakPassword_ThrowsArgumentException()
        {
            //Arrange
            var service = GetAuthService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.RegisterAsync("First", "Last", "new@example.com", "0888000000", "weak"));

            Assert.Equal(PasswordInvalid, exception.Message);
        }

        [Fact]
        public async Task Register_EmailAlreadyTaken_ThrowsInvalidOperationException()
        {
            //Arrange
            var existingUser = new User
            {
                Id = Guid.NewGuid(),
                Email = "taken@example.com",
                Username = "taken@example.com"
            };

            _dbMockRepo.Setup(d => d.All<User>()).Returns(new List<User> { existingUser }.AsQueryable());

            var service = GetAuthService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.RegisterAsync("First", "Last", existingUser.Email, "0888000000", TestPassword));

            Assert.Equal(UserEmailAlreadyExists, exception.Message);
        }

        [Fact]
        public async Task Register_WithExistingCustomerRole_RegistersAndSignsIn()
        {
            //Arrange
            var customerRole = new UserRole
            {
                Id = Guid.NewGuid(),
                Name = "Customer",
                RoleType = UserType.Customer,
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.All<User>()).Returns((new List<User>().AsQueryable()));
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserRole, bool>>>())).ReturnsAsync(customerRole);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<CustomerUser>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);

            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);

            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);

            _authenticationService.Setup(a => a
                .SignInAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            
            var service = GetAuthService();

            //Act
            await service.RegisterAsync("First", "Last", "new@example.com", "0888000000", TestPassword);

            //Assert
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<User>()), Times.Once);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<CustomerUser>()), Times.Once);
        }

        [Fact]
        public async Task Register_WithNoExistingCustomerRole_CreatesRoleAndRegisters()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.All<User>()).Returns((new List<User>().AsQueryable()));
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserRole, bool>>>())).ReturnsAsync((UserRole?)null);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<UserRole>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<CustomerUser>())).Returns(Task.CompletedTask);

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);
            
            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);
            
            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);
            
            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);
            
            _authenticationService.Setup(a => a
                .SignInAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            
            var service = GetAuthService();

            //Act
            await service.RegisterAsync("First", "Last", "new@example.com", "0888000000", TestPassword);

            //Assert
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<UserRole>()), Times.Once);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<User>()), Times.Once);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<CustomerUser>()), Times.Once);
        }

        #endregion

        #region CreateAdminUserAsync

        [Fact]
        public async Task CreateAdminUser_UserNotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetAuthService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateAdminUserAsync(Guid.NewGuid(), "First", "Last"));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task CreateAdminUser_UserAlreadyCustomer_ThrowsInvalidOperationException()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                Username ="user@example.com"
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                FirstName = "Customer",
                LastName = "Test",
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<CustomerUser>()).Returns(new List<CustomerUser> { customerUser }.AsQueryable());

            var service = GetAuthService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateAdminUserAsync(user.Id, "First", "Last"));

            Assert.Equal(UserAlreadyCustomer, exception.Message);
        }

        [Fact]
        public async Task CreateAdminUser_UserAlreadyAdmin_ThrowsInvalidOperationException()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var adminUser = new AdminUser
            {
                Id = user.Id,
                FirstName = "Admin",
                LastName = "Test",
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<CustomerUser>()).Returns(new List<CustomerUser>().AsQueryable());
            _dbMockRepo.Setup(d => d.All<AdminUser>()).Returns(new List<AdminUser> { adminUser }.AsQueryable());

            var service = GetAuthService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateAdminUserAsync(user.Id, "First", "Last"));

            Assert.Equal(UserAlreadyAdmin, exception.Message);
        }

        [Fact]
        public async Task CreateAdminUser_WithExistingAdminRole_CreatesAdminSuccessfully()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                Username = "user@example.com"
            };
            
            var adminRole = new UserRole 
            {
                Id = Guid.NewGuid(),
                Name = "Administrator",
                RoleType = UserType.Admin,
                CanRead = true,
                CanWrite = true,
                CanDelete = true,
                IsActive = true
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<CustomerUser>()).Returns(new List<CustomerUser>().AsQueryable());
            _dbMockRepo.Setup(d => d.All<AdminUser>()).Returns(new List<AdminUser>().AsQueryable());
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserRole, bool>>>())).ReturnsAsync(adminRole);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<AdminUser>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);
            
            var service = GetAuthService();

            //Act
            await service.CreateAdminUserAsync(user.Id, "Admin", "User");

            //Assert
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<AdminUser>()), Times.Once);
            _dbMockRepo.Verify(d => d.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateAdminUser_WithNoExistingAdminRole_CreatesRoleAndAdmin()
        {
            //Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                Username = "user@example.com"
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<CustomerUser>()).Returns(new List<CustomerUser>().AsQueryable());
            _dbMockRepo.Setup(d => d.All<AdminUser>()).Returns(new List<AdminUser>().AsQueryable());
            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserRole, bool>>>())).ReturnsAsync((UserRole?)null);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<UserRole>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<AdminUser>())).Returns(Task.CompletedTask);

            var service = GetAuthService();

            //Act
            await service.CreateAdminUserAsync(user.Id, "Admin", "User");

            //Assert
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<UserRole>()), Times.Once);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<AdminUser>()), Times.Once);
        }

        #endregion

        #region LogoutAsync

        [Fact]
        public async Task Logout_NoHttpContext_ThrowsInvalidOperationException()
        {
            //Arrange
            _httpContextAccessor.Setup(h => h.HttpContext).Returns((HttpContext?)null);

            var service = GetAuthService();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.LogoutAsync());
        }

        [Fact]
        public async Task Logout_ValidContext_SignsOut()
        {
            //Arrange
            _httpContextAccessor.Setup(h => h.HttpContext).Returns(_httpContext.Object);

            _httpContext.Setup(h => h.RequestServices).Returns(_serviceProvider.Object);

            _serviceProvider.Setup(s => s.GetService(typeof(IAuthenticationService))).Returns(_authenticationService.Object);

            _authenticationService.Setup(a => a
                .SignOutAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<AuthenticationProperties?>()))
                .Returns(Task.CompletedTask);

            var service = GetAuthService();

            //Act
            await service.LogoutAsync();

            //Assert
            _authenticationService.Verify(a => a.SignOutAsync(_httpContext.Object, CookieAuthenticationDefaults.AuthenticationScheme, It.IsAny<AuthenticationProperties?>()), Times.Once);
        }

        #endregion
    }
}
