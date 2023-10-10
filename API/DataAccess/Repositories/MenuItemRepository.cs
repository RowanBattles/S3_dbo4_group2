using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class MenuItemRepository
	{
		private readonly MenuMastersDbContext dbContext;

        public MenuItemRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
		{
			return await dbContext.MenuItems.ToListAsync();
		}

        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return await dbContext.MenuItems.FindAsync(id);
        }
    }
}

