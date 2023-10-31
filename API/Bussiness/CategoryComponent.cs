using System;
using Contract_API_Bussiness.Interfaces;
using Models;

namespace Bussiness
{
    public class CategoryComponent : ICategoryComponent
	{
		public CategoryComponent()
		{
		}

        public bool CreateCategory()
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory()
        {
            throw new NotImplementedException();
        }
        public bool UpdateCategory()
        {
            throw new NotImplementedException();
        }

        List<Category> ICategoryComponent.GetCategories()
        {
            throw new NotImplementedException();
        }

        Category ICategoryComponent.GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}

