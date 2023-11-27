using System;
using Bussines_MenuAPI;
using Bussiness_API_Contract;

namespace Bussiness_API_Factory
{
	public class BussinessFactory
	{
		public static IMenuItemComponent GetMenuItemComponent()
		{
			return new MenuItemComponent();
		}
	}
}

