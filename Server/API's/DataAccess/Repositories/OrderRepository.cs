﻿using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Contract_Data_Bussiness.Interfaces;
using Models.Enums;

namespace DataAccess.Repositories
{
	public class OrderRepository : IOrderRepository
    {
		private readonly MenuMastersDbContext dbContext;

        public OrderRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<Order>> GetAllOrdersAsync()
		{
			return await dbContext.Orders.Include(e => e.OrderItems).ThenInclude(e => e.MenuItem).ToListAsync();
		}

        public async Task<IEnumerable<Order>> GetAllOrdersByTypeAsync(OrderType type)
        {
            return await dbContext.Orders.Include(e => e.OrderItems).ThenInclude(e => e.MenuItem).ThenInclude(e => e.Category)
                .Select(order => new Order
                {
                    OrderId = order.OrderId,
                    TabId = order.TabId,
                    StatusKitchen = order.StatusKitchen,
                    StatusBar = order.StatusBar,
                    DateTime = order.DateTime,
                    OrderItems = order.OrderItems.Where(orderItem => orderItem.MenuItem.Category.Type == type).ToList()
                }).ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await dbContext.Orders.Include(e => e.OrderItems).ThenInclude(e => e.MenuItem).FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<Order?> CreateOrderAsync(Order order)
        {
            try
            {
                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();

                return order;
            }
            catch
            {
                return null;
            }
        }

        public async Task<OrderItem?> AddItemToOrderAsync(OrderItem orderItem)
        {
            try
            {
                await dbContext.OrderItems.AddAsync(orderItem);
                await dbContext.SaveChangesAsync();

                return orderItem;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Order?> UpdateOrderAsync(Order order)
        {
            try
            {
                Order? original = await GetOrderByIdAsync(order.OrderId);

                if (original == null) return null;

                dbContext.Entry(original).CurrentValues.SetValues(order);
                await dbContext.SaveChangesAsync();

                return order;
            }
            catch
            {
                return null;
            }
        }

        public async Task<OrderItem?> UpdateItemFromOrderAsync(int orderItemId, int quantity)
        {
            try
            {
                OrderItem? original = await dbContext.OrderItems.FindAsync(orderItemId);

                if (original == null) return null;

                if (quantity <= 0) {
                    bool success = await RemoveItemFromOrderAsync(orderItemId);
                    return success ? new OrderItem() : null;
                }

                original.Quantity = quantity;
                await dbContext.SaveChangesAsync();

                return original;
            }
            catch
            {
                return null;
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
    }
}

