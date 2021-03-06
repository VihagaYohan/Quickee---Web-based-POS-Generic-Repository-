﻿using AutoMapper;
using MVCSample.Business.Entity;
using MVCSample.Business.IService;
using MVCSample.Data.Interface;
using MVCSample.Data.Model;
using System;
using System.Collections.Generic;

namespace MVCSample.Business
{
	public class CustomerService : ICustomerService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public CustomerService(IUnitOfWork unitOfWork,
							   IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public IEnumerable<CustomerBL> GetAll()
		{
			try
			{
				var ls_Cusomers = unitOfWork.CustomerRepository.GetAll();
				return mapper.Map<IEnumerable<CustomerBL>>(ls_Cusomers);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void AddCustomer(CustomerBL entity) 
		{
			try
			{
				var customer = mapper.Map<Customer>(entity);
				unitOfWork.CustomerRepository.Create(customer);
				unitOfWork.Save();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public CustomerBL FindById(int id)
		{
			var customer = unitOfWork.CustomerRepository.FindById(id);
			return mapper.Map<CustomerBL>(customer);
		}

		public CustomerBL UpdateCustomer(CustomerBL customer)
		{
			try
			{
				var CustomerEntity = mapper.Map<Customer>(customer);
				unitOfWork.CustomerRepository.Update(CustomerEntity);
				unitOfWork.Save();

				return customer;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void DeleteCustomer(CustomerBL customer)
		{
			throw new NotImplementedException();
		}
	}
}
