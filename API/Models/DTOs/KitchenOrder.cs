using System;

namespace Models.DTOs
{
	public class KitchenOrder
	{
        public KitchenOrder(Order order)
        {
            List<KitchenOrderItem> barOrderItems = new List<KitchenOrderItem>();
            foreach (OrderItem orderItem in order.OrderItems)
            {
                KitchenOrderItem barOrderItem = new KitchenOrderItem();
                barOrderItem.MenuItemId = orderItem.MenuItemId;
                barOrderItem.ItemName = orderItem.MenuItem.ItemName;
                barOrderItem.Quantity = orderItem.Quantity;

                barOrderItems.Add(barOrderItem);
            }

            this.OrderId = order.OrderId;
            this.TabId = order.TabId;
            this.Status = order.Status;
            this.Notes = order.Notes;
            this.DateTime = order.DateTime;
            this.OrderItems = barOrderItems;
        }

        public int OrderId { get; set; }

        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<KitchenOrderItem> OrderItems { get; set; } = new List<KitchenOrderItem>();
    }
}

