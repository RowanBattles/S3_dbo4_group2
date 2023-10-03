using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		[Required]
		public int TabId { get; set; }
		public Tab Tab { get; set; } = null!;

		[Required]
		public int ItemCount { get; set; }

		public ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();
	}
}

