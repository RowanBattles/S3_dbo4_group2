using DataAccess;
using DataAccess.Repositories;
using Contract_Data_Bussiness.Interfaces;

namespace DataAccess_Factory
{
    public class DataAccessFactory
    {
        private static readonly MenuMastersDbContext dbContext = new MenuMastersDbContext();

        public static ICategoryRepository GetCategoryRepository()
        {
            return new CategoryRepository(dbContext);
        }

        public static IMenuItemRepository GetMenuItemRepository()
        {
            return new MenuItemRepository(dbContext);
        }

        public static IOrderRepository GetOrderRepository()
        {
            return new OrderRepository(dbContext);
        }

        public static ITabRepository GetTabRepository()
        {
            return new TabRepository(dbContext);
        }
    }
}

