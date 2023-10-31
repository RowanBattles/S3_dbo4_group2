using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using DataAccess_Factory;
using Models;

namespace Bussiness
{
	public class TabComponent : ITabComponent
    {
        private readonly ITabRepository _repo;

		public TabComponent()
		{
            _repo = DataAccessFactory.GetTabRepository();
        }

        public async Task<IEnumerable<Tab>> GetAllTabsAsync()
        {
            return await _repo.GetAllTabsAsync();
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

        public async Task<bool> DeleteTabAsync(int id)
        {
            return await _repo.DeleteTabAsync(id);
        }
    }
}

