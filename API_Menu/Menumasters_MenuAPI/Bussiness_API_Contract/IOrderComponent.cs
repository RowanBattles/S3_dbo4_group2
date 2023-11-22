using System;
using MenuAPI_Models;

namespace Bussiness_API_Contract
{
	public interface IOrderComponent
	{
        Task<Order?> GetOrderByIdAsync(int id);

        Task<bool> CreateOrderAsync(Order order);

    }
}

