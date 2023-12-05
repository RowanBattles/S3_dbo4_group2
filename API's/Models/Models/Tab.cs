using System;

namespace Models
{
	public class Tab
	{
		public int TabId { get; set; }

		public int TableNumber { get; set; }

		public decimal? TabTotal { get; set; }

		public decimal? PaidCash { get; set; }

		public decimal? PaidPIN { get; set; }

		public bool Paid { get { return (this.PaidCash + this.PaidPIN) >= this.TabTotal; } }
	}
}

