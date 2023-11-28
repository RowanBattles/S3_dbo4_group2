using System;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;
using MenuAPI_Models.enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer_MenuAPI.Repos
{
	public class OrderRepository : IOrdersDAL
	{
        private readonly MenuAPIDBContext dbContext;

        public OrderRepository(MenuAPIDBContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await dbContext.Orders.FindAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            try
            {
                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddItemToOrderAsync(OrderItem orderItem)
        {
            try
            {
                await dbContext.OrderItems.AddAsync(orderItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            try
            {
                Order? original = await GetOrderByIdAsync(order.OrderId);

                if (original == null) return false;

                dbContext.Entry(original).CurrentValues.SetValues(order);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveItemFromOrderAsync(int id)
        {
            try
            {
                OrderItem? original = await dbContext.OrderItems.FindAsync(id);

                if (original == null) return false;

                dbContext.OrderItems.Remove(original);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                Order? original = await GetOrderByIdAsync(id);

                if (original == null) return false;

                dbContext.Orders.Remove(original);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}

