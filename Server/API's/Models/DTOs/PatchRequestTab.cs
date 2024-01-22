using System;
using Models.Enums;

namespace Models.DTOs
{
	public class PatchRequestTab
	{
		public int TabId { get; set; }

		public RequestType Request { get; set; }

    }
}

