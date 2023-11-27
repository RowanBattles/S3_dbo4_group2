using System;
using Bussiness_API_Contract;
using DataLayer_Factory;
using DataLayer_MenuAPI.Repos;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
	public class MenuItemComponent : IMenuItemComponent
    {
        private readonly IMenuItemDAL _repo;

        public MenuItemComponent()
        {
            _repo = DateLayerFactory.GetMenuItemDAL();
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

