using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample.Entity
{
	public class ProductPL
	{
		[Key]
		public int ProductId { get; set; }

		[Required(ErrorMessage ="Product name required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Product description required")]
		public string Description { get; set; }

		[Required (ErrorMessage = "Number of product quantity is required")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Product unit price is required")]
		public decimal UnitPrice { get; set; }
		public bool Availability { get; set; }
		public int QuantityToBeAdd { get; set; }
	}
}
