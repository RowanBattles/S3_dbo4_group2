﻿using System;

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
            this.Paid = tab.Paid;
        }

        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public decimal? TabTotal { get; set; }

        public decimal? PaidCash { get; set; }

        public decimal? PaidPIN { get; set; }

        public decimal? MoneyRemaining { get { return this.TabTotal - (this.PaidCash + this.PaidPIN); } }

        public bool Paid { get; set; }

        public ICollection<SalesOrderItem> OrderItems { get; set; } = new List<SalesOrderItem>();
    }
}
