using System;
using MenuAPI_Models;

namespace Bussiness_API_Contract
{
	public interface ICategoryComponent
	{
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(int id);
    }
}

