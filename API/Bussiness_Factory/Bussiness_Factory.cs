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
    static public IMenuComponent GetContact()
    {
        return new MenuComponent();
    }
    static public IMenuComponent GetContact()
    {
        return new MenuComponent();
    }
    static public IMenuComponent GetContact()
    {
        return new MenuComponent();
    }
    static public IMenuComponent GetContact()
    {
        return new MenuComponent();
    }
}

