using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Contract_Data_Bussiness.Interfaces;

namespace DataAccess.Repositories
{
	public class MenuItemRepository : IMenuItemRepository
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

