using System;
using MenuAPI_Models;

namespace DateLayer_Bussiness_Contract
{
	public interface ITabDAL
	{
        Task<bool> CreateTabAsync(Tab tab);
    }
}

