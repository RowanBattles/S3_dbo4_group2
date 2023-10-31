using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IAccountRepository
	{
        Task<IEnumerable<Account>> GetAllAccountsAsync();

        Task<Account?> GetAccountByIdAsync(int id);
    }
}

