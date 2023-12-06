using System;
using Bussiness_API_Contract;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
	public class OrderComponent : IOrderComponent
    {
        private readonly IOrderDAL _repo;

        public OrderComponent(IOrderDAL repo)
        {
            _repo = repo;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repo.GetOrderByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            return await _repo.CreateOrderAsync(order);
        }

        public async Task<bool> AddItemToOrderAsync(OrderItem orderItem)
        {
            return await _repo.AddItemToOrderAsync(orderItem);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _repo.UpdateOrderAsync(order);
        }

        public async Task<bool> RemoveItemFromOrderAsync(int id)
        {
            return await _repo.RemoveItemFromOrderAsync(id);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _repo.DeleteOrderAsync(id);
        }
    }
}
