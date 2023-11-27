using System;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer_MenuAPI.Repos
{
	public class TabRepository : ITabDAL
	{
        private readonly MenuAPIDBContext dbContext;

        public TabRepository(MenuAPIDBContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<Tab?> GetTabByIdAsync(int id)
        {
            return await dbContext.Tabs.FindAsync(id);
        }

        public async Task<bool> CreateTabAsync(Tab tab)
        {
            try
            {
                await dbContext.Tabs.AddAsync(tab);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateTabAsync(Tab tab)
        {
            try
            {
                Tab? original = await GetTabByIdAsync(tab.TabId);

                if (original == null) return false;

                dbContext.Entry(original).CurrentValues.SetValues(tab);
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

