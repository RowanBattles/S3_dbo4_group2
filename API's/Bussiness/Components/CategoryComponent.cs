using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;

namespace Bussiness.Components
{
    public class CategoryComponent : ICategoryComponent
	{
        private readonly ICategoryRepository _categoryRepo;

		public CategoryComponent(ICategoryRepository categoryRepository)
		{
            _categoryRepo = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepo.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepo.GetCategoryByIdAsync(id);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            return await _categoryRepo.CreateCategoryAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepo.UpdateCategoryAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepo.DeleteCategoryAsync(id);
        }
    }
}

