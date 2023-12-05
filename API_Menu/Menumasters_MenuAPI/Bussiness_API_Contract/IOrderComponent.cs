using System;
using MenuAPI_Models;

namespace Bussiness_API_Contract
{
	public interface IOrderComponent
	{
        Task<Order?> GetOrderByIdAsync(int id);

        Task<bool> CreateOrderAsync(Order order);

        Task<bool> AddItemToOrderAsync(OrderItem orderItem);

        Task<bool> UpdateOrderAsync(Order order);

        Task<bool> RemoveItemFromOrderAsync(int id);

        Task<bool> DeleteOrderAsync(int id);
    }
}

