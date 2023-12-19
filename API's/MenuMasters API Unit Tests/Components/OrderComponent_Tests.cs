using System;
using Bussiness.Components;
using Contract_Data_Bussiness.Interfaces;
using Moq;

namespace MenuMasters_API_Unit_Tests.Components
{
	public class OrderComponent_Tests
	{
        private readonly OrderComponent _orderComponent;

        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ITabRepository> _tabRepositoryMock;

        public OrderComponent_Tests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _tabRepositoryMock = new Mock<ITabRepository>();

            _orderComponent = new OrderComponent(
                _orderRepositoryMock.Object,
                _tabRepositoryMock.Object
            );
        }

        [Fact]
        public async Task GetAllOrdersAsync_Test()
        {

        }

        [Fact]
        public async Task GetAllKitchenOrdersAsync_Test()
        {

        }

        [Fact]
        public async Task GetAllBarOrdersAsync_Test()
        {

        }

        [Fact]
        public async Task GetOrderByIdAsync_Test()
        {

        }

        [Fact]
        public async Task CreateOrderAsync_Test()
        {

        }

        [Fact]
        public async Task AddItemToOrderAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateOrderAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateItemFromOrderAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateKitchenOrderStateAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateBarOrderStateAsync_Test()
        {

        }

        [Fact]
        public async Task DeleteOrderAsync_Test()
        {

        }

        [Fact]
        public async Task RemoveItemFromOrderAsync_Test()
        {

        }
    }
}

