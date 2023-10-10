using System;

namespace DataAccess.Models
{
	public class MenuItem
    {
		public int MenuItemId { get; set; }

		public string ItemName { get; set; }

		public string ItemDescription { get; set; }

		public decimal ItemPrice { get; set; }

		public int ItemStock { get; set; }

		public int CategoryId { get; set; }

        //public byte[] Photo { get; set; }
    }
}

