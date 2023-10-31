using System;
using DataAccess.Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IMenuComponent
	{
		public List<MenuItem> GetMenuItems();

		public MenuItem GetMenuItem();

		public bool CreateMenuItem();

		public bool UpdateMenuItem();

		public bool DeleteMenuItem();
	}
}

