using AutoMapper;
using MVCSample.Business.Entity;
using MVCSample.Business.Exceptions;
using MVCSample.Business.IService;
using MVCSample.Data.Interface;
using MVCSample.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCSample.Business.Service
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IProductService productService;
		private readonly IMapper mapper;

		public OrderService(IUnitOfWork unitOfWork,
							IProductService productService,
							IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.productService = productService;
			this.mapper = mapper;
		}

		public IEnumerable<OrderBL> GetAll()
		{
			try
			{
				var ls_Order = unitOfWork.OrderRepository.GetAll();
				return mapper.Map<IEnumerable<OrderBL>>(ls_Order);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void AddOrder(OrderBL order)
		{
			try
			{
				if (order == null)
				{
					throw new OrderNotFoundException();
				}
				else if (order.OrderItems == null)
				{
					throw new OrderItemNotFoundException();
				}
				else 
				{
					var objOrder = mapper.Map<Order>(order);

					using (var transaction = unitOfWork.Context.Database.BeginTransaction()) 
					{
						try
						{
							unitOfWork.OrderRepository.Create(objOrder);
							unitOfWork.Save();

							var ls_OrderItems = mapper.Map<IEnumerable<OrderItemBL>>(objOrder.OrderItems);
							productService.UpdateQuantity(ls_OrderItems);

							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							throw new Exception(ex.Message);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
