﻿using System;
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
    }
}
