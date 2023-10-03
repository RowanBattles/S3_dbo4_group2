using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		[Required]
		[StringLength(100)]
		public string CategoryName { get; set; }

		[Required]
		public int Type { get; set; }

		public ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();
	}
}

