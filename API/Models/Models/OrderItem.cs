using System;

namespace Models
{
	public class OrderItem
	{
		public int OrderItemId { get; set; }

		public int OrderId { get; set; }

		public int MenuItemId { get; set; }
		public MenuItem? MenuItem { get; set; } = null!;

		public int Quantity { get; set; }
	}
}

