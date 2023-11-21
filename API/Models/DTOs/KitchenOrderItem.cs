using System;

namespace Models.DTOs
{
	public class KitchenOrderItem
	{
        public int MenuItemId { get; set; }

        public string ItemName { get; set; }

        public string? Notes { get; set; }

        public int Quantity { get; set; }
    }
}

