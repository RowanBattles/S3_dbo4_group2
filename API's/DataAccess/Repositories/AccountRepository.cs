using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Contract_Data_Bussiness.Interfaces;

namespace DataAccess.Repositories
{
	public class AccountRepository : IAccountRepository
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

