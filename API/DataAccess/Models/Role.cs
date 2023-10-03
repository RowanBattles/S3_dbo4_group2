using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
	public class Role
	{
		[Key]
		public int RoleId { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(400)]
		public string Description { get; set; }

		public ICollection<Account> Accounts { get; } = new List<Account>();
	}
}

