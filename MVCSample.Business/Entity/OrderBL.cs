using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.Entity
{
	public class OrderBL
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public CustomerBL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public IEnumerable<OrderItemBL> OrderItems { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
