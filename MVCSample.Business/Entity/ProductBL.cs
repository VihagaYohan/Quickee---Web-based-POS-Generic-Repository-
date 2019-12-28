using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCSample.Business.Entity
{
	public class ProductBL
	{
		[Key]
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public bool Availability { get; set; }
	}
}
