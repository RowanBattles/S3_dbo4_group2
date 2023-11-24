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

        public async Task<bool> CreateMenuItemAsync(MenuItem menuItem)
        {
            try
            {
                await dbContext.MenuItems.AddAsync(menuItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateMenuItemAsync(MenuItem menuItem)
        {
            try
            {
                MenuItem? original = await GetMenuItemByIdAsync(menuItem.MenuItemId);

                if (original == null) return false;

                dbContext.Entry(original).CurrentValues.SetValues(menuItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            try
            {
                MenuItem? original = await GetMenuItemByIdAsync(id);

                if (original == null) return false;

                dbContext.MenuItems.Remove(original);
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

