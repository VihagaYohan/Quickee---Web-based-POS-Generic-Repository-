using MVCSample.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.IService
{
	public interface IOrderService
	{
		IEnumerable<OrderBL> GetAll();
		void AddOrder(OrderBL order);
	}
}
