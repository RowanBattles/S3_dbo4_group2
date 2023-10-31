using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using DataAccess_Factory;
using Models;

namespace Bussiness
{
    public class OrderComponent : IOrderComponent
	{
        private readonly IOrderRepository _repo;

		public OrderComponent()
		{
            _repo = DataAccessFactory.GetOrderRepository();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _repo.GetOrderByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

