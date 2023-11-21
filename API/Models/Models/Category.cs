using System;
using Models.Enums;

namespace Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public OrderType Type { get; set; }
	}
}

