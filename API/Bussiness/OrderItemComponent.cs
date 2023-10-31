using System;
using Contract_API_Bussiness.Interfaces;
using DataAccess.Models;
using Models;

namespace Bussiness
{
    public class OrderItemComponent : IOrderItemComponent
	{
		public OrderItemComponent()
		{
		}

        public Task<bool> CreateOrderItemAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderItemAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}

