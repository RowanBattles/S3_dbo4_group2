using System;
namespace MenuAPI_Models
{
	public class Order
	{
        public int OrderId { get; set; }

        public int TabId { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}

