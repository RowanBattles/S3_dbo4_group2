using System;
using Bussiness_API_Contract;
using DataLayer_Factory;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
	public class OrderComponent : IOrderComponent
    {
        private readonly IOrdersDAL _repo;

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllKitchenOrdersAsync()
        {
            IEnumerable<Order> orders = await _repo.GetAllOrdersByTypeAsync(OrderType.Kitchen);
            List<KitchenOrder> kitchenOrders = new List<KitchenOrder>();

            foreach (Order order in orders)
            {
                Tab? tab = await DataAccessFactory.GetTabRepository().GetTabByIdAsync(order.TabId);

                KitchenOrder kitchenOrder = new KitchenOrder(order);
                kitchenOrder.TableNumber = tab != null ? tab.TableNumber : -1;

                kitchenOrders.Add(kitchenOrder);
            }

            return kitchenOrders;
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllBarOrdersAsync()
        {
            IEnumerable<Order> orders = await _repo.GetAllOrdersByTypeAsync(OrderType.Bar);
            List<KitchenOrder> barOrders = new List<KitchenOrder>();

            foreach (Order order in orders)
            {
                Tab? tab = await DataAccessFactory.GetTabRepository().GetTabByIdAsync(order.TabId);

                KitchenOrder barOrder = new KitchenOrder(order);
                barOrder.TableNumber = tab != null ? tab.TableNumber : -1;

                barOrders.Add(barOrder);
            }

            return barOrders;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllSalesOrdersAsync()
        {
            IEnumerable<Order> orders = await _repo.GetAllOrdersAsync();
            List<SalesOrder> salesOrders = new List<SalesOrder>();

            foreach (Order order in orders)
            {
                Tab? tab = await DataAccessFactory.GetTabRepository().GetTabByIdAsync(order.TabId);

                SalesOrder salesOrder = new SalesOrder(order);
                salesOrder.TableNumber = tab != null ? tab.TableNumber : -1;
                salesOrder.TabTotal = tab != null ? tab.TabTotal : null;

                salesOrders.Add(salesOrder);
            }

            return salesOrders;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repo.GetOrderByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            return await _repo.CreateOrderAsync(order);
        }

        public async Task<bool> AddItemToOrderAsync(OrderItem orderItem)
        {
            return await _repo.AddItemToOrderAsync(orderItem);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _repo.UpdateOrderAsync(order);
        }

        public async Task<bool> RemoveItemFromOrderAsync(int id)
        {
            return await _repo.RemoveItemFromOrderAsync(id);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _repo.DeleteOrderAsync(id);
        }
    }
}
