using System;

namespace Models.DTOs
{
	public class KitchenOrder
	{
        public int OrderId { get; set; }

        public int TabId { get; set; }

        // TODO: get from tab id
        public int? TableNumber { get; set; }

        public string Status { get; set; }

        public string? Notes { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<KitchenOrderItem> OrderItems { get; set; } = new List<KitchenOrderItem>();
    }
}

