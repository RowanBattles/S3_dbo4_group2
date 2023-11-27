using System;

namespace Models
{
	public class Account
	{
		public int AccountId { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public string? Email { get; set; }

		public int RoleId { get; set; }
	}
}

