using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class Account
	{
		[Key]
		public int AccountId { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[StringLength(200)]
		public string Password { get; set; }

		[StringLength(200)]
		public string Email { get; set; }

		[Required]
		public int RoleId { get; set; }
		public Role Role { get; set; } = null!;
	}
}

