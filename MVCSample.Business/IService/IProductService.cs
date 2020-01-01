using MVCSample.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.IService
{
	public interface IProductService
	{
		IEnumerable<ProductBL> GetAll();
		void Add(ProductBL product);
		ProductBL FindById(int id);
		void UpdateQuantity(IEnumerable<OrderItemBL> OrderItems);
	}
}
