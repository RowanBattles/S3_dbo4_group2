using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;
using Models.DTOs;

namespace Bussiness.Components
{
	public class TabComponent : ITabComponent
    {
        private readonly ITabRepository _tabRepo;
        private readonly IOrderRepository _orderRepo;

		public TabComponent(ITabRepository tabRepository, IOrderRepository orderRepository)
		{
            _tabRepo = tabRepository;
            _orderRepo = orderRepository;
        }

        private async Task<SalesTab> GetSalesTabAsync(Tab tab)
        {
            SalesTab salesTab = new SalesTab(tab);

            foreach (Order order in tab.Orders)
            {
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    SalesOrderItem salesOrderItem = new SalesOrderItem(orderItem);
                    salesTab.OrderItems.Add(salesOrderItem);
                }
            }

            return salesTab;
        }

        public async Task<IEnumerable<Tab>> GetAllTabsAsync()
        {
            return await _tabRepo.GetAllTabsAsync();
        }

        public async Task<IEnumerable<SalesTab>> GetAllSalesTabsAsync()
        {
            IEnumerable<Tab> tabs = await _tabRepo.GetAllTabsAsync();
            List<SalesTab> salesTabs = new List<SalesTab>();

            foreach (Tab tab in tabs)
            {
                if (!tab.Paid)
                {
                    salesTabs.Add(await GetSalesTabAsync(tab));
                }
            }

            return salesTabs;
        }

        public async Task<Tab?> GetTabByIdAsync(int id)
        {
            return await _tabRepo.GetTabByIdAsync(id);
        }

        public async Task<SalesTab?> GetSalesTabByIdAsync(int id)
        {
            Tab? tab = await _tabRepo.GetTabByIdAsync(id);

            if (tab != null)
            {
                return await GetSalesTabAsync(tab);
            }

            return null;
        }

        public async Task<Tab?> CreateTabAsync(Tab tab)
        {
            return await _tabRepo.CreateTabAsync(tab);
        }

        public async Task<Tab?> UpdateTabAsync(Tab tab)
        {
            return await _tabRepo.UpdateTabAsync(tab);
        }

        public async Task<bool> DeleteTabAsync(int id)
        {
            return await _tabRepo.DeleteTabAsync(id);
        }
    }
}

