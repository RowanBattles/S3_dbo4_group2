using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;
using Models.DTOs;
using Models.Enums;

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

        private async Task<SalesTab> ConvertToSalesTabAsync(Tab tab)
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

            salesTab.Date = tab.Orders.OrderBy(x => x.DateTime).First().DateTime;

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
                salesTabs.Add(await ConvertToSalesTabAsync(tab));
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
                return await ConvertToSalesTabAsync(tab);
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

        public async Task<RequestType?> UpdateRequestTypeAsync(PatchRequestTab requestTab)
        {
            Tab? tab = await this.GetTabByIdAsync(requestTab.TabId);

            if (tab == null) return null;

            if ((int)requestTab.Request > 2 || (int)requestTab.Request < 0) return null;

            tab.Request = requestTab.Request;

            tab = await this.UpdateTabAsync(tab);

            if (tab != null)
            {
                return tab.Request;
            }
            else
            {
                return null;
            }
        }

        public async Task<SalesTab?> PayTab(PayTab payTab)
        {
            Tab? tab = await this.GetTabByIdAsync(payTab.TabId);

            if (tab == null) return null;

            if(payTab.PaidCash != null)
            {
                if (tab.PaidCash == null)
                {
                    tab.PaidCash = 0;
                }

                tab.PaidCash += (decimal)payTab.PaidCash;
            }

            if(payTab.PaidPIN != null)
            {
                if(tab.PaidPIN == null)
                {
                    tab.PaidPIN = 0;
                }

                tab.PaidPIN += (decimal)payTab.PaidPIN;
            }

            tab = await this.UpdateTabAsync(tab);

            if (tab != null)
            {
                return await ConvertToSalesTabAsync(tab);
            } else
            {
                return null;
            }
        }

        public async Task<bool> DeleteTabAsync(int id)
        {
            return await _tabRepo.DeleteTabAsync(id);
        }
    }
}

