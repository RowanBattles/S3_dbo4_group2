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
			try
			{
				await dbContext.Categories.AddAsync(category);
				await dbContext.SaveChangesAsync();

				return true;
			}
            catch
			{
				return false;
			}
		}

		public async Task<bool> UpdateCategoryAsync(Category category)
		{
            try
            {
                Category? original = await GetCategoryByIdAsync(category.CategoryId);

                if (original == null) return false;

                dbContext.Entry(original).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

		public async Task<bool> DeleteCategoryAsync(int id)
		{
            try
            {
                Category? original = await GetCategoryByIdAsync(id);

                if (original == null) return false;

                dbContext.Categories.Remove(original);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

