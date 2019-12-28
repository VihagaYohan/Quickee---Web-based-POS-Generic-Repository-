using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Model
{
	public class Order
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
