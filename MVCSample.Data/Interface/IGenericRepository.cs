using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Data.Interface
{
	public interface IGenericRepository<TEntity> where TEntity:class
	{
		IEnumerable<TEntity> GetAll();
		void Create(TEntity entity);

		TEntity FindById(int id);
		void Update(TEntity entity);

		void Delete(TEntity entity);
		
	}
}
