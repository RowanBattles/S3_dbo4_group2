using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderComponent
	{
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task<bool> CreateOrderAsync(Order order);

        Task<bool> UpdateOrderAsync(Order order);

        Task<bool> DeleteOrderAsync(int id);
    }
}

