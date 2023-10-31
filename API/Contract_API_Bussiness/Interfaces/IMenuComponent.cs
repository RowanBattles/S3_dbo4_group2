using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IMenuComponent
	{
		Task<List<MenuItem>> GetMenuItems();

		Task<MenuItem> GetMenuItem();

		Task<bool> CreateMenuItem();

		Task<bool> UpdateMenuItem();

		Task<bool> DeleteMenuItem();
	}
}

