﻿using System;
using Models;

namespace Contract_Data_Bussiness.Interfaces
{
	public interface ITabRepository
	{
        Task<IEnumerable<Tab>> GetAllTabsAsync();

        Task<Tab?> GetTabByIdAsync(int id);

        Task<Tab?> GetOpenTabWithTableNumberAsync(int tableNumber);

        Task<Tab?> CreateTabAsync(Tab tab);

        Task<Tab?> UpdateTabAsync(Tab tab);

        Task<bool> DeleteTabAsync(int id);
    }
}

