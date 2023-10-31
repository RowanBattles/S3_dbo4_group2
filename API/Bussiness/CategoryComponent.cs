using System;
using Contract_API_Bussiness.Interfaces;
using Contract_Data_Bussiness.Interfaces;
using Models;

namespace Bussiness
{
    public class CategoryComponent : ICategoryComponent
	{
        private readonly ICategoryRepository _repo;

		public CategoryComponent()
		{
            MenuMastersDbContext dbContext = new MenuMastersDbContext();
            _repo = new CategoryRepository(dbContext);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _repo.GetCategoryByIdAsync(id);
        }

        public bool CreateCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategoryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

