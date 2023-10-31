using Bussiness;
using Contract_API_Bussiness.Interfaces;

namespace Bussiness_Factory;
public class Bussiness_Factory
{
    static public IMenuComponent GetMenuComponent()
    {
        return new MenuComponent();
    }
    static public IOrderComponent GetOrderComponent()
    {
        return new OrderComponent();
    }
    static public IOrderItemComponent GetOrderItemComponent()
    {
        return new OrderItemComponent();
    }
    static public ITabComponent GetTabComponent()
    {
        return new TabComponent();
    }
    static public ICategoryComponent GetCategoryComponent()
    {
        return new CategoryComponent();
    }
}

 