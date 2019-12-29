using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.Exceptions
{
	public class NotEnoughQuantityException : Exception
	{
		public NotEnoughQuantityException() :base("Not enough quantity")
		{

		}
	}
}
