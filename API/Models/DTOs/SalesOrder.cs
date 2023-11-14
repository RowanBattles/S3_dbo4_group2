using System;

namespace Models.DTOs
{
	public class SalesOrder
	{
        public int OrderId { get; set; }

        public int TabId { get; set; }

        public int TableNumber { get; set; }

        public decimal TabTotal { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<SalesOrderItem> OrderItems { get; set; } = new List<SalesOrderItem>();
    }
}

