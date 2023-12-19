using System;
using Bussiness.Components;
using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;
using Models.Enums;
using Moq;

namespace MenuMasters_API_Unit_Tests.Components
{
	public class MenuItemComponent_Tests
	{
        private readonly MenuItemComponent _menuItemComponent;

        private readonly Mock<IMenuItemRepository> _menuItemRepositoryMock;

        public MenuItemComponent_Tests()
        {
            _menuItemRepositoryMock = new Mock<IMenuItemRepository>();

            _menuItemComponent = new MenuItemComponent(
                _menuItemRepositoryMock.Object
            );
        }

        [Fact]
        public async Task GetAllMenuItemsAsync_Test()
        {
            // Arrange
            IEnumerable<MenuItem> expectedMenuItems = new List<MenuItem>()
            {
                new MenuItem
                {
                    MenuItemId = 1,
                    ItemName = "Burger",
                    ItemPrice = 3.50m,
                    ItemDescription_Long = "A classic burger",
                    ItemDescription_Short = "A classic burger",
                    ItemStock = 20
                }
            };

            _menuItemRepositoryMock
                .Setup(repo => repo.GetAllMenuItemsAsync())
                .ReturnsAsync(expectedMenuItems);

            // Act
            IEnumerable<MenuItem> result = await _menuItemComponent.GetAllMenuItemsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMenuItems, result);
        }

        [Fact]
        public async Task GetMenuItemByIdAsync_Test()
        {
            // Arrange
            int inputMenuItemId = 1;

            MenuItem expectedMenuItem = new MenuItem
            {
                MenuItemId = 1,
                ItemName = "Burger",
                ItemPrice = 3.50m,
                ItemDescription_Long = "A classic burger",
                ItemDescription_Short = "A classic burger",
                ItemStock = 20
            };

            _menuItemRepositoryMock
                .Setup(repo => repo.GetMenuItemByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedMenuItem);

            // Act
            MenuItem? result = await _menuItemComponent.GetMenuItemByIdAsync(inputMenuItemId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMenuItem, result);
        }

        [Fact]
        public async Task CreateMenuItemAsync_Test()
        {
            // Arrange
            MenuItem expectedMenuItem = new MenuItem
            {
                MenuItemId = 1,
                ItemName = "Burger",
                ItemPrice = 3.50m,
                ItemDescription_Long = "A classic burger",
                ItemDescription_Short = "A classic burger",
                ItemStock = 20
            };

            MenuItem inputMenuItem = new MenuItem
            {
                ItemName = "Burger",
                ItemPrice = 3.50m,
                ItemDescription_Long = "A classic burger",
                ItemDescription_Short = "A classic burger",
                ItemStock = 20
            };

            _menuItemRepositoryMock
                .Setup(repo => repo.CreateMenuItemAsync(It.IsAny<MenuItem>()))
                .ReturnsAsync(expectedMenuItem);

            // Act
            MenuItem? result = await _menuItemComponent.CreateMenuItemAsync(inputMenuItem);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMenuItem, result);
        }

        [Fact]
        public async Task UpdateMenuItemAsync_Test()
        {
            // Arrange
            MenuItem expectedMenuItem = new MenuItem
            {
                MenuItemId = 1,
                ItemName = "Hamburger",
                ItemPrice = 4.50m,
                ItemDescription_Long = "A classic burger",
                ItemDescription_Short = "A classic burger",
                ItemStock = 20
            };

            MenuItem inputMenuItem = new MenuItem
            {
                MenuItemId = 1,
                ItemName = "Hamburger",
                ItemPrice = 4.50m,
                ItemDescription_Long = "A classic burger",
                ItemDescription_Short = "A classic burger",
                ItemStock = 20
            };

            _menuItemRepositoryMock
                .Setup(repo => repo.UpdateMenuItemAsync(It.IsAny<MenuItem>()))
                .ReturnsAsync(expectedMenuItem);

            // Act
            MenuItem? result = await _menuItemComponent.UpdateMenuItemAsync(inputMenuItem);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMenuItem, result);
        }

        [Fact]
        public async Task DeleteMenuItemAsync_Test()
        {
            // Arrange
            int inputMenuItemId = 1;

            _menuItemRepositoryMock
                .Setup(repo => repo.DeleteMenuItemAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            bool result = await _menuItemComponent.DeleteMenuItemAsync(inputMenuItemId);

            // Assert
            Assert.True(result);
        }
    }
}

