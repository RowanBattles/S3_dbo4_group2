using System;
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

        public bool CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _repo.GetCategoryByIdAsync(id);
        }

        public bool UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

