using System;

namespace MenuMasters_API.DTOs
{
	public class SalesOrder
	{
        public int OrderId { get; set; }

        public int TabId { get; set; }

        // TODO: get from tab id
        public int TableNumber { get; set; }

        // TODO: get from tab id
        public decimal TabTotal { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<SalesOrderItem> OrderItems { get; } = new List<SalesOrderItem>();
    }
}

