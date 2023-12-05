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
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersAsync();

            foreach (Order order in orders)
            {
                if (order.TabId == tab.TabId)
                {
                    foreach (OrderItem orderItem in order.OrderItems)
                    {
                        SalesOrderItem salesOrderItem = new SalesOrderItem(orderItem);
                        tab.OrderItems.Add(salesOrderItem);
                    }
                }
            }

            return tab;
        }

        public async Task<IEnumerable<SalesTab>> GetAllTabsAsync()
        {
            IEnumerable<Tab> _tabs = await _tabRepo.GetAllTabsAsync();
            List<Tab> tabs = new List<Tab>();

            foreach (Tab _tab in _tabs)
            {
                tabs.Add(await GetTabWithOrderItemsAsync(_tab));
            }

            return tabs;
        }

        public async Task<SalesTab?> GetTabByIdAsync(int id)
        {
            Tab? tab = await _tabRepo.GetTabByIdAsync(id);

            if (tab != null)
            {
                tab = await GetTabWithOrderItemsAsync(tab);
            }

            return null;
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

