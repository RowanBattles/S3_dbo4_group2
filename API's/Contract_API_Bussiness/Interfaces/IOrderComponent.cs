using System;
using Models;
using Models.DTOs;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderComponent
	{
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<IEnumerable<KitchenOrder>> GetAllKitchenOrdersAsync();

        Task<IEnumerable<KitchenOrder>> GetAllBarOrdersAsync();

        Task<IEnumerable<SalesOrder>> GetAllSalesOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task<bool> CreateOrderAsync(Order order);

        Task<bool> AddItemToOrderAsync(OrderItem orderItem);

        Task<bool> UpdateOrderAsync(Order order);

        Task<bool> RemoveItemFromOrderAsync(int id);

        Task<bool> DeleteOrderAsync(int id);
    }
}

