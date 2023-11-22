using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using DataAccess_Factory;
using Models;
using Models.DTOs;

namespace Bussiness
{
    public class OrderComponent : IOrderComponent
	{
        private readonly IOrderRepository _repo;

		public OrderComponent()
		{
            _repo = DataAccessFactory.GetOrderRepository();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllKitchenOrdersAsync()
        {
            // TODO: filter based on type (kitchen) here first
            IEnumerable<Order> orders = await _repo.GetAllOrdersAsync();
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
            // TODO: filter based on type (bar) here first
            IEnumerable<Order> orders = await _repo.GetAllOrdersAsync();
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
                salesOrder.TabTotal = tab != null ? tab.TabTotal : -1;

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

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _repo.UpdateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _repo.DeleteOrderAsync(id);
        }
    }
}

