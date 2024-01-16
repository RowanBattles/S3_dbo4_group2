using System;
using MenuAPI_Models;

namespace DateLayer_Bussiness_Contract
{
	public interface IMenuDAL
	{
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();

        Task<MenuItem?> GetMenuItemByIdAsync(int id);
    }
}

