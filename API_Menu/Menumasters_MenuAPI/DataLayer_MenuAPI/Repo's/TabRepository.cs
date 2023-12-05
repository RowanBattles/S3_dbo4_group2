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
    }
}

