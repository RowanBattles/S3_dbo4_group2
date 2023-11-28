using System.Threading;
using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;
using Models.DTOs;
using Models.Enums;

namespace Bussiness.Components
{
    public class OrderComponent : IOrderComponent
	{
        private readonly IOrderRepository _orderRepo;
        private readonly ITabRepository _tabRepo;

		public OrderComponent(IOrderRepository orderRepository, ITabRepository tabRepository)
		{
            _orderRepo = orderRepository;
            _tabRepo = tabRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllKitchenOrdersAsync()
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersByTypeAsync(OrderType.Kitchen);
            List<KitchenOrder> kitchenOrders = new List<KitchenOrder>();

            foreach (Order order in orders)
            {
                if (order.OrderItems.Count > 0)
                {
                    Tab? tab = await _tabRepo.GetTabByIdAsync(order.TabId);

                    KitchenOrder kitchenOrder = new KitchenOrder(order);
                    kitchenOrder.TableNumber = tab != null ? tab.TableNumber : -1;

                    kitchenOrders.Add(kitchenOrder);
                }
            }

            return kitchenOrders;
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllBarOrdersAsync()
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersByTypeAsync(OrderType.Bar);
            List<KitchenOrder> barOrders = new List<KitchenOrder>();

            foreach (Order order in orders)
            {
                if (order.OrderItems.Count > 0)
                {
                    Tab? tab = await _tabRepo.GetTabByIdAsync(order.TabId);

                    KitchenOrder barOrder = new KitchenOrder(order);
                    barOrder.TableNumber = tab != null ? tab.TableNumber : -1;

                    barOrders.Add(barOrder);
                }
            }

            return barOrders;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllSalesOrdersAsync()
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersAsync();
            List<SalesOrder> salesOrders = new List<SalesOrder>();

            foreach (Order order in orders)
            {
                Tab? tab = await _tabRepo.GetTabByIdAsync(order.TabId);

                if (tab != null && !tab.Paid && order.OrderItems.Count > 0)
                {
                    SalesOrder salesOrder = new SalesOrder(order);
                    salesOrder.TableNumber = tab != null ? tab.TableNumber : -1;
                    salesOrder.TabTotal = tab != null ? tab.TabTotal : null;

                    salesOrders.Add(salesOrder);
                }
            }

            return salesOrders;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepo.GetOrderByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            return await _orderRepo.CreateOrderAsync(order);
        }

        public async Task<bool> AddItemToOrderAsync(OrderItem orderItem)
        {
            return await _orderRepo.AddItemToOrderAsync(orderItem);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _orderRepo.UpdateOrderAsync(order);
        }

        public async Task<bool> RemoveItemFromOrderAsync(int id)
        {
            return await _orderRepo.RemoveItemFromOrderAsync(id);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepo.DeleteOrderAsync(id);
        }
    }
}

