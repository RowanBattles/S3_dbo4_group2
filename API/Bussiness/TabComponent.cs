using System;
using Contract_API_Bussiness.Interfaces;
using DataAccess.Models;
using Models;

namespace Bussiness
{
	public class TabComponent : ITabComponent
    {
		public TabComponent()
		{
		}

        public Task<bool> CreateTabAsync(Tab tab)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTabAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tab> GetTabByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tab>> GetTabsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTabAsync(Tab tab)
        {
            throw new NotImplementedException();
        }
    }
}

