namespace BeachEquipmentStore.Tests
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Tests.Common;
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices;
    using Moq;

    public class CategoryControllerServiceTests : BaseTest
    {
        private readonly Mock<ICategoryService> _categoryService;

        public CategoryControllerServiceTests()
        {
            _categoryService = _mockRepository.Create<ICategoryService>();
        }

        private CategoryControllerService GetService()
        {
            return new CategoryControllerService(_categoryService.Object);
        }

        #region GetAllCategoriesAsync

        [Fact]
        public async Task GetAllCategories_ServiceThrows_ReturnsFailureResponse()
        {
            //Arrange
            _categoryService.Setup(c => c.GetAllCategoriesAsync())
                .ThrowsAsync(new InvalidOperationException("Categories unavailable"));

            var service = GetService();

            //Act
            var result = await service.GetAllCategoriesAsync();

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Categories unavailable", result.ResponseMessage);
        }

        [Fact]
        public async Task GetAllCategories_Success_ReturnsCategories()
        {
            //Arrange
            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Плажни кърпи" },
                new CategoryViewModel { Id = 2, Name = "Чадъри" },
                new CategoryViewModel { Id = 3, Name = "Надуваеми" }
            };

            _categoryService.Setup(c => c.GetAllCategoriesAsync()).ReturnsAsync(categories);

            var service = GetService();

            //Act
            var result = await service.GetAllCategoriesAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(3, result.Categories.Count);
        }

        #endregion
    }
}
