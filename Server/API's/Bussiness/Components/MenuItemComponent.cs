using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;

namespace Bussiness.Components
{
    public class MenuItemComponent : IMenuItemComponent
    {
        private readonly IMenuItemRepository _menuItemRepo;

        public MenuItemComponent(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepo = menuItemRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepo.GetAllMenuItemsAsync();
        }

        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return await _menuItemRepo.GetMenuItemByIdAsync(id);
        }

        public async Task<MenuItem?> CreateMenuItemAsync(MenuItem menuItem)
        {
            return await _menuItemRepo.CreateMenuItemAsync(menuItem);
        }

        public async Task<MenuItem?> UpdateMenuItemAsync(MenuItem menuItem)
        {
            return await _menuItemRepo.UpdateMenuItemAsync(menuItem);
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            return await _menuItemRepo.DeleteMenuItemAsync(id);
        }
    }
}
