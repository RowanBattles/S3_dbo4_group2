using System;

namespace Models
{
	public class Order
	{
		public int OrderId { get; set; }

		public int TabId { get; set; }

		public int ItemCount { get; set; }

		public ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();
	}
}

