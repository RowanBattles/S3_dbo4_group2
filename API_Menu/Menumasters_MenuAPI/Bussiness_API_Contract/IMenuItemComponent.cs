using System;
using MenuAPI_Models;

namespace Bussiness_API_Contract
{
	public interface IMenuItemComponent
	{
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();

        Task<MenuItem?> GetMenuItemByIdAsync(int id);

    }
}

