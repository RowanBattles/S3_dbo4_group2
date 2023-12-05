using System;

namespace Models
{
	public class Tab
	{
		public int TabId { get; set; }

		public int TableNumber { get; set; }

		public decimal? TabTotal {
			get { return Orders.SelectMany(order => order.OrderItems).Sum(orderItem => orderItem.MenuItem?.ItemPrice ?? 0); }
			set { }
		}

		public decimal? PaidCash { get; set; }

		public decimal? PaidPIN { get; set; }

		public bool Paid { get { return (this.PaidCash + this.PaidPIN) >= this.TabTotal; } set { } }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

