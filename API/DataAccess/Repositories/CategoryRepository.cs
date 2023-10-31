using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Contract_Data_Bussiness.Interfaces;

namespace DataAccess.Repositories
{
	public class CategoryRepository : ICategoryRepository
    {
		private readonly MenuMastersDbContext dbContext;

        public CategoryRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await dbContext.Categories.ToListAsync();
		}

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await dbContext.Categories.FindAsync(id);
        }

		public async Task<bool> CreateCategoryAsync(Category category)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UpdateCategoryAsync(Category category)
		{
            throw new NotImplementedException();
        }

		public async Task<bool> DeleteCategoryAsync(int id)
		{
            throw new NotImplementedException();
        }
    }
}

