using System;
using Bussiness.Components;
using Contract_Data_Bussiness.Interfaces;
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

        }

        [Fact]
        public async Task GetMenuItemByIdAsync_Test()
        {

        }

        [Fact]
        public async Task CreateMenuItemAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateMenuItemAsync_Test()
        {

        }

        [Fact]
        public async Task DeleteMenuItemAsync_Test()
        {

        }
    }
}

