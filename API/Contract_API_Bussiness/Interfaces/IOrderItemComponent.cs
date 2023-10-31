using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderItemComponent
	{
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync();

        Task<OrderItem> GetOrderItemByIdAsync(int id);

        Task<bool> CreateOrderItemAsync(OrderItem orderItem);

        Task<bool> UpdateOrderItemAsync(OrderItem orderItem);

        Task<bool> DeleteOrderItemAsync(int id);
    }
}

