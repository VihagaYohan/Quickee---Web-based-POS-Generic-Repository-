using AutoMapper;
using MVCSample.Business.Entity;
using MVCSample.Business.IService;
using MVCSample.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using MVCSample.Business.Exceptions;
using MVCSample.Data.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVCSample.Business.Service
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public ProductService(IUnitOfWork unitOfWork,
							  IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public IEnumerable<ProductBL> GetAll()
		{
			try
			{
				var ls_Product = unitOfWork.ProductRepository.GetAll().OrderBy(p => p.ProductId);
				return mapper.Map<IEnumerable<ProductBL>>(ls_Product);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Add(ProductBL entity) 
		{
			try
			{
				var product = mapper.Map<Product>(entity);
				unitOfWork.ProductRepository.Create(product);
				unitOfWork.Save();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ProductBL FindById(int id) 
		{
			try
			{
				var product = unitOfWork.ProductRepository.FindById(id);
				return mapper.Map<ProductBL>(product);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void UpdateQuantity(IEnumerable<OrderItemBL> OrderItems)
		{
			try
			{
				if (OrderItems == null)
				{
					throw new OrderItemNotFoundException();
				}
				else 
				{
					foreach (var item in OrderItems)
					{
						try
						{
							var product = unitOfWork.ProductRepository.FindById(item.ProductId);
							var existingOrderItem = unitOfWork.Context.OrderItems.AsNoTracking()
																				 .FirstOrDefault(o => o.OrderItemId == o.OrderItemId);
							var existingQuantity = existingOrderItem.Quantity;
							var CurrentQtyInStock = product.Quantity;
							var RequestedQuantity = item.Quantity;
							var QuantityToBeUpdated = 0;
							var NewQuantity = 0;

							if (RequestedQuantity < existingQuantity)
							{
								QuantityToBeUpdated = existingQuantity - RequestedQuantity;
								NewQuantity = CurrentQtyInStock + QuantityToBeUpdated;
							}
							else if (RequestedQuantity > existingQuantity)
							{
								QuantityToBeUpdated = RequestedQuantity - existingQuantity;
								NewQuantity = CurrentQtyInStock - QuantityToBeUpdated;
							}
							else if (RequestedQuantity == existingQuantity)
							{
								NewQuantity = CurrentQtyInStock - RequestedQuantity;
							}

							if (CurrentQtyInStock == 0)
							{
								throw new NotEnoughQuantityException();
							}

							product.Quantity = NewQuantity;
							unitOfWork.ProductRepository.Update(product);
							unitOfWork.Save();
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
