using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class OrderRepository
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
    }
}

