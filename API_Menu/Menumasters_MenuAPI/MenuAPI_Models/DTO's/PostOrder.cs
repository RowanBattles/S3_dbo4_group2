using System;
namespace MenuAPI_Models.DTOs
{
	public class PostOrder
	{
        public int TabId { get; set; }

        public IEnumerable<PostOrderItem> orderItems { get; set; } = new List<PostOrderItem>();
    }
}

