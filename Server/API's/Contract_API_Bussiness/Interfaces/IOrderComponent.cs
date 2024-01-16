using System;
using Models;
using Models.DTOs;
using Models.Enums;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderComponent
	{
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<IEnumerable<KitchenOrder>> GetAllKitchenOrdersAsync();

        Task<IEnumerable<KitchenOrder>> GetAllBarOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task<Order?> CreateOrderAsync(PostOrder order);

        Task<OrderItem?> AddItemToOrderAsync(OrderItem orderItem);

        Task<Order?> UpdateOrderAsync(Order order);

        Task<OrderItem?> UpdateItemFromOrderAsync(PatchOrderItem orderItem);

        Task<OrderStatus?> UpdateKitchenOrderStateAsync(int id);

        Task<OrderStatus?> UpdateBarOrderStateAsync(int id);

        Task<bool> DeleteOrderAsync(int id);

        Task<bool> RemoveItemFromOrderAsync(int id);
    }
}

