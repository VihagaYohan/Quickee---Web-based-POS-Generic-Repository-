using MVCSample.Data.Model;
using MVCSample.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Interface
{
	public interface IUnitOfWork
	{
		GenericRepository<Customer> CustomerRepository { get; }
		void Save();
	}
}
