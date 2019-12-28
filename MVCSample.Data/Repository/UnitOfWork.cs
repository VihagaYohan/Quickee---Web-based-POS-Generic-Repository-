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
		private GenericRepository<Product> productRepository;
		private GenericRepository<Order> orderRepository;

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

		public GenericRepository<Product> ProductRepository 
		{
			get 
			{
				if (this.productRepository == null) 
				{
					this.productRepository = new GenericRepository<Product>(context);
				}
				return productRepository;
			}
		}

		public GenericRepository<Order> OrderRepository 
		{
			get 
			{
				if (this.orderRepository == null) 
				{
					this.orderRepository = new GenericRepository<Order>(context);
				}
				return orderRepository;
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
