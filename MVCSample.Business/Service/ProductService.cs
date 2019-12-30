using AutoMapper;
using MVCSample.Business.Entity;
using MVCSample.Business.IService;
using MVCSample.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using MVCSample.Business.Exceptions;

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
				var ls_Product = unitOfWork.ProductRepository.GetAll();
				return mapper.Map<IEnumerable<ProductBL>>(ls_Product);
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

		public void UpdateQuantity(IEnumerable<OrderItemBL> OrderItems,bool AddItems)
		{
			try
			{
				foreach (var item in OrderItems)
				{
					if (item == null)
					{
						throw new OrderItemNotFoundException();
					}
					else 
					{
						using (var transaction = unitOfWork.Context.Database.BeginTransaction()) 
						{
							try
							{
								var product = unitOfWork.ProductRepository.FindById(item.ProductId);
								var CurrentQuantity = product.Quantity;
								var RequestedQuantity = item.Quantity;
								int NewQuantity = 0;

								if (AddItems == true)
								{
									product.QuantityToBeAdd = RequestedQuantity;
									NewQuantity = CurrentQuantity + product.QuantityToBeAdd;
								}
								else
								{
									if (RequestedQuantity <= CurrentQuantity)
									{
										NewQuantity = CurrentQuantity - RequestedQuantity;
									}
									else if (RequestedQuantity > CurrentQuantity)
									{
										throw new NotEnoughQuantityException();
									}
									else
									{
										throw new ProductNotAvailableException();
									}
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
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
