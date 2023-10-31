using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using DataAccess_Factory;
using Models;

namespace Bussiness
{
    public class CategoryComponent : ICategoryComponent
	{
        private readonly ICategoryRepository _repo;

		public CategoryComponent()
		{
            _repo = DataAccessFactory.GetCategoryRepository();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _repo.GetCategoryByIdAsync(id);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            return await _repo.CreateCategoryAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            return await _repo.UpdateCategoryAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _repo.DeleteCategoryAsync(id);
        }
    }
}

