using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample.Entity
{
	public class CustomerPL
	{
		[Key]
		public int CustomerId { get; set; }

		[Required(ErrorMessage ="Please enter first name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage ="Please enter last name")]
		public string LastName { get; set; }
		
		[Required(ErrorMessage ="Please enter e-mail address")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		public string FullName 
		{
			get { return FirstName + " " + LastName; }
		}
	}
}
