using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IMenuItemRepository
	{
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();

        Task<MenuItem?> GetMenuItemByIdAsync(int id);

        Task<bool> CreateMenuItemAsync(MenuItem menuItem);

        Task<bool> UpdateMenuItemAsync(MenuItem menuItem);

        Task<bool> DeleteMenuItemAsync(int id);
    }
}

