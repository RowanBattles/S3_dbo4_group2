using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IOrderRepository
	{
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<IEnumerable<OrderItem>> GetOrderItemsAsync()

        Task<Order?> GetOrderByIdAsync(int id);

        Task<bool> CreateOrderAsync(Order order);

        Task<bool> UpdateOrderAsync(Order order);

        Task<bool> DeleteOrderAsync(int id);
    }
}

