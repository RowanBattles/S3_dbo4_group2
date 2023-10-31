using System;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class CategoryRepository
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
    }
}

