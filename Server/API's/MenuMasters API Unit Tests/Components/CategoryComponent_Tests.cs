using Bussiness.Components;
using Contract_Data_Bussiness.Interfaces;
using Models;
using Models.Enums;
using Moq;

namespace MenuMasters_API_Unit_Tests.Components
{
	public class CategoryComponent_Tests
	{
        private readonly CategoryComponent _categoryComponent;

        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public CategoryComponent_Tests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _categoryComponent = new CategoryComponent(
                _categoryRepositoryMock.Object
            );
        }

		[Fact]
		public async Task GetAllCategoriesAsync_Test()
		{
            // Arrange
            IEnumerable<Category> expectedCategories = new List<Category>()
            {
                new Category {
                    CategoryId = 1,
                    CategoryName = "Drinks",
                    Type = OrderType.Bar
                }
            };

            _categoryRepositoryMock
                .Setup(repo => repo.GetAllCategoriesAsync())
                .ReturnsAsync(expectedCategories);

            // Act
            IEnumerable<Category> result = await _categoryComponent.GetAllCategoriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCategories, result);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_Test()
        {
            // Arrange
            int inputCategoryId = 1;

            Category expectedCategory = new Category
            {
                CategoryId = 1,
                CategoryName = "Drinks",
                Type = OrderType.Bar
            };

            _categoryRepositoryMock
                .Setup(repo => repo.GetCategoryByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedCategory);

            // Act
            Category? result = await _categoryComponent.GetCategoryByIdAsync(inputCategoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCategory, result);
        }

        [Fact]
        public async Task CreateCategoryAsync_Test()
        {
            // Arrange
            Category expectedCategory = new Category
            {
                CategoryId = 1,
                CategoryName = "Drinks",
                Type = OrderType.Bar
            };

            Category inputCategory = new Category
            {
                CategoryName = "Drinks",
                Type = OrderType.Bar
            };

            _categoryRepositoryMock
                .Setup(repo => repo.CreateCategoryAsync(It.IsAny<Category>()))
                .ReturnsAsync(expectedCategory);

            // Act
            Category? result = await _categoryComponent.CreateCategoryAsync(inputCategory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCategory, result);
        }

        [Fact]
        public async Task UpdateCategoryAsync_Test()
        {
            // Arrange
            Category expectedCategory = new Category
            {
                CategoryId = 1,
                CategoryName = "Soft Drinks",
                Type = OrderType.Bar
            };

            Category inputCategory = new Category
            {
                CategoryId = 1,
                CategoryName = "Soft Drinks",
                Type = OrderType.Bar
            };

            _categoryRepositoryMock
                .Setup(repo => repo.UpdateCategoryAsync(It.IsAny<Category>()))
                .ReturnsAsync(expectedCategory);

            // Act
            Category? result = await _categoryComponent.UpdateCategoryAsync(inputCategory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCategory, result);
        }

        [Fact]
        public async Task DeleteCategoryAsync_Test()
        {
            // Arrange
            int inputCategoryId = 1;

            _categoryRepositoryMock
                .Setup(repo => repo.DeleteCategoryAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            bool result = await _categoryComponent.DeleteCategoryAsync(inputCategoryId);

            // Assert
            Assert.True(result);
        }
    }
}

