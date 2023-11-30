using System;
using Bussines_MenuAPI;
using Bussiness_API_Contract;

namespace Bussiness_API_Factory
{
	public class BussinessFactory
	{
		public static ICategoryComponent GetCategoryComponent()
		{
			return new CategoryComponent();
		}

		public static IMenuItemComponent GetMenuItemComponent()
		{
			return new MenuItemComponent();
		}

		public static IOrderComponent GetOrderComponent()
		{
			return new OrderComponent();
		}

		public static ITabComponent GetTabComponent()
		{
			return new TabComponent();
		}
	}
}

