using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IRoleRepository
	{
        Task<IEnumerable<Role>> GetAllRolesAsync();

        Task<Role?> GetRoleByIdAsync(int id);
    }
}

