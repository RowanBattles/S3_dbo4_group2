using System;
using Models.Enums;

namespace Models.DTOs
{
	public class SalesTab
	{
        public SalesTab(Tab tab)
        {
            this.TabId = tab.TabId;
            this.TableNumber = tab.TableNumber;
            this.TabTotal = tab.TabTotal;
            this.PaidCash = tab.PaidCash;
            this.PaidPIN = tab.PaidPIN;
            this.MoneyRemaining = tab.MoneyRemaining;
            this.Paid = tab.Paid;
            this.Request = tab.Request;
        }

        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public DateTime Date { get; set; }

        public decimal TabTotal { get; set; }

        public decimal PaidCash { get; set; }

        public decimal PaidPIN { get; set; }

        public decimal MoneyRemaining { get; set; }

        public bool Paid { get; set; }

        public RequestType Request { get; set; }

        public ICollection<SalesOrderItem> OrderItems { get; set; } = new List<SalesOrderItem>();
    }
}

