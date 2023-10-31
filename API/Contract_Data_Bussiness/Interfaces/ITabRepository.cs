using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface ITabRepository
	{
        Task<IEnumerable<Tab>> GetAllTabsAsync();

        Task<Tab?> GetTabByIdAsync(int id);
    }
}

