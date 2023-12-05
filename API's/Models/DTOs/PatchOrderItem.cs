using System;
namespace Models.DTOs
{
	public class PatchOrderItem
	{
        public int OrderItemId { get; set; }

        public string? Notes { get; set; }

        public int Quantity { get; set; }
    }
}

