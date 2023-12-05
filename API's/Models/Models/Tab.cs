using System;

namespace Models
{
	public class Tab
	{
		public int TabId { get; set; }

		public int TableNumber { get; set; }

		public decimal? TabTotal { get; set; }

		public bool Paid { get; set; }
	}
}

