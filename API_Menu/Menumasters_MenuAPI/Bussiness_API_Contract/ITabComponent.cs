using System;
using MenuAPI_Models;

namespace Bussiness_API_Contract
{
	public interface ITabComponent
	{
        Task<Tab?> GetTabByIdAsync(int id);

        Task<bool> CreateTabAsync(Tab tab);

        Task<bool> UpdateTabAsync(Tab tab);

    }
}

