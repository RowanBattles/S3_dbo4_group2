using System;
using DataAccess.Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderItemComponent
	{
        public List<MenuItem> GetOrderItems();

        public MenuItem GetOrderItem();

        public bool CreateOrderItem();

        public bool UpdateOrderItem();

        public bool DeleteOrderItem();
    }
}

