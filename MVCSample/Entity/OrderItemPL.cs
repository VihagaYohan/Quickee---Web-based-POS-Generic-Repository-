using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample.Entity
{
	public class OrderItemPL
	{
		public int OrderItemId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public decimal LineTotal { get; set; }
	}
}
