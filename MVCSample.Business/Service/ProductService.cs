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

		public void UpdateQuantity(IEnumerable<OrderItemBL> OrderItems)
		{
			foreach (var item in OrderItems)
			{
				var product = unitOfWork.ProductRepository.FindById(item.ProductId);
				var CurrentQuantity = product.Quantity;
				var RequestedQuantity = item.Quantity;
				int NewQuantity;

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
				product.Quantity = NewQuantity;
				unitOfWork.ProductRepository.Update(product);
				unitOfWork.Save();
			}
		}
	}
}
