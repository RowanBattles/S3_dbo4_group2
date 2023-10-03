using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class MenuItem
    {
		[Key]
		public int MenuItemId { get; set; }

		[Required]
		[StringLength(100)]
		public string ItemName { get; set; }

		[StringLength(400)]
		public string ItemDescription { get; set; }

		[Required]
		public decimal ItemPrice { get; set; }

		public int ItemStock { get; set; }

		[Required]
		public int CategoryId { get; set; }
		public Category Category { get; set; } = null!;

        //public byte[] Photo { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}

