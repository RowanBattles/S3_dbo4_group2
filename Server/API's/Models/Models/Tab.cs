using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Tab
	{
		public int TabId { get; set; }

		public int TableNumber { get; set; }

		public decimal TabTotal {
			get { return Orders.SelectMany(order => order.OrderItems).Sum(orderItem => orderItem.MenuItem?.ItemPrice ?? 0); }
			set { }
		}

		public decimal PaidCash { get; set; }

		public decimal PaidPIN { get; set; }

		[NotMapped]
        public decimal MoneyRemaining { get { return this.TabTotal - (this.PaidCash + this.PaidPIN); } }

		[NotMapped]
        public bool Paid { get { return this.MoneyRemaining <= 0; } }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

