using Bussiness;
using Contract_API_Bussiness.Interfaces;

namespace Bussiness_Factory
{
    public class BussinessFactory
    {
        static public ICategoryComponent GetCategoryComponent()
        {
            return new CategoryComponent();
        }

        static public IMenuItemComponent GetMenuItemComponent()
        {
            return new MenuItemComponent();
        }

        static public IOrderComponent GetOrderComponent()
        {
            return new OrderComponent();
        }

        static public ITabComponent GetTabComponent()
        {
            return new TabComponent();
        }
    }
}

 