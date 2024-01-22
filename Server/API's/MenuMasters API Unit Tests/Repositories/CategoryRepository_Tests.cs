using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Repositories;
using Models;
using Models.Enums;

namespace MenuMasters_API_Unit_Tests.Repositories
{
    public class CategoryRepository_Tests
    {
        private readonly DbContextOptions<MenuMastersDbContext> _options;

        public CategoryRepository_Tests()
        {
            _options = new DbContextOptionsBuilder<MenuMastersDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase_{new Random().Next(int.MinValue, int.MaxValue)}")
                .Options;
        }

        [Fact]
        public async Task GetAllCategoriesAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);
                dbContext.Categories.Add(new Category { CategoryName = "Soft Drinks", Type = OrderType.Bar });
                dbContext.Categories.Add(new Category { CategoryName = "Burgers", Type = OrderType.Kitchen });
                dbContext.SaveChanges();

                // Act
                IEnumerable<Category> result = await categoryRepository.GetAllCategoriesAsync();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
                Assert.Contains(result, x => x.CategoryName == "Soft Drinks");
                Assert.Contains(result, x => x.CategoryName == "Burgers");
            }
        }

        [Fact]
        public async Task GetCategoryByIdAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);
                dbContext.Categories.Add(new Category { CategoryName = "Soft Drinks", Type = OrderType.Bar });
                dbContext.SaveChanges();

                // Act
                Category? result = await categoryRepository.GetCategoryByIdAsync(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Soft Drinks", result.CategoryName);
                Assert.Equal(OrderType.Bar, result.Type);
            }
        }

        [Fact]
        public async Task CreateCategoryAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);
                Category newCategory = new Category { CategoryName = "Soft Drinks", Type = OrderType.Bar };

                // Act
                Category? result = await categoryRepository.CreateCategoryAsync(newCategory);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Soft Drinks", result.CategoryName);
                Assert.Equal(OrderType.Bar, result.Type);
            }
        }

        [Fact]
        public async Task UpdateCategoryAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);
                dbContext.Categories.Add(new Category { CategoryName = "Soft Drinks", Type = OrderType.Bar });
                dbContext.SaveChanges();
                Category updated = new Category { CategoryId = 1, CategoryName = "Drinks", Type = OrderType.Bar };

                // Act
                Category? result = await categoryRepository.UpdateCategoryAsync(updated);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Drinks", result.CategoryName);
            }
        }

        [Fact]
        public async Task DeleteCategoryAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);
                dbContext.Categories.Add(new Category { CategoryName = "Soft Drinks", Type = OrderType.Bar });
                dbContext.SaveChanges();

                // Act
                bool result = await categoryRepository.DeleteCategoryAsync(1);

                // Assert
                Assert.True(result);
            }
        }
    }
}
