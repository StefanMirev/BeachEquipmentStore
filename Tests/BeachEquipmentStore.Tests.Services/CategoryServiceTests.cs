namespace BeachEquipmentStore.Tests.Services
{
    using BeachEquipmentStore.Services;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Tests.Common;
    using static Core.Common.Constants.Messages;

    public class CategoryServiceTests : BaseTest
    {
        private readonly AllBusinessLogics _allBls;

        public CategoryServiceTests()
        {
            _allBls = new AllBusinessLogics(_dbMockRepo.Object);
        }

        private CategoryService GetCategoryService()
        {
            return new CategoryService(_allBls);
        }

        #region GetAllCategoriesAsync

        [Fact]
        public async Task GetAllCategories_WithCategories_ReturnsExpectedResult()
        {
            //Arrange
            SetupCategoriesRepo();

            var service = GetCategoryService();

            //Act
            var result = await service.GetAllCategoriesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_categories.Count, result.Count);
            Assert.All(result, vm =>
            {
                var match = _categories.First(c => c.Id == vm.Id);
                Assert.Equal(match.Name, vm.Name);
                Assert.Equal(match.ImageUrl, vm.ImageUrl);
            });
        }

        [Fact]
        public async Task GetAllCategories_EmptyCategories_ThrowsInvalidOperationException()
        {
            //Arrange
            SetupCategoriesRepo(new List<Category>());

            var service = GetCategoryService();

            //Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetAllCategoriesAsync());

            Assert.Equal(CategoriesNotFound, exception.Message);
        }

        #endregion
    }
}
