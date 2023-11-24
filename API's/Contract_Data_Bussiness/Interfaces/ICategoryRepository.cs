using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface ICategoryRepository
	{
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(int id);

        Task<bool> CreateCategoryAsync(Category category);

        Task<bool> UpdateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(int id);
    }
}

