using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample.Entity
{
	public class OrderPL
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public CustomerPL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItemPL> OrderItems { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
