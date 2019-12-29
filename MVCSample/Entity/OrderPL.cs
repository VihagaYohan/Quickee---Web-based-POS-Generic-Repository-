using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample.Entity
{
	public class OrderPL
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }

		[Required(ErrorMessage ="Select an customer from entity")]
		public CustomerPL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public IEnumerable<OrderItemPL> OrderItems { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
