using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ICategoryComponent
	{
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();

        public Task<Category> GetCategoryByIdAsync(int id);

        public bool CreateCategoryAsync(Category category);

        public bool UpdateCategoryAsync(Category category);

        public bool DeleteCategoryAsync(int id);
    }
}

