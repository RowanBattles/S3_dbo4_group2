using System;
using DataAccess.Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ICategoryComponent
	{
        public List<MenuItem> GetCategories();

        public MenuItem GetCategory();

        public bool CreateCategory();

        public bool UpdateCategory();

        public bool DeleteCategory();
    }
}

