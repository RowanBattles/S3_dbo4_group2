using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class OrderItem
	{
		[Key]
		public int OrderItemId { get; set; }

		[Required]
		public int OrderId { get; set; }

		[Required]
		public int ItemId { get; set; }
	}
}

