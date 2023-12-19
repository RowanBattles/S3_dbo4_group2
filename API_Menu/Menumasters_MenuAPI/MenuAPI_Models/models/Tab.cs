using System;
namespace MenuAPI_Models
{
	public class Tab
	{
        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public decimal? TabTotal { get; set; }

        public decimal Paid_cash { get; set; }

        public decimal Paid_pin { get; set; }
    }
}

