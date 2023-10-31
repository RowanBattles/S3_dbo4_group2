using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderItemComponent
	{
        Task<List<OrderItem>> GetOrderItems();

        Task<OrderItem> GetOrderItem();

        Task<bool> CreateOrderItem();

        Task<bool> UpdateOrderItem();

        Task<bool> DeleteOrderItem();
    }
}

