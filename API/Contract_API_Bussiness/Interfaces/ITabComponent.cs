using System;
using DataAccess.Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ITabComponent
	{
        public List<MenuItem> GetTabs();

        public MenuItem GetTab();

        public bool CreateTab();

        public bool UpdateTab();

        public bool DeleteTab();
    }
}

