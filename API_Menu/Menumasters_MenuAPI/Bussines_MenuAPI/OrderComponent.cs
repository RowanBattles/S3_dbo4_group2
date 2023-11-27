using System;
using Bussiness_API_Contract;
using DataLayer_Factory;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
	public class OrderComponent : IOrderComponent
    {
        private readonly IOrdersDAL _repo;

        public OrderComponent()
        {
            _repo = DateLayerFactory.GetOrdersDAL();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repo.GetOrderByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            return await _repo.CreateOrderAsync(order);
        }
    }
}
