using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IOrderRepository
	{
        Task<IEnumerable<Role>> GetAllRolesAsync();

        Task<Role?> GetRoleByIdAsync(int id);
    }
}

