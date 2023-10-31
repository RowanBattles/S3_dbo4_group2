using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ITabComponent
	{
        Task<IEnumerable<Tab>> GetAllTabsAsync();

        Task<Tab?> GetTabByIdAsync(int id);

        Task<bool> CreateTabAsync(Tab tab);

        Task<bool> UpdateTabAsync(Tab tab);

        Task<bool> DeleteTabAsync(int id);
    }
}

