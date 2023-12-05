using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Contract_Data_Bussiness.Interfaces;

namespace DataAccess.Repositories
{
	public class TabRepository : ITabRepository
    {
		private readonly MenuMastersDbContext dbContext;

        public TabRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<Tab>> GetAllTabsAsync()
		{
			return await dbContext.Tabs.ToListAsync();
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

        public async Task<bool> DeleteTabAsync(int id)
        {
            try
            {
                Tab? original = await GetTabByIdAsync(id);

                if (original == null) return false;

                dbContext.Tabs.Remove(original);
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

