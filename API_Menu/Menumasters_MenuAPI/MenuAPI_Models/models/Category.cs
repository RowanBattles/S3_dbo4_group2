using System;
namespace MenuAPI_Models
{
	public class Category
	{
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public OrderType Type { get; set; }
    }
}

