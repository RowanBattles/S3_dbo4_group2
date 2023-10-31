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

        List<Category> ICategoryComponent.GetCategories()
        {
            throw new NotImplementedException();
        }

        Category ICategoryComponent.GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}

