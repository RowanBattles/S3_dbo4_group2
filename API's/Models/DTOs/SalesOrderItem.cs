using System;

namespace Models.DTOs
{
	public class SalesOrderItem
	{
        public int MenuItemId { get; set; }

        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }

        public int Quantity { get; set; }
    }
}

