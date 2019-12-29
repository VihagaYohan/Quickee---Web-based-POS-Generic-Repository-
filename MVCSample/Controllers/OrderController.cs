using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCSample.Business.Entity;
using MVCSample.Business.IService;
using MVCSample.Data.Model;
using MVCSample.Entity;
using MVCSample.ViewModels;

namespace MVCSample.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public ICustomerService CustomerService { get; }
        public IProductService ProductService { get; }

        public OrderController(ICustomerService customerService,
                               IProductService productService,
                               IOrderService orderService,
                               IMapper mapper)
        {
            CustomerService = customerService;
            ProductService = productService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var ls_Orders = orderService.GetAll();
            var Orders = mapper.Map<IEnumerable<OrderPL>>(ls_Orders);
            return View(Orders);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            var ls_Customers = CustomerService.GetAll(); // customer list
            var ls_Products = ProductService.GetAll(); // product list
            var orderDate = DateTime.Now.ToShortDateString(); // order date

            var Customers = mapper.Map<IEnumerable<CustomerPL>>(ls_Customers);
            var Products = mapper.Map<IEnumerable<ProductPL>>(ls_Products);

            var viewModel = new OrderViewModel()
            {
                Customers = Customers,
                Products = Products,
                OrderDate = Convert.ToDateTime(orderDate)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(OrderBL order) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderService.AddOrder(mapper.Map<OrderBL>(order));
                    return RedirectToAction("Index");
                }
                else 
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}