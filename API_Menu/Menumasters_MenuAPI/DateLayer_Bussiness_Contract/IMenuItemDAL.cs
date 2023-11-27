using System;
using MenuAPI_Models;

namespace DateLayer_Bussiness_Contract
{
	public interface IMenuItemDAL
	{
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();

        Task<MenuItem?> GetMenuItemByIdAsync(int id);
    }
}

