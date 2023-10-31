using Contract_API_Bussiness.Interfaces;
using Models;

namespace Bussiness;
public class MenuComponent : IMenuComponent
{
    async Task<bool> IMenuComponent.CreateMenuItem()
    {
    }

    async Task<bool> IMenuComponent.DeleteMenuItem()
    {
        throw new NotImplementedException();
    }

    async Task<MenuItem> IMenuComponent.GetMenuItem()
    {
        throw new NotImplementedException();
    }

    public async Task<List<MenuItem>> IMenuComponent.GetMenuItems()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IMenuComponent.UpdateMenuItem()
    {
        throw new NotImplementedException();
    }
}
