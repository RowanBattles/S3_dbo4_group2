using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ITabComponent
	{
        Task<List<MenuItem>> GetTabs();

        Task<MenuItem> GetTab();

        Task<bool> CreateTab();

        Task<bool> UpdateTab();

        Task<bool> DeleteTab();
    }
}

