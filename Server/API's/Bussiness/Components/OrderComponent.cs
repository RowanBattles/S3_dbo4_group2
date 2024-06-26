﻿using System.Threading;
using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;
using Models.DTOs;
using Models.Enums;

namespace Bussiness.Components
{
    public class OrderComponent : IOrderComponent
	{
        private readonly IOrderRepository _orderRepo;
        private readonly ITabRepository _tabRepo;

		public OrderComponent(IOrderRepository orderRepository, ITabRepository tabRepository)
		{
            _orderRepo = orderRepository;
            _tabRepo = tabRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllKitchenOrdersAsync()
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersByTypeAsync(OrderType.Kitchen);
            List<KitchenOrder> kitchenOrders = new List<KitchenOrder>();

            foreach (Order order in orders)
            {
                if (order.OrderItems.Count > 0 && order.StatusKitchen != OrderStatus.Completed)
                {
                    Tab? tab = await _tabRepo.GetTabByIdAsync(order.TabId);

                    KitchenOrder kitchenOrder = new KitchenOrder(order);
                    kitchenOrder.TableNumber = tab != null ? tab.TableNumber : -1;

                    kitchenOrders.Add(kitchenOrder);
                }
            }

            return kitchenOrders;
        }

        public async Task<IEnumerable<KitchenOrder>> GetAllBarOrdersAsync()
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllOrdersByTypeAsync(OrderType.Bar);
            List<KitchenOrder> barOrders = new List<KitchenOrder>();

            foreach (Order order in orders)
            {
                if (order.OrderItems.Count > 0 && order.StatusBar != OrderStatus.Completed)
                {
                    Tab? tab = await _tabRepo.GetTabByIdAsync(order.TabId);

                    KitchenOrder barOrder = new KitchenOrder(order);
                    barOrder.TableNumber = tab != null ? tab.TableNumber : -1;

                    barOrders.Add(barOrder);
                }
            }

            return barOrders;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepo.GetOrderByIdAsync(id);
        }

        public async Task<Order?> CreateOrderAsync(PostOrder postOrder)
        {
            // First lets try to get an open tab with the given tablenumber
            Tab? tab = await _tabRepo.GetOpenTabWithTableNumberAsync(postOrder.TableNumber);

            // If it doesnt exist, make a new one
            if(tab == null)
            {
                tab = await _tabRepo.CreateTabAsync(new Tab() { TableNumber = postOrder.TableNumber });
                // If something went wrong with creating, well return null
                if (tab == null) { return null; }
            }

            Order order = new Order()
            {
                TabId = tab.TabId,
                StatusKitchen = OrderStatus.Pending,
                StatusBar = OrderStatus.Pending,
                DateTime = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };

            foreach (PostOrderItem postOrderItem in postOrder.orderItems)
            {
                OrderItem orderItem = new OrderItem()
                {
                    MenuItemId = postOrderItem.MenuItemId,
                    Notes = postOrderItem.Notes,
                    Quantity = postOrderItem.Quantity
                };
                order.OrderItems.Add(orderItem);
            }

            return await _orderRepo.CreateOrderAsync(order);
        }

        public async Task<OrderItem?> AddItemToOrderAsync(OrderItem orderItem)
        {
            return await _orderRepo.AddItemToOrderAsync(orderItem);
        }

        public async Task<Order?> UpdateOrderAsync(Order order)
        {
            return await _orderRepo.UpdateOrderAsync(order);
        }

        public async Task<OrderItem?> UpdateItemFromOrderAsync(PatchOrderItem orderItem)
        {
            return await _orderRepo.UpdateItemFromOrderAsync(orderItem.OrderItemId, orderItem.Quantity);
        }

        public async Task<OrderStatus?> UpdateKitchenOrderStateAsync(int id)
        {
            Order? order = await this.GetOrderByIdAsync(id);

            if (order == null) return null;

            // If its completed, cycle back to pending for the next state
            if(order.StatusKitchen == OrderStatus.Completed)
            {
                order.StatusKitchen = OrderStatus.Pending;
            } else
            {
                // Otherwise go to the next state
                order.StatusKitchen = (OrderStatus)((int)order.StatusKitchen + 1);
            }

            order = await this.UpdateOrderAsync(order);

            return order != null ? order.StatusKitchen : null;
        }

        public async Task<OrderStatus?> UpdateBarOrderStateAsync(int id)
        {
            Order? order = await this.GetOrderByIdAsync(id);

            if (order == null) return null;

            // If its completed, cycle back to pending for the next state
            if (order.StatusBar == OrderStatus.Completed)
            {
                order.StatusBar = OrderStatus.Pending;
            }
            else
            {
                // Otherwise go to the next state
                order.StatusBar = (OrderStatus)((int)order.StatusBar + 1);
            }

            order = await this.UpdateOrderAsync(order);

            return order != null ? order.StatusBar : null;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepo.DeleteOrderAsync(id);
        }

        public async Task<bool> RemoveItemFromOrderAsync(int id)
        {
            return await _orderRepo.RemoveItemFromOrderAsync(id);
        }
    }
}

