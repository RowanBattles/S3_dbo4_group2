using System;
using Models;
using Models.Enums;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IOrderRepository
	{
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<IEnumerable<Order>> GetAllOrdersByTypeAsync(OrderType type);

        Task<Order?> GetOrderByIdAsync(int id);

        Task<Order?> CreateOrderAsync(Order order);

        Task<OrderItem?> AddItemToOrderAsync(OrderItem orderItem);

        Task<Order?> UpdateOrderAsync(Order order);

        Task<bool> RemoveItemFromOrderAsync(int id);

        Task<bool> DeleteOrderAsync(int id);
    }
}

