using Microsoft.EntityFrameworkCore;
using MVCSample.Data.Interface;
using MVCSample.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly QuickeeContext context;
		private GenericRepository<Customer> customerRepository;

		public UnitOfWork(DbContext context)
		{
			this.context = (QuickeeContext)context;
		}

		public GenericRepository<Customer> CustomerRepository 
		{
			get 
			{
				if (this.customerRepository == null)
				{
					this.customerRepository = new GenericRepository<Customer>(context);
				}
				return customerRepository;
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
