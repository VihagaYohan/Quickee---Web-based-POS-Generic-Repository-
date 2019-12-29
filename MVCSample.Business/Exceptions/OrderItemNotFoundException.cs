using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.Exceptions
{
	public class OrderItemNotFoundException:Exception
	{
		public OrderItemNotFoundException():base("Please add atleaset one product item inorder to procced with purchase process")
		{

		}
	}
}
