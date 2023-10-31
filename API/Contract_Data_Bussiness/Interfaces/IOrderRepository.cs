using System;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface IOrderRepository
	{
        Task<IEnumerable<Role>> GetAllRolesAsync();


    }
}

