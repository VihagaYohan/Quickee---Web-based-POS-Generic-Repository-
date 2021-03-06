﻿using MVCSample.Business.Entity;
using MVCSample.Data.Model;
using MVCSample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSample
{
	public class MappingProfile:AutoMapper.Profile
	{
		public MappingProfile()
		{
			CreateMap<CustomerBL, Customer>().ReverseMap();
			CreateMap<CustomerPL, CustomerBL>().ReverseMap();

			CreateMap<ProductBL, Product>().ReverseMap();
			CreateMap<ProductPL, ProductBL>().ReverseMap();

			CreateMap<OrderBL, Order>().ReverseMap();
			CreateMap<OrderPL, OrderBL>().ReverseMap();

			CreateMap<OrderItemBL, OrderItem>().ReverseMap();
			CreateMap<OrderItemPL, OrderItemBL>().ReverseMap();
		}
	}
}
