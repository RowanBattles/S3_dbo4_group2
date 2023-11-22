using System;
using Bussiness_API_Contract;
using DataLayer_Factory;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
	public class TabComponent : ITabComponent
    {
        private readonly ITabDAL _repo;

        public TabComponent()
        {
            _repo = DateLayerFactory.GetTabDAL();
        }

        public async Task<Tab?> GetTabByIdAsync(int id)
        {
            return await _repo.GetTabByIdAsync(id);
        }

        public async Task<bool> CreateTabAsync(Tab tab)
        {
            return await _repo.CreateTabAsync(tab);
        }

        public async Task<bool> UpdateTabAsync(Tab tab)
        {
            return await _repo.UpdateTabAsync(tab);
        }
    }
}

