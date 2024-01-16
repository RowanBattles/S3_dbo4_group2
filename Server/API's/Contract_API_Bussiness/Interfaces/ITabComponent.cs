using System;
using Models;
using Models.DTOs;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ITabComponent
	{
        Task<IEnumerable<Tab>> GetAllTabsAsync();

        Task<IEnumerable<SalesTab>> GetAllSalesTabsAsync();

        Task<Tab?> GetTabByIdAsync(int id);

        Task<SalesTab?> GetSalesTabByIdAsync(int id);

        Task<Tab?> CreateTabAsync(Tab tab);

        Task<Tab?> UpdateTabAsync(Tab tab);

        Task<SalesTab?> PayTab(PayTab payTab);

        Task<bool> DeleteTabAsync(int id);
    }
}

