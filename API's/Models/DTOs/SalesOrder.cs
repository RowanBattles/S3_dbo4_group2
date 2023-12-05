using System;

namespace Models.DTOs
{
	public class SalesOrder
	{
        public SalesOrder() { }

        public SalesOrder(Order order)
        {
            List<SalesOrderItem> salesOrderItems = new List<SalesOrderItem>();
            foreach (OrderItem orderItem in order.OrderItems)
            {
                SalesOrderItem salesOrderItem = new SalesOrderItem();
                salesOrderItem.MenuItemId = orderItem.MenuItemId;
                salesOrderItem.ItemName = orderItem.MenuItem.ItemName;
                salesOrderItem.ItemPrice = orderItem.MenuItem.ItemPrice;
                salesOrderItem.Quantity = orderItem.Quantity;

                salesOrderItems.Add(salesOrderItem);
            }

            this.OrderId = order.OrderId;
            this.TabId = order.TabId;
            this.DateTime = order.DateTime;
            this.OrderItems = salesOrderItems;
        }

        public int OrderId { get; set; }

        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public decimal? TabTotal { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<SalesOrderItem> OrderItems { get; set; } = new List<SalesOrderItem>();
    }
}

