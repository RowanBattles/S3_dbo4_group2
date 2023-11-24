using System;
using Models.Enums;

namespace Models.DTOs
{
	public class KitchenOrder
	{
        public KitchenOrder() { }

        public KitchenOrder(Order order)
        {
            List<KitchenOrderItem> kitchenOrderItems = new List<KitchenOrderItem>();
            foreach (OrderItem orderItem in order.OrderItems)
            {
                KitchenOrderItem kitchenOrderItem = new KitchenOrderItem();
                kitchenOrderItem.MenuItemId = orderItem.MenuItemId;
                kitchenOrderItem.ItemName = orderItem.MenuItem.ItemName;
                kitchenOrderItem.Notes = orderItem.Notes;
                kitchenOrderItem.Quantity = orderItem.Quantity;

                kitchenOrderItems.Add(kitchenOrderItem);
            }

            this.OrderId = order.OrderId;
            this.TabId = order.TabId;
            this.Status = order.Status;
            this.DateTime = order.DateTime;
            this.OrderItems = kitchenOrderItems;
        }

        public int OrderId { get; set; }

        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<KitchenOrderItem> OrderItems { get; set; } = new List<KitchenOrderItem>();
    }
}

