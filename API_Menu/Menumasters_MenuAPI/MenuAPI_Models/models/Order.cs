using System;
using MenuAPI_Models.enums;

namespace MenuAPI_Models
{
	public class Order
	{
        public int OrderId { get; set; }

        public int TabId { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

