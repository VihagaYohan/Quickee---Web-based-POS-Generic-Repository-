using Microsoft.EntityFrameworkCore;
using MVCSample.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data
{
	public class QuickeeContext:DbContext
	{
		public QuickeeContext(DbContextOptions<QuickeeContext> options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
	}
}
