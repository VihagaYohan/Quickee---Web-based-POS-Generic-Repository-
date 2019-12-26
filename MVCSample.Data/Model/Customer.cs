using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Model
{
	public class Customer
	{
		public int CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}	
	}
}
