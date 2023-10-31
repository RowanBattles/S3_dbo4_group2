using System;
using Models;

namespace Contract_API_Bussiness.Interfaces
{
	public interface ICategoryComponent
	{
        Task<List<Category>> GetCategories();

        Task<Category> GetCategory();

        Task<bool> CreateCategory();

        Task<bool> UpdateCategory();

        Task<bool> DeleteCategory();
    }
}

