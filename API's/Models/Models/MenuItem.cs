using System;

namespace Models
{
	public class MenuItem
    {
		public int MenuItemId { get; set; }

		public string ItemName { get; set; }

		public string? ItemDescription_Short { get; set; }

        public string? ItemDescription_Long { get; set; }

        public decimal ItemPrice { get; set; }

		public int? ItemStock { get; set; }

		public int CategoryId { get; set; }

		public Category? Category { get; set; } = null!;

        public string? ImageURL { get; set; }

		public string? DietaryInfo { get; set; }

		public string? Ingredients { get; set; }
    }
}

