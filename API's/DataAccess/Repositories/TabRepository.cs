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
			return await dbContext.Tabs.Include(x => x.Orders).ThenInclude(x => x.OrderItems).ThenInclude(x => x.MenuItem).ToListAsync();
		}

        public async Task<Tab?> GetTabByIdAsync(int id)
        {
            return await dbContext.Tabs.Include(x => x.Orders).ThenInclude(x => x.OrderItems).ThenInclude(x => x.MenuItem).FirstOrDefaultAsync(x => x.TabId == id);
        }

        public async Task<Tab?> GetOpenTabWithTableNumberAsync(int tableNumber)
        {
            IEnumerable<Tab> tabs = await dbContext.Tabs.Include(x => x.Orders).ThenInclude(x => x.OrderItems).ThenInclude(x => x.MenuItem).Where(x => x.TableNumber == tableNumber).ToListAsync();
            return tabs.FirstOrDefault(x => !x.Paid);
        }

        public async Task<Tab?> CreateTabAsync(Tab tab)
        {
            try
            {
                await dbContext.Tabs.AddAsync(tab);
                await dbContext.SaveChangesAsync();

                return tab;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Tab?> UpdateTabAsync(Tab tab)
        {
            try
            {
                Tab? original = await GetTabByIdAsync(tab.TabId);

                if (original == null) return null;

                dbContext.Entry(original).CurrentValues.SetValues(tab);
                await dbContext.SaveChangesAsync();

                return tab;
            }
            catch
            {
                return null;
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

