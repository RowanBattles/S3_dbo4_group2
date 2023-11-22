using System;
using MenuAPI_Models;

namespace DateLayer_Bussiness_Contract
{
	public interface IOrdersDAL
	{

        Task<Order?> GetOrderByIdAsync(int id);

        Task<bool> CreateOrderAsync(Order order);

        Task<bool> UpdateOrderAsync(Order order);
    }
}

