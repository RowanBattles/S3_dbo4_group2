using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IMenuComponent
	{
		Task<IEnumerable<MenuItem>> GetMenuItemsAsync();

		Task<MenuItem> GetMenuItemByIdAsync(int id);

		Task<bool> CreateMenuItemAsync(MenuItem menuItem);

		Task<bool> UpdateMenuItemAsync(MenuItem menuItem);

		Task<bool> DeleteMenuItemAsync(MenuItem menuItem);
	}
}

