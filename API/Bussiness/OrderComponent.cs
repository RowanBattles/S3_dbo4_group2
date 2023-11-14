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
                //Tab? tab = await DataAccessFactory.GetTabRepository().GetTabByIdAsync(order.TabId);

                List<KitchenOrderItem> kitchenOrderItems = new List<KitchenOrderItem>();
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    KitchenOrderItem kitchenOrderItem = new KitchenOrderItem();
                    kitchenOrderItem.MenuItemId = orderItem.MenuItemId;
                    kitchenOrderItem.ItemName = orderItem.MenuItem.ItemName;
                    kitchenOrderItem.Quantity = orderItem.Quantity;

                    kitchenOrderItems.Add(kitchenOrderItem);
                }

                KitchenOrder kitchenOrder = new KitchenOrder();
                kitchenOrder.OrderId = order.OrderId;
                kitchenOrder.TabId = order.TabId;
                kitchenOrder.TableNumber = null;
                kitchenOrder.Status = order.Status;
                kitchenOrder.Notes = order.Notes;
                kitchenOrder.DateTime = order.DateTime;
                kitchenOrder.OrderItems = kitchenOrderItems;

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

                List<KitchenOrderItem> barOrderItems = new List<KitchenOrderItem>();
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    KitchenOrderItem barOrderItem = new KitchenOrderItem();
                    barOrderItem.MenuItemId = orderItem.MenuItemId;
                    barOrderItem.ItemName = orderItem.MenuItem.ItemName;
                    barOrderItem.Quantity = orderItem.Quantity;

                    barOrderItems.Add(barOrderItem);
                }

                KitchenOrder barOrder = new KitchenOrder();
                barOrder.OrderId = order.OrderId;
                barOrder.TabId = order.TabId;
                barOrder.TableNumber = tab != null ? tab.TableNumber : -1;
                barOrder.Status = order.Status;
                barOrder.Notes = order.Notes;
                barOrder.DateTime = order.DateTime;
                barOrder.OrderItems = barOrderItems;

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

                List<SalesOrderItem> salesOrderItems = new List<SalesOrderItem>();
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    SalesOrderItem salesOrderItem = new SalesOrderItem();
                    salesOrderItem.MenuItemId = orderItem.MenuItemId;
                    salesOrderItem.ItemName = orderItem.MenuItem.ItemName;
                    salesOrderItem.ItemPrice = orderItem.MenuItem.ItemPrice;
                    salesOrderItem.Quantity = orderItem.Quantity;

                    salesOrderItems.Add(salesOrderItem);
                }

                SalesOrder salesOrder = new SalesOrder();
                salesOrder.OrderId = order.OrderId;
                salesOrder.TabId = order.TabId;
                salesOrder.TableNumber = tab != null ? tab.TableNumber : -1;
                salesOrder.TabTotal = tab != null ? tab.TabTotal : -1;
                salesOrder.Status = order.Status;
                salesOrder.Notes = order.Notes;
                salesOrder.DateTime = order.DateTime;
                salesOrder.OrderItems = salesOrderItems;

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

