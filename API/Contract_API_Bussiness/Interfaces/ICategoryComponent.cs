using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ICategoryComponent
	{
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();

        public Task<Category> GetCategoryByIdAsync(int id);

        public bool CreateCategoryAsync();

        public bool UpdateCategoryAsync();

        public bool DeleteCategoryAsync();
    }
}

