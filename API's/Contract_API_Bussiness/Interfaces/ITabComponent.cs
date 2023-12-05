using System;
using Models;
using Models.DTOs;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ITabComponent
	{
        Task<IEnumerable<SalesTab>> GetAllTabsAsync();

        Task<SalesTab?> GetTabByIdAsync(int id);

        Task<Tab?> CreateTabAsync(Tab tab);

        Task<Tab?> UpdateTabAsync(Tab tab);

        Task<bool> DeleteTabAsync(int id);
    }
}

