using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class AccountRepository
	{
		private readonly MenuMastersDbContext dbContext;

        public AccountRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<Account>> GetAllAccountsAsync()
		{
			return await dbContext.Accounts.ToListAsync();
		}

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await dbContext.Accounts.FindAsync(id);
        }
    }
}

