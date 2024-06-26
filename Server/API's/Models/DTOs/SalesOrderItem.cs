﻿using System;

namespace Models.DTOs
{
	public class SalesOrderItem
	{
        public SalesOrderItem(OrderItem orderItem)
        {
            this.OrderItemId = orderItem.OrderItemId;
            this.MenuItemId = orderItem.MenuItemId;
            this.ItemName = orderItem.MenuItem.ItemName;
            this.ItemPrice = orderItem.MenuItem.ItemPrice;
            this.Quantity = orderItem.Quantity;
        }

        public int OrderItemId { get; set; }

        public int MenuItemId { get; set; }

        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }

        public int Quantity { get; set; }
    }
}

