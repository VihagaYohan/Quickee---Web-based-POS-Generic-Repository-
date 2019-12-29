using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.Exceptions
{
	public class OrderNotFoundException : Exception
	{
		public OrderNotFoundException() : base("Requested order not found ")
		{

		}
	}
}
