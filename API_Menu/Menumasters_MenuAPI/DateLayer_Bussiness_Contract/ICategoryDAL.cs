using System;
using MenuAPI_Models;

namespace DateLayer_Bussiness_Contract
{
	public interface ICategoryDAL
	{
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(int id);
    }
}

