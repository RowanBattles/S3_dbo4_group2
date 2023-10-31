using System;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class TabRepository
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
    }
}

