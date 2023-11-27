using System;
using MenuAPI_Models;

namespace DateLayer_Bussiness_Contract
{
	public interface ITabDAL
	{
        Task<Tab?> GetTabByIdAsync(int id);

        Task<bool> CreateTabAsync(Tab tab);

        Task<bool> UpdateTabAsync(Tab tab);
    }
}

