namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;

    public class ManufacturerControllerServiceTests : BaseTest
    {
        private readonly Mock<IManufacturerService> _manufacturerService;

        public ManufacturerControllerServiceTests()
        {
            _manufacturerService = _mockRepository.Create<IManufacturerService>();
        }

        private ManufacturerControllerService GetService()
        {
            return new ManufacturerControllerService(_manufacturerService.Object);
        }

        #region GetAllManufacturersAsync

        [Fact]
        public async Task GetAllManufacturers_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _manufacturerService.Setup(m => m.GetAllManufacturersAsync())
                .ThrowsAsync(new InvalidOperationException("Manufacturers unavailable"));

            var service = GetService();

            //Act
            var result = await service.GetAllManufacturersAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Manufacturers unavailable", result.ResponseMessage);
        }

        [Fact]
        public async Task GetAllManufacturers_Success_ReturnsManufacturers()
        {
            //Arrange
            var manufacturers = new List<ManufacturerViewModel>
            {
                new ManufacturerViewModel { Id = 1, Name = "Vinex" },
                new ManufacturerViewModel { Id = 2, Name = "INTEX" }
            };

            _manufacturerService.Setup(m => m.GetAllManufacturersAsync()).ReturnsAsync(manufacturers);

            var service = GetService();

            //Act
            var result = await service.GetAllManufacturersAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Manufacturers.Count);
        }

        #endregion
    }
}
