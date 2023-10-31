using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using DataAccess_Factory;
using Models;

namespace Bussiness;
public class MenuItemComponent : IMenuItemComponent
{
    private readonly IMenuItemRepository _repo;

    public MenuItemComponent()
    {
        _repo = DataAccessFactory.GetMenuItemRepository();
    }

    public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
    {
        return await _repo.GetAllMenuItemsAsync();
    }

    public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
    {
        return await _repo.GetMenuItemByIdAsync(id);
    }

    public async Task<bool> CreateMenuItemAsync(MenuItem menuItem)
    {
        return await _repo.CreateMenuItemAsync(menuItem);
    }

    public async Task<bool> UpdateMenuItemAsync(MenuItem menuItem)
    {
        return await _repo.UpdateMenuItemAsync(menuItem);
    }

    public async Task<bool> DeleteMenuItemAsync(int id)
    {
        return await _repo.DeleteMenuItemAsync(id);
    }
}
