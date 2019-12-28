using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Model
{
	public class OrderItem
	{
		public int OrderItemId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public decimal LineTotal { get; set; }
	}
}
