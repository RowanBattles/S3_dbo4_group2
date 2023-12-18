using System;
using Bussiness.Components;
using Contract_Data_Bussiness.Interfaces;
using Moq;

namespace MenuMasters_API_Unit_Tests.Components
{
	public class TabComponent_Tests
	{
        private readonly TabComponent _tabComponent;

        private readonly Mock<ITabRepository> _tabRepositoryMock;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;

        public TabComponent_Tests()
        {
            _tabRepositoryMock = new Mock<ITabRepository>();
            _orderRepositoryMock = new Mock<IOrderRepository>();

            _tabComponent = new TabComponent(
                _tabRepositoryMock.Object,
                _orderRepositoryMock.Object
            );
        }

        [Fact]
        public async Task GetAllTabsAsync_Test()
        {

        }

        [Fact]
        public async Task GetAllSalesTabsAsync_Test()
        {

        }

        [Fact]
        public async Task GetTabByIdAsync_Test()
        {

        }

        [Fact]
        public async Task GetSalesTabByIdAsync_Test()
        {

        }

        [Fact]
        public async Task CreateTabAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateTabAsync_Test()
        {

        }

        [Fact]
        public async Task PayTab_Test()
        {

        }

        [Fact]
        public async Task DeleteTabAsync_Test()
        {

        }
    }
}

