using System;
using DataAccess.Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface IOrderComponent
	{
        public List<MenuItem> GetOrders();

        public MenuItem GetOrder();

        public bool CreateOrder();

        public bool UpdateOrder();

        public bool DeleteOrder();
    }
}

