using System;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer_MenuAPI.Repos
{
	public class MenuItemRepository : IMenuItemDAL
	{
        private readonly MenuAPIDBContext dbContext;

        public MenuItemRepository(MenuAPIDBContext _dbContext)
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

