using System;
using MenuAPI_Models;

namespace Bussiness_API_Contract
{
	public interface ITabComponent
	{
        Task<bool> CreateTabAsync(Tab tab);

        //Task<bool> UpdateTabAsync(Tab tab);
        //Task<Tab?> GetTabByIdAsync(int id);

    }
}

