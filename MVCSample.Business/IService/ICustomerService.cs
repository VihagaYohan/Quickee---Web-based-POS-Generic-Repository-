using MVCSample.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.IService
{
	public interface ICustomerService
	{
		IEnumerable<CustomerBL> GetAll();
		void AddCustomer(CustomerBL customer);
		CustomerBL FindById(int id);
		CustomerBL UpdateCustomer(CustomerBL customer);
	}
}
