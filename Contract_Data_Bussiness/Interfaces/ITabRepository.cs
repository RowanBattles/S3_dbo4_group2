using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface ITabRepository
	{
        Task<IEnumerable<Tab>> GetAllTabsAsync();

        Task<Tab?> GetTabByIdAsync(int id);

        Task<bool> CreateTabAsync(Tab tab);

        Task<bool> UpdateTabAsync(Tab tab);

        Task<bool> DeleteTabAsync(int id);
    }
}

