using System;
namespace MenuAPI_Models.DTOs
{
	public class PostOrderItem
	{
        public int MenuItemId { get; set; }

        public string? Notes { get; set; }

        public int Quantity { get; set; }
    }
}

