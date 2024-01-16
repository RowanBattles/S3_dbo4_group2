using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IMenuItemRepository
	{
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();

        Task<MenuItem?> GetMenuItemByIdAsync(int id);

        Task<MenuItem?> CreateMenuItemAsync(MenuItem menuItem);

        Task<MenuItem?> UpdateMenuItemAsync(MenuItem menuItem);

        Task<bool> DeleteMenuItemAsync(int id);
    }
}

