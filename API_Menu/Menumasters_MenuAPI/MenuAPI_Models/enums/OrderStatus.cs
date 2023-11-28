using System;
namespace MenuAPI_Models.enums
{
	public class OrderStatus
	{
		public enum OrderStatus : byte
		{
            Pending = 0,
			Active = 1,
			Completed = 2

        }
	}
}

