using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderComponent
	{
        Task<List<Order>> GetOrders();

        Task<Order> GetOrder();

        Task<bool> CreateOrder();

        Task<bool> UpdateOrder();

        Task<bool> DeleteOrder();
    }
}

