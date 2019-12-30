using MVCSample.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample.ViewModels
{
	public class OrderViewModel
	{
		public IEnumerable<CustomerPL> Customers { get; set; }
		public IEnumerable<ProductPL> Products { get; set; }
		public DateTime OrderDate { get; set; }
		public IEnumerable<OrderItemPL> OrderItems { get; set; }
		
		[Required(ErrorMessage = "Select an customer from viewModel")]
		public CustomerPL Customer { get; set; }
		public ProductPL Product { get; set; }
		public OrderPL Order { get; set; }
	}
}
