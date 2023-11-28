using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;

namespace Bussiness.Components
{
	public class TabComponent : ITabComponent
    {
        private readonly ITabRepository _tabRepo;

		public TabComponent(ITabRepository tabRepository)
		{
            _tabRepo = tabRepository;
        }

        public async Task<IEnumerable<Tab>> GetAllTabsAsync()
        {
            return await _tabRepo.GetAllTabsAsync();
        }

        public async Task<Tab?> GetTabByIdAsync(int id)
        {
            return await _tabRepo.GetTabByIdAsync(id);
        }

        public async Task<bool> CreateTabAsync(Tab tab)
        {
            return await _tabRepo.CreateTabAsync(tab);
        }

        public async Task<bool> UpdateTabAsync(Tab tab)
        {
            return await _tabRepo.UpdateTabAsync(tab);
        }

        public async Task<bool> DeleteTabAsync(int id)
        {
            return await _tabRepo.DeleteTabAsync(id);
        }
    }
}

