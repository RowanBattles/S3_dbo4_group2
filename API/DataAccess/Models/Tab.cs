using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class Tab
	{
		[Key]
		public int TabId { get; set; }

		[Required]
		public int TableNumber { get; set; }

		public decimal TabTotal { get; set; }

		public ICollection<Order> Orders { get; } = new List<Order>();
	}
}

