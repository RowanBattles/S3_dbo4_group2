using System;
using Bussiness_API_Contract;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
	public class MenuComponent : IMenuComponent
    {
        private readonly IMenuDAL _repo;

        public MenuComponent(IMenuDAL repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _repo.GetAllMenuItemsAsync();
        }

        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return await _repo.GetMenuItemByIdAsync(id);
        }
    }
}

