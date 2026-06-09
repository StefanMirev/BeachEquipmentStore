namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Tests.Common;
    using Moq;
    using System.Linq.Expressions;
    using static Core.Common.Constants.Messages;

    public class AddressServiceTests : BaseTest
    {
        private readonly AllBusinessLogics _allBls;

        public AddressServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
        }

        private AddressService GetAddressService()
        {
            return new AddressService(_allBls);
        }

        #region GetAllAddressesByUserIdAsync

        [Fact]
        public async Task GetAllAddressesByUserId_UserNotFound_ThrowsArgumentException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.GetAllAddressesByUserIdAsync(Guid.NewGuid()));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task GetAllAddressesByUserId_NoAddresses_ThrowsInvalidOperationException()
        {
            //Arrange
            var user = new User
            {
                Email = "user@example.com",
                Username = "user@example.com"
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(new List<Address>());

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetAllAddressesByUserIdAsync(user.Id));

            Assert.Equal(AddressNotFound, exception.Message);
        }

        [Fact]
        public async Task GetAllAddressesByUserId_ReturnsOrderedAddresses()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var primaryAddress = new Address
            {
                Name = "Primary Street 123",
                Town = "Sofia",
                ZipCode = "1000",
                IsPrimaryAddress = true,
                CustomerUserId = userId
            };

            var secondaryAddress = new Address
            {
                Name = "Secondary Street 45",
                Town = "Plovdiv",
                ZipCode = "4000",
                IsPrimaryAddress = false,
                CustomerUserId = userId
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            SearchForDbMockRepoHelper(new List<Address> { primaryAddress, secondaryAddress });

            var service = GetAddressService();

            //Act
            var result = await service.GetAllAddressesByUserIdAsync(userId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.True(result[0].IsPrimaryAddress);
        }

        #endregion

        #region GetAddressDetailsByIdAsync

        [Fact]
        public async Task GetAddressDetailsById_NotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Address>(It.IsAny<Guid>())).ReturnsAsync((Address?)null);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetAddressDetailsByIdAsync(Guid.NewGuid()));

            Assert.Equal(AddressNotFound, exception.Message);
        }

        [Fact]
        public async Task GetAddressDetailsById_ReturnsViewModel()
        {
            //Arrange
            var address = new Address
            {
                Name = "Main Street 123",
                Town = "Sofia",
                ZipCode = "1000",
                IsPrimaryAddress = true,
                CustomerUserId = Guid.NewGuid()
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<Address>(It.IsAny<Guid>())).ReturnsAsync(address);

            var service = GetAddressService();

            //Act
            var result = await service.GetAddressDetailsByIdAsync(address.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(address.Id, result.Id);
            Assert.Equal(address.Name, result.Name);
            Assert.Equal(address.Town, result.Town);
            Assert.Equal(address.ZipCode, result.ZipCode);
            Assert.Equal(address.IsPrimaryAddress, result.IsPrimaryAddress);
        }

        #endregion

        #region AddAddressAsync

        [Fact]
        public async Task AddAddress_UserNotFound_ThrowsArgumentException()
        {
            //Arrange
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAddressAsync(Guid.NewGuid(), "Main Street 1", "Sofia", "1000"));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task AddAddress_AddressLimitReached_ThrowsInvalidOperationException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var addresses = Enumerable.Range(0, 10)
                .Select(_ => new Address
                {
                    Name = "Some Street Long",
                    Town = "Sofia",
                    ZipCode = "1000",
                    CustomerUserId = userId
                })
                .ToList();

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<Address>()).Returns(addresses.AsQueryable());

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.AddAddressAsync(userId, "New Street 1", "Sofia", "1000"));

            Assert.Equal(AddressLimitReached, exception.Message);
        }

        [Fact]
        public async Task AddAddress_InvalidZipCode_ThrowsArgumentException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<Address>()).Returns(new List<Address>().AsQueryable());

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAddressAsync(userId, "Main Street 1", "Sofia", "INVALID"));

            Assert.Equal(AddressZipCodeInvalid, exception.Message);
        }

        [Fact]
        public async Task AddAddress_NotPrimary_AddsSuccessfully()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<Address>()).Returns(new List<Address>().AsQueryable());

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<Address>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetAddressService();

            //Act
            await service.AddAddressAsync(userId, "Main Street 123", "Sofia", "1000", false);

            //Assert
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<Address>()), Times.Once);
            _dbMockRepo.Verify(d => d.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task AddAddress_IsPrimary_UpdatesExistingPrimaryAndAdds()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var existingPrimary = new Address
            {
                Name = "Old Primary Street",
                Town = "Sofia",
                ZipCode = "1000",
                IsPrimaryAddress = true,
                CustomerUserId = userId
            };

            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.All<Address>()).Returns(new List<Address>().AsQueryable());

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FirstOrDefaultAsync(It.IsAny<Expression<Func<Address, bool>>>()))
                .ReturnsAsync(existingPrimary);
            _dbMockRepo.Setup(d => d.AddAsync(It.IsAny<Address>())).Returns(Task.CompletedTask);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetAddressService();

            //Act
            await service.AddAddressAsync(userId, "New Primary Street", "Plovdiv", "4000", true);

            //Assert
            Assert.False(existingPrimary.IsPrimaryAddress);
            _dbMockRepo.Verify(d => d.AddAsync(It.IsAny<Address>()), Times.Once);
        }

        #endregion

        #region UpdateAddressByIdAsync

        [Fact]
        public async Task UpdateAddressById_NotFound_ThrowsInvalidOperationException()
        {
            //Arrange
            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Address>(It.IsAny<Guid>())).ReturnsAsync((Address?)null);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.UpdateAddressByIdAsync(Guid.NewGuid(), "New Name Street", "Sofia", "1000"));

            Assert.Equal(AddressNotFound, exception.Message);
        }

        [Fact]
        public async Task UpdateAddressById_UpdatesFields()
        {
            //Arrange
            var address = new Address
            {
                Name = "Old Street Name Long",
                Town = "Old Town",
                ZipCode = "1111",
                CustomerUserId = Guid.NewGuid()
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Address>(It.IsAny<Guid>())).ReturnsAsync(address);
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            var service = GetAddressService();

            //Act
            await service.UpdateAddressByIdAsync(address.Id, "New Street Name Long", "New Town", "2222");

            //Assert
            Assert.Equal("New Street Name Long", address.Name);
            Assert.Equal("New Town", address.Town);
            Assert.Equal("2222", address.ZipCode);
        }

        #endregion

        #region DeleteAddressByIdAsync

        [Fact]
        public async Task DeleteAddressById_AddressNotFound_ThrowsArgumentException()
        {
            //Arrange
            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Address>(It.IsAny<Guid>())).ReturnsAsync((Address?)null);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.DeleteAddressByIdAsync(Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal(AddressNotFound, exception.Message);
        }

        [Fact]
        public async Task DeleteAddressById_UserNotFound_ThrowsArgumentException()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var address = new Address
            {
                Name = "Some Street Long",
                Town = "Sofia",
                ZipCode = "1000",
                CustomerUserId = userId
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Address>(It.IsAny<Guid>())).ReturnsAsync(address);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync((User?)null);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.DeleteAddressByIdAsync(userId, address.Id));

            Assert.Equal(UserNotFound, exception.Message);
        }

        [Fact]
        public async Task DeleteAddressById_AddressNotBelongingToUser_ThrowsArgumentException()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var differentUserId = Guid.NewGuid();

            var address = new Address
            {
                Name = "Some Street Long",
                Town = "Sofia",
                ZipCode = "1000",
                CustomerUserId = differentUserId
            };

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.RollbackAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Address>(It.IsAny<Guid>())).ReturnsAsync(address);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);

            var service = GetAddressService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.DeleteAddressByIdAsync(userId, address.Id));

            Assert.Equal(AddressNotFound, exception.Message);
        }

        [Fact]
        public async Task DeleteAddressById_DeletesAndReturnsRemainingAddresses()
        {
            //Arrange
            var userId = Guid.NewGuid();

            var addressToDelete = new Address
            {
                Name = "Address To Delete",
                Town = "Sofia",
                ZipCode = "1000",
                IsPrimaryAddress = false,
                CustomerUserId = userId
            };

            var remainingAddress = new Address
            {
                Name = "Remaining Street Long",
                Town = "Plovdiv",
                ZipCode = "4000",
                IsPrimaryAddress = true,
                CustomerUserId = userId
            };

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                Username = "user@example.com"
            };

            var transactionProxy = GetDbContextTransactionProxy();
            transactionProxy.Setup(t => t.CommitAsync()).Returns(Task.CompletedTask);

            _dbMockRepo.Setup(d => d.FindByIdAsync<Address>(It.IsAny<Guid>())).ReturnsAsync(addressToDelete);
            _dbMockRepo.Setup(d => d.FindByIdAsNoTrackingAsync<User>(It.IsAny<Guid>())).ReturnsAsync(user);
            _dbMockRepo.Setup(d => d.Delete(It.IsAny<Address>()));
            _dbMockRepo.Setup(d => d.SaveChangesAsync()).ReturnsAsync(1);

            SearchForDbMockRepoHelper(new List<Address> { remainingAddress });

            var service = GetAddressService();

            //Act
            var result = await service.DeleteAddressByIdAsync(userId, addressToDelete.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
            _dbMockRepo.Verify(d => d.Delete(It.IsAny<Address>()), Times.Once);
            _dbMockRepo.Verify(d => d.SaveChangesAsync(), Times.Once);
        }

        #endregion
    }
}
