namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Tests.Common;
    using static Core.Common.Constants.Messages;

    public class ManufacturerServiceTests : BaseTest
    {
        private readonly AllBusinessLogics _allBls;

        public ManufacturerServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
        }

        private ManufacturerService GetManufacturerService()
        {
            return new ManufacturerService(_allBls);
        }

        #region GetAllManufacturersAsync

        [Fact]
        public async Task GetAllManufacturers_WithManufacturers_ReturnsExpectedResult()
        {
            //Arrange
            SetupManufacturersRepo();

            var service = GetManufacturerService();

            //Act
            var result = await service.GetAllManufacturersAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_manufacturers.Count, result.Count);
            Assert.All(result, vm =>
            {
                var match = _manufacturers.First(m => m.Id == vm.Id);
                Assert.Equal(match.Name, vm.Name);
                Assert.Equal(match.ImageUrl, vm.ImageUrl);
            });
        }

        [Fact]
        public async Task GetAllManufacturers_EmptyManufacturers_ThrowsInvalidOperationException()
        {
            //Arrange
            SetupManufacturersRepo(new List<Manufacturer>());

            var service = GetManufacturerService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetAllManufacturersAsync());

            Assert.Equal(ManufacturersNotFound, exception.Message);
        }

        #endregion
    }
}
