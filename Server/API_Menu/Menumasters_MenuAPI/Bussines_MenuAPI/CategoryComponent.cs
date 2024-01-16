using System;
using Bussiness_API_Contract;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;

namespace Bussines_MenuAPI
{
    public class CategoryComponent : ICategoryComponent
	{
        private readonly ICategoryDAL _repo;

        public CategoryComponent(ICategoryDAL repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _repo.GetCategoryByIdAsync(id);
        }
    }
}

