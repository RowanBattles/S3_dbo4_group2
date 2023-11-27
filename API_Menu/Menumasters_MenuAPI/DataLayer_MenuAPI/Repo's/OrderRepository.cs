using System;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer_MenuAPI.Repos
{
	public class OrderRepository : IOrdersDAL
	{
        private readonly MenuAPIDBContext dbContext;

        public OrderRepository(MenuAPIDBContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await dbContext.Orders.FindAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            try
            {
                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            try
            {
                Order? original = await GetOrderByIdAsync(order.OrderId);

                if (original == null) return false;

                dbContext.Entry(original).CurrentValues.SetValues(order);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

