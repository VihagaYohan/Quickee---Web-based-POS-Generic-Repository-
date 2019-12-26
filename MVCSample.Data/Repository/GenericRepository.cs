﻿using Microsoft.EntityFrameworkCore;
using MVCSample.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly QuickeeContext db;
		private DbSet<TEntity> dataSet;

		public GenericRepository(QuickeeContext db)
		{
			this.db = db;
			dataSet = db.Set<TEntity>();
		}
		public IEnumerable<TEntity> GetAll()
		{
			return dataSet;
		}

		public void Create(TEntity entity)
		{
			dataSet.Add(entity);
			db.SaveChanges();
		}
	}
}