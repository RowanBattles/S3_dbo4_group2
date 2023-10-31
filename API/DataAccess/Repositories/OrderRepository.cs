using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Contract_Data_Bussiness.Interfaces;

namespace DataAccess.Repositories
{
	public class OrderRepository : IOrderRepository
    {
		private readonly MenuMastersDbContext dbContext;

        public OrderRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<Order>> GetAllOrdersAsync()
		{
			return await dbContext.Orders.Include(e => e.MenuItems).ToListAsync();
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

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                Order? original = await GetOrderByIdAsync(id);

                if (original == null) return false;

                dbContext.Orders.Remove(original);
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

