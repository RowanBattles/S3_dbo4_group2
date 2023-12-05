using System;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer_MenuAPI.Repos
{
	public class CategoryDAL : ICategoryDAL
	{
        private readonly MenuAPIDbContext dbContext;

        public CategoryDAL(MenuAPIDbContext _dbContext)
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
    }
}

