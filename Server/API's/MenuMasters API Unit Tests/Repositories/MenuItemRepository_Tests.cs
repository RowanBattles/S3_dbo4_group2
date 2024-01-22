using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MenuMasters_API_Unit_Tests.Repositories
{
	public class MenuItemRepository_Tests
	{
        private readonly DbContextOptions<MenuMastersDbContext> _options;

        public MenuItemRepository_Tests()
        {
            _options = new DbContextOptionsBuilder<MenuMastersDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase_{new Random().Next(int.MinValue, int.MaxValue)}")
                .Options;
        }

        [Fact]
		public async Task GetAllMenuItemsAsync_Test()
		{
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                MenuItemRepository menuItemRepository = new MenuItemRepository(dbContext);
                dbContext.MenuItems.Add(new MenuItem { ItemName = "Cola", ItemPrice = 1.00m, ItemDescription_Long = "A refreshing drink", ItemDescription_Short = "A refreshing drink", ItemStock = 10 });
                dbContext.MenuItems.Add(new MenuItem { ItemName = "Burger", ItemPrice = 3.50m, ItemDescription_Long = "A classic burger", ItemDescription_Short = "A classic burger", ItemStock = 20 });
                dbContext.SaveChanges();

                // Act
                IEnumerable<MenuItem> result = await menuItemRepository.GetAllMenuItemsAsync();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
                Assert.Contains(result, x => x.ItemName == "Cola");
                Assert.Contains(result, x => x.ItemName == "Burger");
            }
        }

        [Fact]
        public async Task GetMenuItemByIdAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                MenuItemRepository menuItemRepository = new MenuItemRepository(dbContext);
                dbContext.MenuItems.Add(new MenuItem { ItemName = "Cola", ItemPrice = 1.00m, ItemDescription_Long = "A refreshing drink", ItemDescription_Short = "A refreshing drink", ItemStock = 10 });
                dbContext.SaveChanges();

                // Act
                MenuItem? result = await menuItemRepository.GetMenuItemByIdAsync(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Cola", result.ItemName);
                Assert.Equal(1.00m, result.ItemPrice);
            }
        }

        [Fact]
        public async Task CreateMenuItemAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                MenuItemRepository menuItemRepository = new MenuItemRepository(dbContext);
                MenuItem newMenuItem = new MenuItem { ItemName = "Cola", ItemPrice = 1.00m, ItemDescription_Long = "A refreshing drink", ItemDescription_Short = "A refreshing drink", ItemStock = 10 };

                // Act
                MenuItem? result = await menuItemRepository.CreateMenuItemAsync(newMenuItem);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Cola", result.ItemName);
                Assert.Equal(1.00m, result.ItemPrice);
            }
        }

        [Fact]
        public async Task UpdateMenuItemAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                MenuItemRepository menuItemRepository = new MenuItemRepository(dbContext);
                dbContext.MenuItems.Add(new MenuItem { ItemName = "Cola", ItemPrice = 1.00m, ItemDescription_Long = "A refreshing drink", ItemDescription_Short = "A refreshing drink", ItemStock = 10 });
                dbContext.SaveChanges();
                MenuItem updated = new MenuItem { MenuItemId = 1, ItemName = "Sprite", ItemPrice = 1.50m, ItemDescription_Long = "A refreshing drink", ItemDescription_Short = "A refreshing drink", ItemStock = 10 };

                // Act
                MenuItem? result = await menuItemRepository.UpdateMenuItemAsync(updated);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Sprite", result.ItemName);
                Assert.Equal(1.50m, result.ItemPrice);
            }
        }

        [Fact]
        public async Task DeleteMenuItemAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                MenuItemRepository menuItemRepository = new MenuItemRepository(dbContext);
                dbContext.MenuItems.Add(new MenuItem { ItemName = "Cola", ItemPrice = 1.00m, ItemDescription_Long = "A refreshing drink", ItemDescription_Short = "A refreshing drink", ItemStock = 10 });
                dbContext.SaveChanges();

                // Act
                bool result = await menuItemRepository.DeleteMenuItemAsync(1);

                // Assert
                Assert.True(result);
            }
        }
    }
}

