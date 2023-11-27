using System;
using DataLayer_MenuAPI;
using DataLayer_MenuAPI.Repos;
using DateLayer_Bussiness_Contract;

namespace DataLayer_Factory
{
	public class DateLayerFactory
	{
		private static readonly MenuAPIDBContext MenuAPIDB = new MenuAPIDBContext();

		public static ICategoryDAL GetCategoryDAL()
		{
			return new CategoryRepository(MenuAPIDB);
		}

		public static IOrdersDAL GetOrdersDAL()
		{
			return new OrderRepository(MenuAPIDB);
		}

		public static IMenuItemDAL GetMenuItemDAL()
		{
			return new MenuItemRepository(MenuAPIDB);
		}

		public static ITabDAL GetTabDAL()
		{
			return new TabRepository(MenuAPIDB);
		}
	}
}

