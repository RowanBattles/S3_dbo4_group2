using System;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class RoleRepository
	{
		private readonly MenuMastersDbContext dbContext;

        public RoleRepository(MenuMastersDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

		public async Task<IEnumerable<Role>> GetAllRolesAsync()
		{
			return await dbContext.Roles.ToListAsync();
		}

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await dbContext.Roles.FindAsync(id);
        }
    }
}

