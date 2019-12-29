using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.Exceptions
{
	public class ProductNotAvailableException :Exception
	{
		public ProductNotAvailableException() : base("Product not available in stock")
		{

		}
	}
}
